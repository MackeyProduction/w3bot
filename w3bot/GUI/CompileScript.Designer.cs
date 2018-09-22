namespace w3bot.GUI
{
    partial class CompileScript
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
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.rbFromDirectory = new System.Windows.Forms.RadioButton();
            this.rbDownload = new System.Windows.Forms.RadioButton();
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnCompile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUrl
            // 
            this.tbUrl.Enabled = false;
            this.tbUrl.Location = new System.Drawing.Point(12, 80);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(319, 20);
            this.tbUrl.TabIndex = 0;
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(185, 106);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(146, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download and compile";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // rbFromDirectory
            // 
            this.rbFromDirectory.AutoSize = true;
            this.rbFromDirectory.Checked = true;
            this.rbFromDirectory.Location = new System.Drawing.Point(12, 12);
            this.rbFromDirectory.Name = "rbFromDirectory";
            this.rbFromDirectory.Size = new System.Drawing.Size(145, 17);
            this.rbFromDirectory.TabIndex = 2;
            this.rbFromDirectory.TabStop = true;
            this.rbFromDirectory.Text = "Compile from src directory";
            this.rbFromDirectory.UseVisualStyleBackColor = true;
            this.rbFromDirectory.CheckedChanged += new System.EventHandler(this.rbFromDirectory_CheckedChanged);
            // 
            // rbDownload
            // 
            this.rbDownload.AutoSize = true;
            this.rbDownload.Location = new System.Drawing.Point(12, 35);
            this.rbDownload.Name = "rbDownload";
            this.rbDownload.Size = new System.Drawing.Size(119, 17);
            this.rbDownload.TabIndex = 3;
            this.rbDownload.Text = "Compile from Github";
            this.rbDownload.UseVisualStyleBackColor = true;
            this.rbDownload.CheckedChanged += new System.EventHandler(this.rbDownload_CheckedChanged);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Enabled = false;
            this.lblUrl.Location = new System.Drawing.Point(12, 64);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(32, 13);
            this.lblUrl.TabIndex = 4;
            this.lblUrl.Text = "URL:";
            // 
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(11, 106);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(146, 23);
            this.btnCompile.TabIndex = 5;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // CompileScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 137);
            this.Controls.Add(this.btnCompile);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.rbDownload);
            this.Controls.Add(this.rbFromDirectory);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.tbUrl);
            this.Name = "CompileScript";
            this.Text = "CompileScript";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.RadioButton rbFromDirectory;
        private System.Windows.Forms.RadioButton rbDownload;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Button btnCompile;
    }
}