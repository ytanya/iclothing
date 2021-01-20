namespace iClothing
{
    partial class PaintForm
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
            this.paintManagement1 = new iClothing.PaintManagement();
            this.SuspendLayout();
            // 
            // paintManagement1
            // 
            this.paintManagement1.BackColor = System.Drawing.Color.White;
            this.paintManagement1.Location = new System.Drawing.Point(-2, 1);
            this.paintManagement1.Name = "paintManagement1";
            this.paintManagement1.Size = new System.Drawing.Size(870, 750);
            this.paintManagement1.TabIndex = 0;
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 750);
            this.Controls.Add(this.paintManagement1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaintForm";
            this.Text = "PaintForm";
            this.ResumeLayout(false);

        }

        #endregion

        private PaintManagement paintManagement1;
    }
}