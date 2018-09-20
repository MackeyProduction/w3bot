using System;

namespace w3bot.GUI
{
    partial class Scriptmanager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scriptmanager));
            this.listViewScripts = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderApp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelScript = new System.Windows.Forms.Label();
            this.progressBarLoad = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // listViewScripts
            // 
            this.listViewScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderApp,
            this.columnHeaderDes,
            this.columnHeaderAuthor,
            this.columnHeaderVer});
            this.listViewScripts.FullRowSelect = true;
            this.listViewScripts.GridLines = true;
            this.listViewScripts.Location = new System.Drawing.Point(0, 0);
            this.listViewScripts.MultiSelect = false;
            this.listViewScripts.Name = "listViewScripts";
            this.listViewScripts.Size = new System.Drawing.Size(565, 201);
            this.listViewScripts.TabIndex = 1;
            this.listViewScripts.UseCompatibleStateImageBehavior = false;
            this.listViewScripts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 119;
            // 
            // columnHeaderApp
            // 
            this.columnHeaderApp.Text = "Target App";
            this.columnHeaderApp.Width = 72;
            // 
            // columnHeaderDes
            // 
            this.columnHeaderDes.Text = "Description";
            this.columnHeaderDes.Width = 219;
            // 
            // columnHeaderAuthor
            // 
            this.columnHeaderAuthor.Text = "Author";
            this.columnHeaderAuthor.Width = 70;
            // 
            // columnHeaderVer
            // 
            this.columnHeaderVer.Text = "Version";
            this.columnHeaderVer.Width = 51;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(490, 207);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Script-Location:";
            // 
            // labelScript
            // 
            this.labelScript.AutoSize = true;
            this.labelScript.Location = new System.Drawing.Point(99, 212);
            this.labelScript.Name = "labelScript";
            this.labelScript.Size = new System.Drawing.Size(10, 13);
            this.labelScript.TabIndex = 4;
            this.labelScript.Text = "-";
            // 
            // progressBarLoad
            // 
            this.progressBarLoad.Location = new System.Drawing.Point(0, 188);
            this.progressBarLoad.MarqueeAnimationSpeed = 50;
            this.progressBarLoad.Name = "progressBarLoad";
            this.progressBarLoad.Size = new System.Drawing.Size(565, 13);
            this.progressBarLoad.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarLoad.TabIndex = 5;
            // 
            // Scriptmanager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 233);
            this.Controls.Add(this.progressBarLoad);
            this.Controls.Add(this.labelScript);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listViewScripts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scriptmanager";
            this.Text = "Scriptmanager";
            this.Load += new System.EventHandler(this.Scriptmanager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Scriptmanager_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.ListView listViewScripts;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelScript;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderApp;
        private System.Windows.Forms.ColumnHeader columnHeaderDes;
        private System.Windows.Forms.ColumnHeader columnHeaderAuthor;
        private System.Windows.Forms.ColumnHeader columnHeaderVer;
        private System.Windows.Forms.ProgressBar progressBarLoad;
    }
}