namespace w3bot.GUI
{
    partial class Main
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
            this.textBoxLog = new System.Windows.Forms.RichTextBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.visitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mousePositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.pixelColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layoutBoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cannyEdgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magnifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.elementIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.BackColor = System.Drawing.Color.White;
            this.textBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLog.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLog.ForeColor = System.Drawing.Color.Black;
            this.textBoxLog.Location = new System.Drawing.Point(0, 608);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(994, 89);
            this.textBoxLog.TabIndex = 1;
            this.textBoxLog.Text = "";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.startToolStripMenuItem,
            this.inputToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(994, 24);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.toolStripSeparator1,
            this.visitToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.infoToolStripMenuItem.Image = global::w3bot.Resource1.application;
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.infoToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.Image = global::w3bot.Resource1.key;
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.accountToolStripMenuItem.Text = "Account";
            this.accountToolStripMenuItem.Click += new System.EventHandler(this.accountToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // visitToolStripMenuItem
            // 
            this.visitToolStripMenuItem.Name = "visitToolStripMenuItem";
            this.visitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.visitToolStripMenuItem.Text = "Visit w3bot.org";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(150, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem.Text = "Exit...";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem1,
            this.stopToolStripMenuItem,
            this.addToolStripMenuItem});
            this.startToolStripMenuItem.Image = global::w3bot.Resource1.script;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.startToolStripMenuItem.Text = "Script";
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.Image = global::w3bot.Resource1.control_play;
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem1.Text = "Start";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Image = global::w3bot.Resource1.control_stop;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::w3bot.Resource1.script_add;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Compile Script";
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allowToolStripMenuItem,
            this.blockToolStripMenuItem});
            this.inputToolStripMenuItem.Image = global::w3bot.Resource1.keyboard;
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.inputToolStripMenuItem.Text = "Input";
            // 
            // allowToolStripMenuItem
            // 
            this.allowToolStripMenuItem.Image = global::w3bot.Resource1.keyboard_add;
            this.allowToolStripMenuItem.Name = "allowToolStripMenuItem";
            this.allowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.allowToolStripMenuItem.Text = "Allow";
            // 
            // blockToolStripMenuItem
            // 
            this.blockToolStripMenuItem.Image = global::w3bot.Resource1.keyboard_delete;
            this.blockToolStripMenuItem.Name = "blockToolStripMenuItem";
            this.blockToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.blockToolStripMenuItem.Text = "Block";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logboxToolStripMenuItem,
            this.updatesToolStripMenuItem,
            this.toolStripSeparator3,
            this.mouseToolStripMenuItem,
            this.mousePositionToolStripMenuItem,
            this.toolStripSeparator5,
            this.pixelColorToolStripMenuItem,
            this.layoutBoundsToolStripMenuItem,
            this.cannyEdgesToolStripMenuItem,
            this.magnifierToolStripMenuItem,
            this.toolStripSeparator4,
            this.elementIDToolStripMenuItem,
            this.sourceCodeToolStripMenuItem});
            this.debugToolStripMenuItem.Image = global::w3bot.Resource1.bug;
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // logboxToolStripMenuItem
            // 
            this.logboxToolStripMenuItem.Checked = true;
            this.logboxToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logboxToolStripMenuItem.Name = "logboxToolStripMenuItem";
            this.logboxToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.logboxToolStripMenuItem.Text = "Show Logbox";
            this.logboxToolStripMenuItem.Click += new System.EventHandler(this.logboxToolStripMenuItem_Click);
            // 
            // updatesToolStripMenuItem
            // 
            this.updatesToolStripMenuItem.Name = "updatesToolStripMenuItem";
            this.updatesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.updatesToolStripMenuItem.Text = "No Double Buffer";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(163, 6);
            // 
            // mouseToolStripMenuItem
            // 
            this.mouseToolStripMenuItem.Name = "mouseToolStripMenuItem";
            this.mouseToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.mouseToolStripMenuItem.Text = "Mouse";
            // 
            // mousePositionToolStripMenuItem
            // 
            this.mousePositionToolStripMenuItem.Name = "mousePositionToolStripMenuItem";
            this.mousePositionToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.mousePositionToolStripMenuItem.Text = "Mouse Position";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(163, 6);
            // 
            // pixelColorToolStripMenuItem
            // 
            this.pixelColorToolStripMenuItem.Name = "pixelColorToolStripMenuItem";
            this.pixelColorToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.pixelColorToolStripMenuItem.Text = "Pixel Color";
            // 
            // layoutBoundsToolStripMenuItem
            // 
            this.layoutBoundsToolStripMenuItem.Name = "layoutBoundsToolStripMenuItem";
            this.layoutBoundsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.layoutBoundsToolStripMenuItem.Text = "Layout Bounds";
            // 
            // cannyEdgesToolStripMenuItem
            // 
            this.cannyEdgesToolStripMenuItem.Name = "cannyEdgesToolStripMenuItem";
            this.cannyEdgesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cannyEdgesToolStripMenuItem.Text = "Canny Edges";
            // 
            // magnifierToolStripMenuItem
            // 
            this.magnifierToolStripMenuItem.Name = "magnifierToolStripMenuItem";
            this.magnifierToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.magnifierToolStripMenuItem.Text = "Magnifier";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(163, 6);
            // 
            // elementIDToolStripMenuItem
            // 
            this.elementIDToolStripMenuItem.Name = "elementIDToolStripMenuItem";
            this.elementIDToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.elementIDToolStripMenuItem.Text = "Element ID";
            // 
            // sourceCodeToolStripMenuItem
            // 
            this.sourceCodeToolStripMenuItem.Name = "sourceCodeToolStripMenuItem";
            this.sourceCodeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.sourceCodeToolStripMenuItem.Text = "Source Code";
            this.sourceCodeToolStripMenuItem.Click += new System.EventHandler(this.sourceCodeToolStripMenuItem_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 27);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(994, 582);
            this.tabControlMain.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 697);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.textBoxLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "w3bot.org 0.0 - Idle...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBoxLog;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.ToolStripMenuItem updatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mousePositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elementIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem magnifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cannyEdgesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layoutBoundsToolStripMenuItem;
    }
}

