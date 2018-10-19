namespace w3bot.GUI
{
    partial class Account
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.LoginGroupBox = new System.Windows.Forms.GroupBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.linkLblCreateAccount = new System.Windows.Forms.LinkLabel();
            this.linkLblForgotPassword = new System.Windows.Forms.LinkLabel();
            this.lblProxy = new System.Windows.Forms.Label();
            this.cbProxy = new System.Windows.Forms.ComboBox();
            this.btnAddProxy = new System.Windows.Forms.Button();
            this.lblUserAgent = new System.Windows.Forms.Label();
            this.btnAddUserAgent = new System.Windows.Forms.Button();
            this.cbUserAgent = new System.Windows.Forms.ComboBox();
            this.lblBrowserFrames = new System.Windows.Forms.Label();
            this.tbBrowserFrames = new System.Windows.Forms.TextBox();
            this.SettingsGroupBox.SuspendLayout();
            this.LoginGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(19, 51);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(187, 20);
            this.tbUsername.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(19, 103);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(187, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 215);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(409, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // SettingsGroupBox
            // 
            this.SettingsGroupBox.Controls.Add(this.tbBrowserFrames);
            this.SettingsGroupBox.Controls.Add(this.lblBrowserFrames);
            this.SettingsGroupBox.Controls.Add(this.btnAddUserAgent);
            this.SettingsGroupBox.Controls.Add(this.cbUserAgent);
            this.SettingsGroupBox.Controls.Add(this.lblUserAgent);
            this.SettingsGroupBox.Controls.Add(this.btnAddProxy);
            this.SettingsGroupBox.Controls.Add(this.cbProxy);
            this.SettingsGroupBox.Controls.Add(this.lblProxy);
            this.SettingsGroupBox.Location = new System.Drawing.Point(13, 12);
            this.SettingsGroupBox.Name = "SettingsGroupBox";
            this.SettingsGroupBox.Size = new System.Drawing.Size(164, 197);
            this.SettingsGroupBox.TabIndex = 3;
            this.SettingsGroupBox.TabStop = false;
            this.SettingsGroupBox.Text = "Settings";
            // 
            // LoginGroupBox
            // 
            this.LoginGroupBox.Controls.Add(this.linkLblForgotPassword);
            this.LoginGroupBox.Controls.Add(this.linkLblCreateAccount);
            this.LoginGroupBox.Controls.Add(this.lblPassword);
            this.LoginGroupBox.Controls.Add(this.lblUsername);
            this.LoginGroupBox.Controls.Add(this.tbUsername);
            this.LoginGroupBox.Controls.Add(this.tbPassword);
            this.LoginGroupBox.Location = new System.Drawing.Point(194, 12);
            this.LoginGroupBox.Name = "LoginGroupBox";
            this.LoginGroupBox.Size = new System.Drawing.Size(228, 197);
            this.LoginGroupBox.TabIndex = 0;
            this.LoginGroupBox.TabStop = false;
            this.LoginGroupBox.Text = "User";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(16, 35);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 87);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // linkLblCreateAccount
            // 
            this.linkLblCreateAccount.AutoSize = true;
            this.linkLblCreateAccount.Location = new System.Drawing.Point(19, 138);
            this.linkLblCreateAccount.Name = "linkLblCreateAccount";
            this.linkLblCreateAccount.Size = new System.Drawing.Size(95, 13);
            this.linkLblCreateAccount.TabIndex = 5;
            this.linkLblCreateAccount.TabStop = true;
            this.linkLblCreateAccount.Text = "Create an account";
            // 
            // linkLblForgotPassword
            // 
            this.linkLblForgotPassword.AutoSize = true;
            this.linkLblForgotPassword.Location = new System.Drawing.Point(19, 161);
            this.linkLblForgotPassword.Name = "linkLblForgotPassword";
            this.linkLblForgotPassword.Size = new System.Drawing.Size(85, 13);
            this.linkLblForgotPassword.TabIndex = 6;
            this.linkLblForgotPassword.TabStop = true;
            this.linkLblForgotPassword.Text = "Forgot password";
            // 
            // lblProxy
            // 
            this.lblProxy.AutoSize = true;
            this.lblProxy.Location = new System.Drawing.Point(10, 28);
            this.lblProxy.Name = "lblProxy";
            this.lblProxy.Size = new System.Drawing.Size(33, 13);
            this.lblProxy.TabIndex = 4;
            this.lblProxy.Text = "Proxy";
            // 
            // cbProxy
            // 
            this.cbProxy.FormattingEnabled = true;
            this.cbProxy.Location = new System.Drawing.Point(13, 46);
            this.cbProxy.Name = "cbProxy";
            this.cbProxy.Size = new System.Drawing.Size(109, 21);
            this.cbProxy.TabIndex = 5;
            // 
            // btnAddProxy
            // 
            this.btnAddProxy.Location = new System.Drawing.Point(128, 46);
            this.btnAddProxy.Name = "btnAddProxy";
            this.btnAddProxy.Size = new System.Drawing.Size(24, 23);
            this.btnAddProxy.TabIndex = 7;
            this.btnAddProxy.Text = "+";
            this.btnAddProxy.UseVisualStyleBackColor = true;
            // 
            // lblUserAgent
            // 
            this.lblUserAgent.AutoSize = true;
            this.lblUserAgent.Location = new System.Drawing.Point(10, 93);
            this.lblUserAgent.Name = "lblUserAgent";
            this.lblUserAgent.Size = new System.Drawing.Size(63, 13);
            this.lblUserAgent.TabIndex = 8;
            this.lblUserAgent.Text = "User Agent:";
            // 
            // btnAddUserAgent
            // 
            this.btnAddUserAgent.Location = new System.Drawing.Point(128, 109);
            this.btnAddUserAgent.Name = "btnAddUserAgent";
            this.btnAddUserAgent.Size = new System.Drawing.Size(24, 23);
            this.btnAddUserAgent.TabIndex = 10;
            this.btnAddUserAgent.Text = "+";
            this.btnAddUserAgent.UseVisualStyleBackColor = true;
            // 
            // cbUserAgent
            // 
            this.cbUserAgent.FormattingEnabled = true;
            this.cbUserAgent.Location = new System.Drawing.Point(13, 109);
            this.cbUserAgent.Name = "cbUserAgent";
            this.cbUserAgent.Size = new System.Drawing.Size(109, 21);
            this.cbUserAgent.TabIndex = 9;
            // 
            // lblBrowserFrames
            // 
            this.lblBrowserFrames.AutoSize = true;
            this.lblBrowserFrames.Location = new System.Drawing.Point(10, 151);
            this.lblBrowserFrames.Name = "lblBrowserFrames";
            this.lblBrowserFrames.Size = new System.Drawing.Size(95, 13);
            this.lblBrowserFrames.TabIndex = 11;
            this.lblBrowserFrames.Text = "Browser Frames/s:";
            // 
            // tbBrowserFrames
            // 
            this.tbBrowserFrames.Location = new System.Drawing.Point(111, 148);
            this.tbBrowserFrames.Name = "tbBrowserFrames";
            this.tbBrowserFrames.Size = new System.Drawing.Size(41, 20);
            this.tbBrowserFrames.TabIndex = 7;
            this.tbBrowserFrames.Text = "30";
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 248);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.LoginGroupBox);
            this.Controls.Add(this.SettingsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Account";
            this.Text = "Login";
            this.SettingsGroupBox.ResumeLayout(false);
            this.SettingsGroupBox.PerformLayout();
            this.LoginGroupBox.ResumeLayout(false);
            this.LoginGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox SettingsGroupBox;
        private System.Windows.Forms.GroupBox LoginGroupBox;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.LinkLabel linkLblForgotPassword;
        private System.Windows.Forms.LinkLabel linkLblCreateAccount;
        private System.Windows.Forms.Button btnAddProxy;
        private System.Windows.Forms.ComboBox cbProxy;
        private System.Windows.Forms.Label lblProxy;
        private System.Windows.Forms.Label lblUserAgent;
        private System.Windows.Forms.TextBox tbBrowserFrames;
        private System.Windows.Forms.Label lblBrowserFrames;
        private System.Windows.Forms.Button btnAddUserAgent;
        private System.Windows.Forms.ComboBox cbUserAgent;
    }
}