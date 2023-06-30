using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using RequestMocker.Classes;
using System.Timers;
using System.Drawing;

namespace RequestMocker
{
    public partial class MainView : Form
    {
        private Server server = null;
        private TokenGenerator tokenGenerator;
        private string currentToken;

        public MainView()
        {
            InitializeComponent();

            tokenGenerator = new TokenGenerator();

            // Adicione os códigos de status aos ComboBox
            List<int> successStatusCodes = new List<int> { 200, 201, 202, 204 };
            List<int> failureStatusCodes = new List<int> { 403, 401, 400, 404, 500 };

            successResponseCodeComboBox.DataSource = successStatusCodes;
            failureResponseCodeComboBox.DataSource = failureStatusCodes;

            server = new Server(
                urlTextBox.Text,
                (int)portNumericUpDown.Value,
                String.Empty,
                responseBodyTextBox.Text,
                (int)successResponseCodeComboBox.SelectedItem,
                (int)failureResponseCodeComboBox.SelectedItem
            );

            ToggleServerButton(server.IsRunning);

            // Verifique se o arquivo lastToken existe
            if (File.Exists("lastToken"))
            {
                try
                {
                    currentToken = File.ReadAllText("lastToken");

                    if (String.IsNullOrEmpty(currentToken))
                    {
                        throw new Exception("Token file is empty. Generating a new token...");
                    }

                    tokenTextBox.Text = currentToken;
                    server.UpdateToken(currentToken);
                    Console.WriteLine($"Using existing token: {currentToken}\r\n\r\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}\n");
                    GenerateAndSaveToken();
                }
            }
            else
            {
                GenerateAndSaveToken();
            }

            // Iniciar o temporizador
            requestUpdateTimer.Start();
        }

        private void toggleServerButton_Click(object sender, EventArgs e)
        {
            if (server.IsRunning)
            {
                try
                {
                    server.Stop();
                    logTextBox.AppendText("Server stopped successfully.\n");
                }
                catch (Exception ex)
                {
                    logTextBox.AppendText($"Error stopping server: {ex.Message}\n");
                }
            }
            else
            {
                try
                {
                    server.Start();
                    logTextBox.AppendText("Server started successfully.\n");
                }
                catch (Exception ex)
                {
                    logTextBox.AppendText($"Error starting server: {ex.Message}\n");
                }
            }
            ToggleServerButton(server.IsRunning);
        }

        private void generateNewToken_Click(object sender, EventArgs e)
        {
            GenerateAndSaveToken();
        }

        private void copyTokenButton_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(currentToken);
                logTextBox.Text += "\r\n\r\nToken copied to clipboard!\r\n\r\n";
            }
            catch (Exception ex)
            {
                logTextBox.Text += $"\r\n\r\nFailed to copy token: { ex.Message}\r\n\r\n";
            }
        }

        private void buttonUpdateUrl_Click(object sender, EventArgs e)
        {

        }

        private void requestUpdateTimer_Tick(object sender, EventArgs e)
        {
            // Se LastRequestDetails mudou desde a última vez que verificamos, atualize logTextBox
            if (server.LastRequestDetails != logTextBox.Text)
            {
                // Como estamos atualizando a UI de outro thread, precisamos usar Invoke
                Invoke(new Action(() =>
                {
                    logTextBox.Text = server.LastRequestDetails;
                }));
            }
        }

        private void GenerateAndSaveToken()
        {
            currentToken = tokenGenerator.GenerateToken();
            tokenTextBox.Text = currentToken;
            server.UpdateToken(currentToken);

            // Salva o token no arquivo
            try
            {
                File.WriteAllText("lastToken", currentToken);
                tokenTextBox.Text = currentToken;
                server.UpdateToken(currentToken);
                Console.WriteLine($"Generated new token: {currentToken}\r\n\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing token to file: {ex.Message}\n");
            }
        }

        private void buttonUpdateToken_Click(object sender, EventArgs e)
        {
            currentToken = tokenTextBox.Text;
            server.UpdateToken(currentToken);

            // Salva o token no arquivo
            try
            {
                File.WriteAllText("lastToken", currentToken);
                Console.WriteLine($"Updated token: {currentToken}\r\n\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing token to file: {ex.Message}\n");
            }
        }

        public void ToggleServerButton(bool isServerRunning)
        {
            if (isServerRunning)
            {
                toggleServerButton.Text = "Stop Server";
                toggleServerButton.Image = new Bitmap(Properties.Resources.stop);
            }
            else
            {
                toggleServerButton.Text = "Start Server";
                toggleServerButton.Image = new Bitmap(Properties.Resources.start);
            }

            // Redimensione a imagem para a altura do botão novamente.
            int buttonHeight = toggleServerButton.Height;
            toggleServerButton.Image = new Bitmap(toggleServerButton.Image, new Size(buttonHeight, buttonHeight));

            // Certifique-se de que o botão é redesenhado com as novas configurações.
            toggleServerButton.Invalidate();
        }

        private void responseBodyTextBox_TextChanged(object sender, EventArgs e)
        {
            server.UpdateResponseBody(responseBodyTextBox.Text);
        }
    }
}