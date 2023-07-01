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

        /// <summary>
        /// Constructor for the MainView class.
        /// Initializes components, loads status codes, initializes the server, and checks for an existing token.
        /// </summary>
        public MainView()
        {
            InitializeComponent();

            tokenGenerator = new TokenGenerator();

            // Initialize status codes for successful and failed requests
            List<int> successStatusCodes = new List<int> { 200, 201, 202, 204 };
            List<int> failureStatusCodes = new List<int> { 403, 401, 400, 404, 500 };

            successResponseCodeComboBox.DataSource = successStatusCodes;
            failureResponseCodeComboBox.DataSource = failureStatusCodes;

            // Initialize the server with empty token and response body from the textbox
            server = new Server(
                urlTextBox.Text,
                (int)portNumericUpDown.Value,
                String.Empty,
                responseBodyTextBox.Text,
                (int)successResponseCodeComboBox.SelectedItem,
                (int)failureResponseCodeComboBox.SelectedItem
            );

            // Set the button's initial state based on whether the server is running
            ToggleServerButton(server.IsRunning);

            // Check if a token file already exists. If not, generate a new one.
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

            // Start the timer to check for request updates
            requestUpdateTimer.Start();
        }

        /// <summary>
        /// Event handler for the server toggle button click.
        /// Stops the server if it's running, starts it otherwise.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
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

        /// <summary>
        /// Event handler for the "Generate New Token" button click.
        /// Calls the GenerateAndSaveToken method.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void generateNewToken_Click(object sender, EventArgs e)
        {
            GenerateAndSaveToken();
        }

        /// <summary>
        /// Event handler for the "Copy Token" button click.
        /// Copies the current token to the clipboard.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
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

        /// <summary>
        /// Event handler for the timer tick.
        /// Checks if the last request details changed, and updates the log textbox accordingly.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void requestUpdateTimer_Tick(object sender, EventArgs e)
        {
            // If LastRequestDetails changed since the last time we checked, update logTextBox
            if (server.LastRequestDetails != logTextBox.Text)
            {
                // Since we're updating the UI from another thread, we need to use Invoke
                Invoke(new Action(() =>
                {
                    logTextBox.Text = server.LastRequestDetails;
                }));
            }
        }

        /// <summary>
        /// Generates a new token, updates the server and textbox with it, and saves it to a file.
        /// </summary>
        private void GenerateAndSaveToken()
        {
            currentToken = tokenGenerator.GenerateToken();
            tokenTextBox.Text = currentToken;
            server.UpdateToken(currentToken);

            // Save the token to file
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

        /// <summary>
        /// Event handler for the "Update Token" button click.
        /// Updates the token on the server and saves it to a file.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void buttonUpdateToken_Click(object sender, EventArgs e)
        {
            currentToken = tokenTextBox.Text;
            server.UpdateToken(currentToken);

            // Save the token to file
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

        /// <summary>
        /// Updates the server button text and image based on the server status.
        /// </summary>
        /// <param name="isServerRunning">Whether the server is currently running.</param>
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

            // Resize the image to match the button's height.
            int buttonHeight = toggleServerButton.Height;
            toggleServerButton.Image = new Bitmap(toggleServerButton.Image, new Size(buttonHeight, buttonHeight));

            // Ensure the button is redrawn with the new settings.
            toggleServerButton.Invalidate();
        }

        /// <summary>
        /// Event handler for the response body textbox's TextChanged event.
        /// Updates the server's response body with the new text.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void responseBodyTextBox_TextChanged(object sender, EventArgs e)
        {
            server.UpdateResponseBody(responseBodyTextBox.Text);
        }

        /// <summary>
        /// Event handler for the "Update URL" button click.
        /// Updates the URL on the server based on the text in the URL textbox.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void buttonUpdateUrl_Click(object sender, EventArgs e)
        {
            string newUrl = urlTextBox.Text; // Assume you have a textbox for the URL.

            try
            {
                // Assume that you have a method called "UpdateUrl" on the server class.
                server.UpdateUrl(newUrl);
                Console.WriteLine($"Updated URL: {newUrl}\r\n\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating URL: {ex.Message}\n");
            }
        }

    }
}
