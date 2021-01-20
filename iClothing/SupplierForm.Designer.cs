namespace iClothing
{
    partial class SupplierForm
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
            this.supplierManagement1 = new iClothing.SupplierManagement();
            this.SuspendLayout();
            // 
            // supplierManagement1
            // 
            this.supplierManagement1.BackColor = System.Drawing.Color.White;
            this.supplierManagement1.Location = new System.Drawing.Point(1, 1);
            this.supplierManagement1.Name = "supplierManagement1";
            this.supplierManagement1.Size = new System.Drawing.Size(870, 750);
            this.supplierManagement1.TabIndex = 0;
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 750);
            this.Controls.Add(this.supplierManagement1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SupplierForm";
            this.Text = "SupplierForm";
            this.ResumeLayout(false);

        }

        #endregion

        private SupplierManagement supplierManagement1;
    }
}