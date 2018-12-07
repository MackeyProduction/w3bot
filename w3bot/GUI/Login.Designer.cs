namespace w3bot.GUI
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginGroupBox = new System.Windows.Forms.GroupBox();
            this.linkLblForgotPassword = new System.Windows.Forms.LinkLabel();
            this.linkLblCreateAccount = new System.Windows.Forms.LinkLabel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.LoginGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginGroupBox
            // 
            this.LoginGroupBox.Controls.Add(this.linkLblForgotPassword);
            this.LoginGroupBox.Controls.Add(this.linkLblCreateAccount);
            this.LoginGroupBox.Controls.Add(this.lblPassword);
            this.LoginGroupBox.Controls.Add(this.lblUsername);
            this.LoginGroupBox.Controls.Add(this.tbUsername);
            this.LoginGroupBox.Controls.Add(this.tbPassword);
            this.LoginGroupBox.Location = new System.Drawing.Point(12, 12);
            this.LoginGroupBox.Name = "LoginGroupBox";
            this.LoginGroupBox.Size = new System.Drawing.Size(228, 197);
            this.LoginGroupBox.TabIndex = 1;
            this.LoginGroupBox.TabStop = false;
            this.LoginGroupBox.Text = "User";
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
            this.linkLblForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblForgotPassword_LinkClicked);
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
            this.linkLblCreateAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblCreateAccount_LinkClicked);
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
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(16, 35);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username";
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
            this.btnLogin.Size = new System.Drawing.Size(228, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 253);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.LoginGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Login";
            this.Text = "Login";
            this.LoginGroupBox.ResumeLayout(false);
            this.LoginGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox LoginGroupBox;
        private System.Windows.Forms.LinkLabel linkLblForgotPassword;
        private System.Windows.Forms.LinkLabel linkLblCreateAccount;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}