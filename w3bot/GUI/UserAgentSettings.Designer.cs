namespace w3bot.GUI
{
    partial class UserAgentSettings
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
            this.lblOperatingSystem = new System.Windows.Forms.Label();
            this.cbOperatingSystem = new System.Windows.Forms.ComboBox();
            this.lblOperatingSystemVersion = new System.Windows.Forms.Label();
            this.cbOperatingSystemVersion = new System.Windows.Forms.ComboBox();
            this.gbOperatingSystem = new System.Windows.Forms.GroupBox();
            this.gbSoftware = new System.Windows.Forms.GroupBox();
            this.lvlBrowser = new System.Windows.Forms.Label();
            this.cbBrowserVersion = new System.Windows.Forms.ComboBox();
            this.cbBrowser = new System.Windows.Forms.ComboBox();
            this.lblBrowserVersion = new System.Windows.Forms.Label();
            this.lblLayoutEngine = new System.Windows.Forms.Label();
            this.cbLayoutEngineVersion = new System.Windows.Forms.ComboBox();
            this.cbLayoutEngine = new System.Windows.Forms.ComboBox();
            this.lblLayoutEngineVersion = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblUserAgent = new System.Windows.Forms.Label();
            this.gbOperatingSystem.SuspendLayout();
            this.gbSoftware.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOperatingSystem
            // 
            this.lblOperatingSystem.AutoSize = true;
            this.lblOperatingSystem.Location = new System.Drawing.Point(16, 26);
            this.lblOperatingSystem.Name = "lblOperatingSystem";
            this.lblOperatingSystem.Size = new System.Drawing.Size(38, 13);
            this.lblOperatingSystem.TabIndex = 0;
            this.lblOperatingSystem.Text = "Name:";
            // 
            // cbOperatingSystem
            // 
            this.cbOperatingSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperatingSystem.FormattingEnabled = true;
            this.cbOperatingSystem.Location = new System.Drawing.Point(19, 42);
            this.cbOperatingSystem.Name = "cbOperatingSystem";
            this.cbOperatingSystem.Size = new System.Drawing.Size(236, 21);
            this.cbOperatingSystem.TabIndex = 1;
            // 
            // lblOperatingSystemVersion
            // 
            this.lblOperatingSystemVersion.AutoSize = true;
            this.lblOperatingSystemVersion.Location = new System.Drawing.Point(16, 83);
            this.lblOperatingSystemVersion.Name = "lblOperatingSystemVersion";
            this.lblOperatingSystemVersion.Size = new System.Drawing.Size(45, 13);
            this.lblOperatingSystemVersion.TabIndex = 2;
            this.lblOperatingSystemVersion.Text = "Version:";
            // 
            // cbOperatingSystemVersion
            // 
            this.cbOperatingSystemVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperatingSystemVersion.FormattingEnabled = true;
            this.cbOperatingSystemVersion.Location = new System.Drawing.Point(144, 80);
            this.cbOperatingSystemVersion.Name = "cbOperatingSystemVersion";
            this.cbOperatingSystemVersion.Size = new System.Drawing.Size(111, 21);
            this.cbOperatingSystemVersion.TabIndex = 3;
            // 
            // gbOperatingSystem
            // 
            this.gbOperatingSystem.Controls.Add(this.lblOperatingSystem);
            this.gbOperatingSystem.Controls.Add(this.cbOperatingSystemVersion);
            this.gbOperatingSystem.Controls.Add(this.cbOperatingSystem);
            this.gbOperatingSystem.Controls.Add(this.lblOperatingSystemVersion);
            this.gbOperatingSystem.Location = new System.Drawing.Point(12, 12);
            this.gbOperatingSystem.Name = "gbOperatingSystem";
            this.gbOperatingSystem.Size = new System.Drawing.Size(275, 131);
            this.gbOperatingSystem.TabIndex = 4;
            this.gbOperatingSystem.TabStop = false;
            this.gbOperatingSystem.Text = "Operating System";
            // 
            // gbSoftware
            // 
            this.gbSoftware.Controls.Add(this.lblLayoutEngine);
            this.gbSoftware.Controls.Add(this.cbLayoutEngineVersion);
            this.gbSoftware.Controls.Add(this.cbLayoutEngine);
            this.gbSoftware.Controls.Add(this.lblLayoutEngineVersion);
            this.gbSoftware.Controls.Add(this.lvlBrowser);
            this.gbSoftware.Controls.Add(this.cbBrowserVersion);
            this.gbSoftware.Controls.Add(this.cbBrowser);
            this.gbSoftware.Controls.Add(this.lblBrowserVersion);
            this.gbSoftware.Location = new System.Drawing.Point(12, 149);
            this.gbSoftware.Name = "gbSoftware";
            this.gbSoftware.Size = new System.Drawing.Size(275, 220);
            this.gbSoftware.TabIndex = 5;
            this.gbSoftware.TabStop = false;
            this.gbSoftware.Text = "Software";
            // 
            // lvlBrowser
            // 
            this.lvlBrowser.AutoSize = true;
            this.lvlBrowser.Location = new System.Drawing.Point(16, 26);
            this.lvlBrowser.Name = "lvlBrowser";
            this.lvlBrowser.Size = new System.Drawing.Size(48, 13);
            this.lvlBrowser.TabIndex = 0;
            this.lvlBrowser.Text = "Browser:";
            // 
            // cbBrowserVersion
            // 
            this.cbBrowserVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrowserVersion.FormattingEnabled = true;
            this.cbBrowserVersion.Location = new System.Drawing.Point(144, 80);
            this.cbBrowserVersion.Name = "cbBrowserVersion";
            this.cbBrowserVersion.Size = new System.Drawing.Size(111, 21);
            this.cbBrowserVersion.TabIndex = 3;
            // 
            // cbBrowser
            // 
            this.cbBrowser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrowser.FormattingEnabled = true;
            this.cbBrowser.Location = new System.Drawing.Point(19, 42);
            this.cbBrowser.Name = "cbBrowser";
            this.cbBrowser.Size = new System.Drawing.Size(236, 21);
            this.cbBrowser.TabIndex = 1;
            // 
            // lblBrowserVersion
            // 
            this.lblBrowserVersion.AutoSize = true;
            this.lblBrowserVersion.Location = new System.Drawing.Point(16, 83);
            this.lblBrowserVersion.Name = "lblBrowserVersion";
            this.lblBrowserVersion.Size = new System.Drawing.Size(86, 13);
            this.lblBrowserVersion.TabIndex = 2;
            this.lblBrowserVersion.Text = "Browser Version:";
            // 
            // lblLayoutEngine
            // 
            this.lblLayoutEngine.AutoSize = true;
            this.lblLayoutEngine.Location = new System.Drawing.Point(16, 125);
            this.lblLayoutEngine.Name = "lblLayoutEngine";
            this.lblLayoutEngine.Size = new System.Drawing.Size(78, 13);
            this.lblLayoutEngine.TabIndex = 4;
            this.lblLayoutEngine.Text = "Layout Engine:";
            // 
            // cbLayoutEngineVersion
            // 
            this.cbLayoutEngineVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLayoutEngineVersion.FormattingEnabled = true;
            this.cbLayoutEngineVersion.Location = new System.Drawing.Point(144, 179);
            this.cbLayoutEngineVersion.Name = "cbLayoutEngineVersion";
            this.cbLayoutEngineVersion.Size = new System.Drawing.Size(111, 21);
            this.cbLayoutEngineVersion.TabIndex = 7;
            // 
            // cbLayoutEngine
            // 
            this.cbLayoutEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLayoutEngine.FormattingEnabled = true;
            this.cbLayoutEngine.Location = new System.Drawing.Point(19, 141);
            this.cbLayoutEngine.Name = "cbLayoutEngine";
            this.cbLayoutEngine.Size = new System.Drawing.Size(236, 21);
            this.cbLayoutEngine.TabIndex = 5;
            // 
            // lblLayoutEngineVersion
            // 
            this.lblLayoutEngineVersion.AutoSize = true;
            this.lblLayoutEngineVersion.Location = new System.Drawing.Point(16, 182);
            this.lblLayoutEngineVersion.Name = "lblLayoutEngineVersion";
            this.lblLayoutEngineVersion.Size = new System.Drawing.Size(116, 13);
            this.lblLayoutEngineVersion.TabIndex = 6;
            this.lblLayoutEngineVersion.Text = "Layout Engine Version:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 402);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(275, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblUserAgent
            // 
            this.lblUserAgent.AutoSize = true;
            this.lblUserAgent.Location = new System.Drawing.Point(13, 381);
            this.lblUserAgent.Name = "lblUserAgent";
            this.lblUserAgent.Size = new System.Drawing.Size(63, 13);
            this.lblUserAgent.TabIndex = 7;
            this.lblUserAgent.Text = "User Agent:";
            // 
            // UserAgentSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 437);
            this.Controls.Add(this.lblUserAgent);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbSoftware);
            this.Controls.Add(this.gbOperatingSystem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserAgentSettings";
            this.Text = "User Agent settings";
            this.Load += new System.EventHandler(this.UserAgentSettings_Load);
            this.gbOperatingSystem.ResumeLayout(false);
            this.gbOperatingSystem.PerformLayout();
            this.gbSoftware.ResumeLayout(false);
            this.gbSoftware.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOperatingSystem;
        private System.Windows.Forms.ComboBox cbOperatingSystem;
        private System.Windows.Forms.Label lblOperatingSystemVersion;
        private System.Windows.Forms.ComboBox cbOperatingSystemVersion;
        private System.Windows.Forms.GroupBox gbOperatingSystem;
        private System.Windows.Forms.GroupBox gbSoftware;
        private System.Windows.Forms.Label lblLayoutEngine;
        private System.Windows.Forms.ComboBox cbLayoutEngineVersion;
        private System.Windows.Forms.ComboBox cbLayoutEngine;
        private System.Windows.Forms.Label lblLayoutEngineVersion;
        private System.Windows.Forms.Label lvlBrowser;
        private System.Windows.Forms.ComboBox cbBrowserVersion;
        private System.Windows.Forms.ComboBox cbBrowser;
        private System.Windows.Forms.Label lblBrowserVersion;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUserAgent;
    }
}