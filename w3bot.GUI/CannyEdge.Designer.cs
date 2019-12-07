namespace w3bot.GUI
{
    partial class CannyEdge
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
            this.cannyEdgeParameters = new System.Windows.Forms.GroupBox();
            this.numericThresholdLink = new System.Windows.Forms.NumericUpDown();
            this.numericThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblThresholdLink = new System.Windows.Forms.Label();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.cannyEdgeParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericThresholdLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // cannyEdgeParameters
            // 
            this.cannyEdgeParameters.Controls.Add(this.numericThresholdLink);
            this.cannyEdgeParameters.Controls.Add(this.numericThreshold);
            this.cannyEdgeParameters.Controls.Add(this.lblThresholdLink);
            this.cannyEdgeParameters.Controls.Add(this.lblThreshold);
            this.cannyEdgeParameters.Location = new System.Drawing.Point(12, 12);
            this.cannyEdgeParameters.Name = "cannyEdgeParameters";
            this.cannyEdgeParameters.Size = new System.Drawing.Size(308, 130);
            this.cannyEdgeParameters.TabIndex = 0;
            this.cannyEdgeParameters.TabStop = false;
            this.cannyEdgeParameters.Text = "Canny";
            // 
            // numericThresholdLink
            // 
            this.numericThresholdLink.Location = new System.Drawing.Point(167, 63);
            this.numericThresholdLink.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericThresholdLink.Name = "numericThresholdLink";
            this.numericThresholdLink.Size = new System.Drawing.Size(80, 20);
            this.numericThresholdLink.TabIndex = 3;
            this.numericThresholdLink.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericThresholdLink.ValueChanged += new System.EventHandler(this.numericThresholdLink_ValueChanged);
            // 
            // numericThreshold
            // 
            this.numericThreshold.Location = new System.Drawing.Point(167, 30);
            this.numericThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericThreshold.Name = "numericThreshold";
            this.numericThreshold.Size = new System.Drawing.Size(80, 20);
            this.numericThreshold.TabIndex = 2;
            this.numericThreshold.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericThreshold.ValueChanged += new System.EventHandler(this.numericThreshold_ValueChanged);
            // 
            // lblThresholdLink
            // 
            this.lblThresholdLink.AutoSize = true;
            this.lblThresholdLink.Location = new System.Drawing.Point(44, 65);
            this.lblThresholdLink.Name = "lblThresholdLink";
            this.lblThresholdLink.Size = new System.Drawing.Size(80, 13);
            this.lblThresholdLink.TabIndex = 1;
            this.lblThresholdLink.Text = "Threshold Link:";
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(67, 30);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(57, 13);
            this.lblThreshold.TabIndex = 0;
            this.lblThreshold.Text = "Threshold:";
            // 
            // CannyEdge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 163);
            this.Controls.Add(this.cannyEdgeParameters);
            this.Name = "CannyEdge";
            this.Text = "Canny Edge Parameters";
            this.cannyEdgeParameters.ResumeLayout(false);
            this.cannyEdgeParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericThresholdLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox cannyEdgeParameters;
        private System.Windows.Forms.Label lblThresholdLink;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.NumericUpDown numericThresholdLink;
        private System.Windows.Forms.NumericUpDown numericThreshold;
    }
}