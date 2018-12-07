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
            this.listViewAccount = new System.Windows.Forms.ListView();
            this.columnHeaderUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPassword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderScriptname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewAccount
            // 
            this.listViewAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderUsername,
            this.columnHeaderPassword,
            this.columnHeaderScriptname});
            this.listViewAccount.FullRowSelect = true;
            this.listViewAccount.GridLines = true;
            this.listViewAccount.Location = new System.Drawing.Point(0, 0);
            this.listViewAccount.MultiSelect = false;
            this.listViewAccount.Name = "listViewAccount";
            this.listViewAccount.Size = new System.Drawing.Size(566, 196);
            this.listViewAccount.TabIndex = 0;
            this.listViewAccount.UseCompatibleStateImageBehavior = false;
            this.listViewAccount.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderUsername
            // 
            this.columnHeaderUsername.Text = "Username";
            this.columnHeaderUsername.Width = 123;
            // 
            // columnHeaderPassword
            // 
            this.columnHeaderPassword.Text = "Password";
            this.columnHeaderPassword.Width = 154;
            // 
            // columnHeaderScriptname
            // 
            this.columnHeaderScriptname.Text = "Scriptname";
            this.columnHeaderScriptname.Width = 192;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(478, 202);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 202);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 233);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listViewAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Account";
            this.Text = "Account management";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewAccount;
        private System.Windows.Forms.ColumnHeader columnHeaderUsername;
        private System.Windows.Forms.ColumnHeader columnHeaderPassword;
        private System.Windows.Forms.ColumnHeader columnHeaderScriptname;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
    }
}