namespace iClothing
{
    partial class ArtForm
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
            this.artManagement11 = new iClothing.ArtManagement1();
            this.SuspendLayout();
            // 
            // artManagement11
            // 
            this.artManagement11.BackColor = System.Drawing.Color.White;
            this.artManagement11.Location = new System.Drawing.Point(-1, -1);
            this.artManagement11.Name = "artManagement11";
            this.artManagement11.Size = new System.Drawing.Size(870, 750);
            this.artManagement11.TabIndex = 0;
            // 
            // ArtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 750);
            this.Controls.Add(this.artManagement11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ArtForm";
            this.Text = "ArtForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ArtManagement1 artManagement11;
    }
}