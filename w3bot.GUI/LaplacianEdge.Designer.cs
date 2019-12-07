namespace w3bot.GUI
{
    partial class LaplacianEdge
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
            this.laplacianEdgeParameters = new System.Windows.Forms.GroupBox();
            this.numericApertureSize = new System.Windows.Forms.NumericUpDown();
            this.lblApertureSize = new System.Windows.Forms.Label();
            this.laplacianEdgeParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericApertureSize)).BeginInit();
            this.SuspendLayout();
            // 
            // laplacianEdgeParameters
            // 
            this.laplacianEdgeParameters.Controls.Add(this.numericApertureSize);
            this.laplacianEdgeParameters.Controls.Add(this.lblApertureSize);
            this.laplacianEdgeParameters.Location = new System.Drawing.Point(16, 16);
            this.laplacianEdgeParameters.Name = "laplacianEdgeParameters";
            this.laplacianEdgeParameters.Size = new System.Drawing.Size(308, 130);
            this.laplacianEdgeParameters.TabIndex = 1;
            this.laplacianEdgeParameters.TabStop = false;
            this.laplacianEdgeParameters.Text = "Laplacian";
            // 
            // numericApertureSize
            // 
            this.numericApertureSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericApertureSize.Location = new System.Drawing.Point(160, 50);
            this.numericApertureSize.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericApertureSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericApertureSize.Name = "numericApertureSize";
            this.numericApertureSize.Size = new System.Drawing.Size(80, 20);
            this.numericApertureSize.TabIndex = 2;
            this.numericApertureSize.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericApertureSize.ValueChanged += new System.EventHandler(this.numericApertureSize_ValueChanged);
            // 
            // lblApertureSize
            // 
            this.lblApertureSize.AutoSize = true;
            this.lblApertureSize.Location = new System.Drawing.Point(53, 52);
            this.lblApertureSize.Name = "lblApertureSize";
            this.lblApertureSize.Size = new System.Drawing.Size(73, 13);
            this.lblApertureSize.TabIndex = 0;
            this.lblApertureSize.Text = "Aperture Size:";
            // 
            // LaplacianEdge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 163);
            this.Controls.Add(this.laplacianEdgeParameters);
            this.Name = "LaplacianEdge";
            this.Text = "Laplacian Edge Parameters";
            this.laplacianEdgeParameters.ResumeLayout(false);
            this.laplacianEdgeParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericApertureSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox laplacianEdgeParameters;
        private System.Windows.Forms.NumericUpDown numericApertureSize;
        private System.Windows.Forms.Label lblApertureSize;
    }
}