namespace iClothing
{
    partial class ProductForm
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
            this.productManagement11 = new iClothing.ProductManagement1();
            this.SuspendLayout();
            // 
            // productManagement11
            // 
            this.productManagement11.BackColor = System.Drawing.Color.White;
            this.productManagement11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productManagement11.Location = new System.Drawing.Point(2, 2);
            this.productManagement11.Margin = new System.Windows.Forms.Padding(4);
            this.productManagement11.Name = "productManagement11";
            this.productManagement11.Size = new System.Drawing.Size(1200, 730);
            this.productManagement11.TabIndex = 0;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 730);
            this.Controls.Add(this.productManagement11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductForm";
            this.Text = "Productcs";
            this.ResumeLayout(false);

        }

        #endregion

        private ProductManagement1 productManagement11;
    }
}