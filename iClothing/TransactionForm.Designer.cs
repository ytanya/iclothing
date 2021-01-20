namespace iClothing
{
    partial class TransactionForm
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
            this.transactionManagement11 = new iClothing.TransactionManagement1();
            this.SuspendLayout();
            // 
            // transactionManagement11
            // 
            this.transactionManagement11.BackColor = System.Drawing.Color.White;
            this.transactionManagement11.Location = new System.Drawing.Point(-2, 1);
            this.transactionManagement11.Name = "transactionManagement11";
            this.transactionManagement11.Size = new System.Drawing.Size(870, 750);
            this.transactionManagement11.TabIndex = 0;
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 750);
            this.Controls.Add(this.transactionManagement11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransactionForm";
            this.Text = "TransactionForm";
            this.ResumeLayout(false);

        }

        #endregion

        private TransactionManagement1 transactionManagement11;
    }
}