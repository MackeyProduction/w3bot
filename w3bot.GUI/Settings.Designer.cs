namespace w3bot.GUI
{
    partial class Settings
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
            this.btnClearCache = new System.Windows.Forms.Button();
            this.gbCaptcha = new System.Windows.Forms.GroupBox();
            this.rbCaptchaSolveByBotOrService = new System.Windows.Forms.RadioButton();
            this.rbCaptchaSolveByBot = new System.Windows.Forms.RadioButton();
            this.gbCache = new System.Windows.Forms.GroupBox();
            this.lblCacheSize = new System.Windows.Forms.Label();
            this.rbClearCacheOnClose = new System.Windows.Forms.RadioButton();
            this.rbKeepCache = new System.Windows.Forms.RadioButton();
            this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.tbBrowserFrames = new System.Windows.Forms.TextBox();
            this.lblBrowserFrames = new System.Windows.Forms.Label();
            this.btnAddUserAgent = new System.Windows.Forms.Button();
            this.cbUserAgent = new System.Windows.Forms.ComboBox();
            this.lblUserAgent = new System.Windows.Forms.Label();
            this.btnAddProxy = new System.Windows.Forms.Button();
            this.cbProxy = new System.Windows.Forms.ComboBox();
            this.lblProxy = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.gbCaptcha.SuspendLayout();
            this.gbCache.SuspendLayout();
            this.SettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearCache
            // 
            this.btnClearCache.Location = new System.Drawing.Point(6, 64);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(81, 23);
            this.btnClearCache.TabIndex = 1;
            this.btnClearCache.Text = "Clear";
            this.btnClearCache.UseVisualStyleBackColor = true;
            // 
            // gbCaptcha
            // 
            this.gbCaptcha.Controls.Add(this.rbCaptchaSolveByBotOrService);
            this.gbCaptcha.Controls.Add(this.rbCaptchaSolveByBot);
            this.gbCaptcha.Location = new System.Drawing.Point(149, 11);
            this.gbCaptcha.Name = "gbCaptcha";
            this.gbCaptcha.Size = new System.Drawing.Size(199, 139);
            this.gbCaptcha.TabIndex = 4;
            this.gbCaptcha.TabStop = false;
            this.gbCaptcha.Text = "Captcha";
            // 
            // rbCaptchaSolveByBotOrService
            // 
            this.rbCaptchaSolveByBotOrService.Location = new System.Drawing.Point(6, 42);
            this.rbCaptchaSolveByBotOrService.Name = "rbCaptchaSolveByBotOrService";
            this.rbCaptchaSolveByBotOrService.Size = new System.Drawing.Size(188, 32);
            this.rbCaptchaSolveByBotOrService.TabIndex = 1;
            this.rbCaptchaSolveByBotOrService.Text = "Solve by bot if not possible by captcha service or user";
            this.rbCaptchaSolveByBotOrService.UseVisualStyleBackColor = true;
            // 
            // rbCaptchaSolveByBot
            // 
            this.rbCaptchaSolveByBot.AutoSize = true;
            this.rbCaptchaSolveByBot.Checked = true;
            this.rbCaptchaSolveByBot.Location = new System.Drawing.Point(6, 19);
            this.rbCaptchaSolveByBot.Name = "rbCaptchaSolveByBot";
            this.rbCaptchaSolveByBot.Size = new System.Drawing.Size(188, 17);
            this.rbCaptchaSolveByBot.TabIndex = 0;
            this.rbCaptchaSolveByBot.TabStop = true;
            this.rbCaptchaSolveByBot.Text = "Solve by bot if not possible by user";
            this.rbCaptchaSolveByBot.UseVisualStyleBackColor = true;
            // 
            // gbCache
            // 
            this.gbCache.Controls.Add(this.lblCacheSize);
            this.gbCache.Controls.Add(this.rbClearCacheOnClose);
            this.gbCache.Controls.Add(this.rbKeepCache);
            this.gbCache.Controls.Add(this.btnClearCache);
            this.gbCache.Location = new System.Drawing.Point(12, 12);
            this.gbCache.Name = "gbCache";
            this.gbCache.Size = new System.Drawing.Size(131, 138);
            this.gbCache.TabIndex = 5;
            this.gbCache.TabStop = false;
            this.gbCache.Text = "Cache";
            // 
            // lblCacheSize
            // 
            this.lblCacheSize.AutoSize = true;
            this.lblCacheSize.Location = new System.Drawing.Point(6, 106);
            this.lblCacheSize.Name = "lblCacheSize";
            this.lblCacheSize.Size = new System.Drawing.Size(30, 13);
            this.lblCacheSize.TabIndex = 4;
            this.lblCacheSize.Text = "Size:";
            // 
            // rbClearCacheOnClose
            // 
            this.rbClearCacheOnClose.AutoSize = true;
            this.rbClearCacheOnClose.Location = new System.Drawing.Point(6, 41);
            this.rbClearCacheOnClose.Name = "rbClearCacheOnClose";
            this.rbClearCacheOnClose.Size = new System.Drawing.Size(92, 17);
            this.rbClearCacheOnClose.TabIndex = 3;
            this.rbClearCacheOnClose.Text = "Clear on close";
            this.rbClearCacheOnClose.UseVisualStyleBackColor = true;
            // 
            // rbKeepCache
            // 
            this.rbKeepCache.AutoSize = true;
            this.rbKeepCache.Checked = true;
            this.rbKeepCache.Location = new System.Drawing.Point(6, 18);
            this.rbKeepCache.Name = "rbKeepCache";
            this.rbKeepCache.Size = new System.Drawing.Size(50, 17);
            this.rbKeepCache.TabIndex = 2;
            this.rbKeepCache.TabStop = true;
            this.rbKeepCache.Text = "Keep";
            this.rbKeepCache.UseVisualStyleBackColor = true;
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
            this.SettingsGroupBox.Location = new System.Drawing.Point(12, 156);
            this.SettingsGroupBox.Name = "SettingsGroupBox";
            this.SettingsGroupBox.Size = new System.Drawing.Size(336, 197);
            this.SettingsGroupBox.TabIndex = 6;
            this.SettingsGroupBox.TabStop = false;
            this.SettingsGroupBox.Text = "Settings";
            // 
            // tbBrowserFrames
            // 
            this.tbBrowserFrames.Location = new System.Drawing.Point(111, 148);
            this.tbBrowserFrames.Name = "tbBrowserFrames";
            this.tbBrowserFrames.Size = new System.Drawing.Size(41, 20);
            this.tbBrowserFrames.TabIndex = 7;
            this.tbBrowserFrames.Text = "30";
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
            // btnAddUserAgent
            // 
            this.btnAddUserAgent.Location = new System.Drawing.Point(306, 109);
            this.btnAddUserAgent.Name = "btnAddUserAgent";
            this.btnAddUserAgent.Size = new System.Drawing.Size(24, 23);
            this.btnAddUserAgent.TabIndex = 10;
            this.btnAddUserAgent.Text = "+";
            this.btnAddUserAgent.UseVisualStyleBackColor = true;
            this.btnAddUserAgent.Click += new System.EventHandler(this.btnAddUserAgent_Click);
            // 
            // cbUserAgent
            // 
            this.cbUserAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserAgent.FormattingEnabled = true;
            this.cbUserAgent.Location = new System.Drawing.Point(13, 111);
            this.cbUserAgent.Name = "cbUserAgent";
            this.cbUserAgent.Size = new System.Drawing.Size(287, 21);
            this.cbUserAgent.TabIndex = 9;
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
            // btnAddProxy
            // 
            this.btnAddProxy.Location = new System.Drawing.Point(306, 46);
            this.btnAddProxy.Name = "btnAddProxy";
            this.btnAddProxy.Size = new System.Drawing.Size(24, 23);
            this.btnAddProxy.TabIndex = 7;
            this.btnAddProxy.Text = "+";
            this.btnAddProxy.UseVisualStyleBackColor = true;
            this.btnAddProxy.Click += new System.EventHandler(this.btnAddProxy_Click);
            // 
            // cbProxy
            // 
            this.cbProxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProxy.FormattingEnabled = true;
            this.cbProxy.Location = new System.Drawing.Point(13, 46);
            this.cbProxy.Name = "cbProxy";
            this.cbProxy.Size = new System.Drawing.Size(287, 21);
            this.cbProxy.TabIndex = 5;
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
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(12, 359);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(336, 23);
            this.btnSaveSettings.TabIndex = 7;
            this.btnSaveSettings.Text = "Save settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 394);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.SettingsGroupBox);
            this.Controls.Add(this.gbCaptcha);
            this.Controls.Add(this.gbCache);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.gbCaptcha.ResumeLayout(false);
            this.gbCaptcha.PerformLayout();
            this.gbCache.ResumeLayout(false);
            this.gbCache.PerformLayout();
            this.SettingsGroupBox.ResumeLayout(false);
            this.SettingsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClearCache;
        private System.Windows.Forms.GroupBox gbCaptcha;
        private System.Windows.Forms.RadioButton rbCaptchaSolveByBotOrService;
        private System.Windows.Forms.RadioButton rbCaptchaSolveByBot;
        private System.Windows.Forms.GroupBox gbCache;
        private System.Windows.Forms.Label lblCacheSize;
        private System.Windows.Forms.RadioButton rbClearCacheOnClose;
        private System.Windows.Forms.RadioButton rbKeepCache;
        private System.Windows.Forms.GroupBox SettingsGroupBox;
        private System.Windows.Forms.TextBox tbBrowserFrames;
        private System.Windows.Forms.Label lblBrowserFrames;
        private System.Windows.Forms.Button btnAddUserAgent;
        private System.Windows.Forms.ComboBox cbUserAgent;
        private System.Windows.Forms.Label lblUserAgent;
        private System.Windows.Forms.Button btnAddProxy;
        private System.Windows.Forms.ComboBox cbProxy;
        private System.Windows.Forms.Label lblProxy;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}