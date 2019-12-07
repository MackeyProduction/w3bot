namespace w3bot.GUI
{
    partial class SobelEdge
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
            this.sobelEdgeParameters = new System.Windows.Forms.GroupBox();
            this.numericApertureSize = new System.Windows.Forms.NumericUpDown();
            this.lblApertureSize = new System.Windows.Forms.Label();
            this.numericYorder = new System.Windows.Forms.NumericUpDown();
            this.numericXorder = new System.Windows.Forms.NumericUpDown();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.sobelEdgeParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericApertureSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericYorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericXorder)).BeginInit();
            this.SuspendLayout();
            // 
            // sobelEdgeParameters
            // 
            this.sobelEdgeParameters.Controls.Add(this.numericApertureSize);
            this.sobelEdgeParameters.Controls.Add(this.lblApertureSize);
            this.sobelEdgeParameters.Controls.Add(this.numericYorder);
            this.sobelEdgeParameters.Controls.Add(this.numericXorder);
            this.sobelEdgeParameters.Controls.Add(this.lblY);
            this.sobelEdgeParameters.Controls.Add(this.lblX);
            this.sobelEdgeParameters.Location = new System.Drawing.Point(16, 16);
            this.sobelEdgeParameters.Name = "sobelEdgeParameters";
            this.sobelEdgeParameters.Size = new System.Drawing.Size(308, 130);
            this.sobelEdgeParameters.TabIndex = 1;
            this.sobelEdgeParameters.TabStop = false;
            this.sobelEdgeParameters.Text = "Sobel";
            // 
            // numericApertureSize
            // 
            this.numericApertureSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericApertureSize.Location = new System.Drawing.Point(167, 84);
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
            this.numericApertureSize.TabIndex = 5;
            this.numericApertureSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericApertureSize.ValueChanged += new System.EventHandler(this.numericApertureSize_ValueChanged);
            // 
            // lblApertureSize
            // 
            this.lblApertureSize.AutoSize = true;
            this.lblApertureSize.Location = new System.Drawing.Point(44, 86);
            this.lblApertureSize.Name = "lblApertureSize";
            this.lblApertureSize.Size = new System.Drawing.Size(73, 13);
            this.lblApertureSize.TabIndex = 4;
            this.lblApertureSize.Text = "Aperture Size:";
            // 
            // numericYorder
            // 
            this.numericYorder.Location = new System.Drawing.Point(167, 56);
            this.numericYorder.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericYorder.Name = "numericYorder";
            this.numericYorder.Size = new System.Drawing.Size(80, 20);
            this.numericYorder.TabIndex = 3;
            this.numericYorder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericYorder.ValueChanged += new System.EventHandler(this.numericYorder_ValueChanged);
            // 
            // numericXorder
            // 
            this.numericXorder.Location = new System.Drawing.Point(167, 30);
            this.numericXorder.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericXorder.Name = "numericXorder";
            this.numericXorder.Size = new System.Drawing.Size(80, 20);
            this.numericXorder.TabIndex = 2;
            this.numericXorder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericXorder.ValueChanged += new System.EventHandler(this.numericXorder_ValueChanged);
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(100, 58);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 1;
            this.lblY.Text = "Y:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(100, 32);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 0;
            this.lblX.Text = "X:";
            // 
            // SobelEdge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 163);
            this.Controls.Add(this.sobelEdgeParameters);
            this.Name = "SobelEdge";
            this.Text = "Sobel Edge Parameters";
            this.sobelEdgeParameters.ResumeLayout(false);
            this.sobelEdgeParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericApertureSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericYorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericXorder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox sobelEdgeParameters;
        private System.Windows.Forms.NumericUpDown numericYorder;
        private System.Windows.Forms.NumericUpDown numericXorder;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.NumericUpDown numericApertureSize;
        private System.Windows.Forms.Label lblApertureSize;
    }
}