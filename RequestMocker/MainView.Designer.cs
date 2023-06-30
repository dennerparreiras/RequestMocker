
using System.Drawing;
using System.Windows.Forms;

namespace RequestMocker
{
    partial class MainView
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.tokenTextBox = new System.Windows.Forms.TextBox();
            this.generateNewToken = new System.Windows.Forms.Button();
            this.toggleServerButton = new System.Windows.Forms.Button();
            this.copyTokenButton = new System.Windows.Forms.Button();
            this.labelLocalhost = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUpdateUrl = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.portNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.successResponseCodeComboBox = new System.Windows.Forms.ComboBox();
            this.failureResponseCodeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.requestUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonUpdateToken = new System.Windows.Forms.Button();
            this.configsGroupBox = new System.Windows.Forms.GroupBox();
            this.mainLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.responseBodyTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).BeginInit();
            this.configsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(214)))));
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTextBox.Location = new System.Drawing.Point(12, 12);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(652, 610);
            this.logTextBox.TabIndex = 1;
            this.logTextBox.Text = "Awaiting receipt of request. . .";
            // 
            // tokenTextBox
            // 
            this.tokenTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(214)))));
            this.tokenTextBox.Location = new System.Drawing.Point(7, 21);
            this.tokenTextBox.Name = "tokenTextBox";
            this.tokenTextBox.Size = new System.Drawing.Size(334, 24);
            this.tokenTextBox.TabIndex = 2;
            // 
            // generateNewToken
            // 
            this.generateNewToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(214)))), ((int)(((byte)(176)))));
            this.generateNewToken.FlatAppearance.BorderSize = 0;
            this.generateNewToken.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.generateNewToken.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.generateNewToken.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.generateNewToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateNewToken.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateNewToken.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.generateNewToken.Location = new System.Drawing.Point(126, 51);
            this.generateNewToken.Name = "generateNewToken";
            this.generateNewToken.Size = new System.Drawing.Size(134, 23);
            this.generateNewToken.TabIndex = 3;
            this.generateNewToken.Text = "Generate new token";
            this.generateNewToken.UseVisualStyleBackColor = false;
            this.generateNewToken.Click += new System.EventHandler(this.generateNewToken_Click);
            // 
            // toggleServerButton
            // 
            this.toggleServerButton.BackColor = System.Drawing.Color.Transparent;
            this.toggleServerButton.FlatAppearance.BorderSize = 0;
            this.toggleServerButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(208)))), ((int)(((byte)(156)))));
            this.toggleServerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.toggleServerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.toggleServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleServerButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleServerButton.ForeColor = System.Drawing.Color.Transparent;
            this.toggleServerButton.Image = ((System.Drawing.Image)(resources.GetObject("toggleServerButton.Image")));
            this.toggleServerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toggleServerButton.Location = new System.Drawing.Point(61, 410);
            this.toggleServerButton.Name = "toggleServerButton";
            this.toggleServerButton.Padding = new System.Windows.Forms.Padding(10);
            this.toggleServerButton.Size = new System.Drawing.Size(241, 61);
            this.toggleServerButton.TabIndex = 4;
            this.toggleServerButton.Text = "Toggle Server";
            this.toggleServerButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toggleServerButton.UseVisualStyleBackColor = false;
            this.toggleServerButton.Click += new System.EventHandler(this.toggleServerButton_Click);
            // 
            // copyTokenButton
            // 
            this.copyTokenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(214)))), ((int)(((byte)(176)))));
            this.copyTokenButton.FlatAppearance.BorderSize = 0;
            this.copyTokenButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.copyTokenButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.copyTokenButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.copyTokenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyTokenButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyTokenButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.copyTokenButton.Location = new System.Drawing.Point(190, 80);
            this.copyTokenButton.Name = "copyTokenButton";
            this.copyTokenButton.Size = new System.Drawing.Size(151, 23);
            this.copyTokenButton.TabIndex = 3;
            this.copyTokenButton.Text = "Copy token to clipboard";
            this.copyTokenButton.UseVisualStyleBackColor = false;
            this.copyTokenButton.Click += new System.EventHandler(this.copyTokenButton_Click);
            // 
            // labelLocalhost
            // 
            this.labelLocalhost.AutoSize = true;
            this.labelLocalhost.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocalhost.Location = new System.Drawing.Point(31, 123);
            this.labelLocalhost.Name = "labelLocalhost";
            this.labelLocalhost.Size = new System.Drawing.Size(71, 15);
            this.labelLocalhost.TabIndex = 5;
            this.labelLocalhost.Text = "Server URL: ";
            // 
            // urlTextBox
            // 
            this.urlTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(214)))));
            this.urlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urlTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlTextBox.Location = new System.Drawing.Point(6, 141);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.ReadOnly = true;
            this.urlTextBox.Size = new System.Drawing.Size(166, 20);
            this.urlTextBox.TabIndex = 6;
            this.urlTextBox.Text = "http://localhost";
            this.urlTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = ": ";
            // 
            // buttonUpdateUrl
            // 
            this.buttonUpdateUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(214)))), ((int)(((byte)(176)))));
            this.buttonUpdateUrl.FlatAppearance.BorderSize = 0;
            this.buttonUpdateUrl.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.buttonUpdateUrl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.buttonUpdateUrl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.buttonUpdateUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateUrl.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonUpdateUrl.Location = new System.Drawing.Point(273, 140);
            this.buttonUpdateUrl.Name = "buttonUpdateUrl";
            this.buttonUpdateUrl.Size = new System.Drawing.Size(68, 24);
            this.buttonUpdateUrl.TabIndex = 7;
            this.buttonUpdateUrl.Text = "Update";
            this.buttonUpdateUrl.UseVisualStyleBackColor = false;
            this.buttonUpdateUrl.Click += new System.EventHandler(this.buttonUpdateUrl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port:";
            // 
            // portNumericUpDown
            // 
            this.portNumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(214)))));
            this.portNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.portNumericUpDown.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portNumericUpDown.Location = new System.Drawing.Point(184, 140);
            this.portNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.portNumericUpDown.Name = "portNumericUpDown";
            this.portNumericUpDown.Size = new System.Drawing.Size(83, 23);
            this.portNumericUpDown.TabIndex = 8;
            this.portNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.portNumericUpDown.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // successResponseCodeComboBox
            // 
            this.successResponseCodeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(214)))));
            this.successResponseCodeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.successResponseCodeComboBox.FormattingEnabled = true;
            this.successResponseCodeComboBox.Location = new System.Drawing.Point(6, 193);
            this.successResponseCodeComboBox.Name = "successResponseCodeComboBox";
            this.successResponseCodeComboBox.Size = new System.Drawing.Size(121, 23);
            this.successResponseCodeComboBox.TabIndex = 9;
            // 
            // failureResponseCodeComboBox
            // 
            this.failureResponseCodeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(214)))));
            this.failureResponseCodeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.failureResponseCodeComboBox.FormattingEnabled = true;
            this.failureResponseCodeComboBox.Location = new System.Drawing.Point(220, 193);
            this.failureResponseCodeComboBox.Name = "failureResponseCodeComboBox";
            this.failureResponseCodeComboBox.Size = new System.Drawing.Size(121, 23);
            this.failureResponseCodeComboBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Success response:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(217, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Failure response:";
            // 
            // requestUpdateTimer
            // 
            this.requestUpdateTimer.Interval = 1000;
            this.requestUpdateTimer.Tick += new System.EventHandler(this.requestUpdateTimer_Tick);
            // 
            // buttonUpdateToken
            // 
            this.buttonUpdateToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(214)))), ((int)(((byte)(176)))));
            this.buttonUpdateToken.FlatAppearance.BorderSize = 0;
            this.buttonUpdateToken.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.buttonUpdateToken.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.buttonUpdateToken.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(86)))));
            this.buttonUpdateToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateToken.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateToken.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonUpdateToken.Location = new System.Drawing.Point(266, 51);
            this.buttonUpdateToken.Name = "buttonUpdateToken";
            this.buttonUpdateToken.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateToken.TabIndex = 3;
            this.buttonUpdateToken.Text = "Update";
            this.buttonUpdateToken.UseVisualStyleBackColor = false;
            this.buttonUpdateToken.Click += new System.EventHandler(this.buttonUpdateToken_Click);
            // 
            // configsGroupBox
            // 
            this.configsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.configsGroupBox.Controls.Add(this.toggleServerButton);
            this.configsGroupBox.Controls.Add(this.label4);
            this.configsGroupBox.Controls.Add(this.responseBodyTextBox);
            this.configsGroupBox.Controls.Add(this.tokenTextBox);
            this.configsGroupBox.Controls.Add(this.label5);
            this.configsGroupBox.Controls.Add(this.label3);
            this.configsGroupBox.Controls.Add(this.generateNewToken);
            this.configsGroupBox.Controls.Add(this.failureResponseCodeComboBox);
            this.configsGroupBox.Controls.Add(this.buttonUpdateToken);
            this.configsGroupBox.Controls.Add(this.successResponseCodeComboBox);
            this.configsGroupBox.Controls.Add(this.copyTokenButton);
            this.configsGroupBox.Controls.Add(this.portNumericUpDown);
            this.configsGroupBox.Controls.Add(this.labelLocalhost);
            this.configsGroupBox.Controls.Add(this.buttonUpdateUrl);
            this.configsGroupBox.Controls.Add(this.label2);
            this.configsGroupBox.Controls.Add(this.urlTextBox);
            this.configsGroupBox.Controls.Add(this.label1);
            this.configsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configsGroupBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.configsGroupBox.Location = new System.Drawing.Point(685, 12);
            this.configsGroupBox.Name = "configsGroupBox";
            this.configsGroupBox.Size = new System.Drawing.Size(347, 477);
            this.configsGroupBox.TabIndex = 11;
            this.configsGroupBox.TabStop = false;
            this.configsGroupBox.Text = "Configuration";
            // 
            // mainLogoPictureBox
            // 
            this.mainLogoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLogoPictureBox.ErrorImage = global::RequestMocker.Properties.Resources.RequestMocker_512;
            this.mainLogoPictureBox.Image = global::RequestMocker.Properties.Resources.RequestMocker_1024;
            this.mainLogoPictureBox.InitialImage = global::RequestMocker.Properties.Resources.RequestMocker_1024;
            this.mainLogoPictureBox.Location = new System.Drawing.Point(685, 495);
            this.mainLogoPictureBox.Name = "mainLogoPictureBox";
            this.mainLogoPictureBox.Size = new System.Drawing.Size(347, 127);
            this.mainLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainLogoPictureBox.TabIndex = 12;
            this.mainLogoPictureBox.TabStop = false;
            // 
            // responseBodyTextBox
            // 
            this.responseBodyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.responseBodyTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(214)))));
            this.responseBodyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.responseBodyTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.responseBodyTextBox.Location = new System.Drawing.Point(7, 253);
            this.responseBodyTextBox.Multiline = true;
            this.responseBodyTextBox.Name = "responseBodyTextBox";
            this.responseBodyTextBox.Size = new System.Drawing.Size(334, 151);
            this.responseBodyTextBox.TabIndex = 1;
            this.responseBodyTextBox.Text = "\"Response from server.\"";
            this.responseBodyTextBox.TextChanged += new System.EventHandler(this.responseBodyTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Success body response:";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(112)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(1044, 634);
            this.Controls.Add(this.mainLogoPictureBox);
            this.Controls.Add(this.configsGroupBox);
            this.Controls.Add(this.logTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainView";
            this.Text = "RequestMocker by @dennerparreiras";
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).EndInit();
            this.configsGroupBox.ResumeLayout(false);
            this.configsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainLogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.TextBox tokenTextBox;
        private System.Windows.Forms.Button generateNewToken;
        private System.Windows.Forms.Button toggleServerButton;
        private System.Windows.Forms.Button copyTokenButton;
        private System.Windows.Forms.Label labelLocalhost;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUpdateUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown portNumericUpDown;
        private System.Windows.Forms.ComboBox successResponseCodeComboBox;
        private System.Windows.Forms.ComboBox failureResponseCodeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer requestUpdateTimer;
        private System.Windows.Forms.Button buttonUpdateToken;
        private System.Windows.Forms.GroupBox configsGroupBox;
        private System.Windows.Forms.PictureBox mainLogoPictureBox;
        private TextBox responseBodyTextBox;
        private Label label5;
    }
}

