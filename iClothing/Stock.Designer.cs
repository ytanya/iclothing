
namespace iClothing
{
    partial class Stock
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
            this.stockManagement1 = new iClothing.StockManagement();
            this.SuspendLayout();
            // 
            // stockManagement1
            // 
            this.stockManagement1.BackColor = System.Drawing.Color.White;
            this.stockManagement1.Location = new System.Drawing.Point(39, 28);
            this.stockManagement1.Name = "stockManagement1";
            this.stockManagement1.Size = new System.Drawing.Size(870, 750);
            this.stockManagement1.TabIndex = 0;
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1126, 772);
            this.Controls.Add(this.stockManagement1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stock";
            this.Text = "Stock";
            this.ResumeLayout(false);

        }

        #endregion

        private StockManagement stockManagement1;
    }
}