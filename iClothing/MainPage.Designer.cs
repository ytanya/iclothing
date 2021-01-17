namespace iClothing
{
    partial class MainPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.pnMenu = new System.Windows.Forms.Panel();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSignout = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnArt = new System.Windows.Forms.Button();
            this.btnType = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnPaint = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.pnStuff = new System.Windows.Forms.Panel();
            this.btnStuff = new System.Windows.Forms.Button();
            this.pnSystem = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSystem = new System.Windows.Forms.Button();
            this.SidePanelLeft = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.transactionManagement11 = new iClothing.TransactionManagement1();
            this.stockManagement1 = new iClothing.StockManagement();
            this.artManagement11 = new iClothing.ArtManagement1();
            this.productManagement11 = new iClothing.ProductManagement1();
            this.orderManagement1 = new iClothing.OrderManagement();
            this.login2 = new iClothing.Login();
            this.customerManagement11 = new iClothing.CustomerManagement1();
            this.pnMenu.SuspendLayout();
            this.pnLeft.SuspendLayout();
            this.pnStuff.SuspendLayout();
            this.pnSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.pnMenu.Controls.Add(this.lblCurrentUser);
            this.pnMenu.Controls.Add(this.btnClose);
            this.pnMenu.Controls.Add(this.btnSignout);
            resources.ApplyResources(this.pnMenu, "pnMenu");
            this.pnMenu.Name = "pnMenu";
            // 
            // lblCurrentUser
            // 
            resources.ApplyResources(this.lblCurrentUser, "lblCurrentUser");
            this.lblCurrentUser.ForeColor = System.Drawing.Color.White;
            this.lblCurrentUser.Name = "lblCurrentUser";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSignout
            // 
            this.btnSignout.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSignout, "btnSignout");
            this.btnSignout.ForeColor = System.Drawing.Color.White;
            this.btnSignout.Name = "btnSignout";
            this.btnSignout.UseVisualStyleBackColor = true;
            this.btnSignout.Click += new System.EventHandler(this.btnSignout_Click);
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Name = "lblVersion";
            // 
            // btnStaff
            // 
            this.btnStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            resources.ApplyResources(this.btnStaff, "btnStaff");
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.ForeColor = System.Drawing.Color.White;
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnTransaction.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnTransaction, "btnTransaction");
            this.btnTransaction.ForeColor = System.Drawing.Color.White;
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.UseVisualStyleBackColor = false;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnStock.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnStock, "btnStock");
            this.btnStock.ForeColor = System.Drawing.Color.White;
            this.btnStock.Name = "btnStock";
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnCustomer, "btnCustomer");
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnArt
            // 
            this.btnArt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            resources.ApplyResources(this.btnArt, "btnArt");
            this.btnArt.FlatAppearance.BorderSize = 0;
            this.btnArt.ForeColor = System.Drawing.Color.White;
            this.btnArt.Name = "btnArt";
            this.btnArt.UseVisualStyleBackColor = false;
            this.btnArt.Click += new System.EventHandler(this.btnArt_Click);
            // 
            // btnType
            // 
            this.btnType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            resources.ApplyResources(this.btnType, "btnType");
            this.btnType.FlatAppearance.BorderSize = 0;
            this.btnType.ForeColor = System.Drawing.Color.White;
            this.btnType.Name = "btnType";
            this.btnType.UseVisualStyleBackColor = false;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSupplier, "btnSupplier");
            this.btnSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnProduct.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnProduct, "btnProduct");
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnPaint
            // 
            this.btnPaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            resources.ApplyResources(this.btnPaint, "btnPaint");
            this.btnPaint.FlatAppearance.BorderSize = 0;
            this.btnPaint.ForeColor = System.Drawing.Color.White;
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.UseVisualStyleBackColor = false;
            this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            this.btnOrder.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnOrder, "btnOrder");
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.pnLeft.Controls.Add(this.pnStuff);
            this.pnLeft.Controls.Add(this.pnSystem);
            this.pnLeft.Controls.Add(this.lblVersion);
            this.pnLeft.Controls.Add(this.SidePanelLeft);
            resources.ApplyResources(this.pnLeft, "pnLeft");
            this.pnLeft.Name = "pnLeft";
            // 
            // pnStuff
            // 
            this.pnStuff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.pnStuff.Controls.Add(this.btnStuff);
            this.pnStuff.Controls.Add(this.btnOrder);
            this.pnStuff.Controls.Add(this.btnStock);
            resources.ApplyResources(this.pnStuff, "pnStuff");
            this.pnStuff.Name = "pnStuff";
            // 
            // btnStuff
            // 
            this.btnStuff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.btnStuff.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnStuff, "btnStuff");
            this.btnStuff.ForeColor = System.Drawing.Color.White;
            this.btnStuff.Name = "btnStuff";
            this.btnStuff.UseVisualStyleBackColor = false;
            this.btnStuff.Click += new System.EventHandler(this.btnStuff_Click);
            // 
            // pnSystem
            // 
            this.pnSystem.Controls.Add(this.pictureBox6);
            this.pnSystem.Controls.Add(this.pictureBox5);
            this.pnSystem.Controls.Add(this.pictureBox4);
            this.pnSystem.Controls.Add(this.pictureBox3);
            this.pnSystem.Controls.Add(this.pictureBox2);
            this.pnSystem.Controls.Add(this.pictureBox1);
            this.pnSystem.Controls.Add(this.btnSystem);
            this.pnSystem.Controls.Add(this.btnCustomer);
            this.pnSystem.Controls.Add(this.btnProduct);
            this.pnSystem.Controls.Add(this.btnStaff);
            this.pnSystem.Controls.Add(this.btnTransaction);
            this.pnSystem.Controls.Add(this.btnSupplier);
            this.pnSystem.Controls.Add(this.btnType);
            this.pnSystem.Controls.Add(this.btnPaint);
            this.pnSystem.Controls.Add(this.btnArt);
            resources.ApplyResources(this.pnSystem, "pnSystem");
            this.pnSystem.Name = "pnSystem";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            resources.ApplyResources(this.pictureBox6, "pictureBox6");
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            resources.ApplyResources(this.pictureBox5, "pictureBox5");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(177)))), ((int)(((byte)(27)))));
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnSystem
            // 
            this.btnSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(156)))), ((int)(((byte)(29)))));
            this.btnSystem.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSystem, "btnSystem");
            this.btnSystem.ForeColor = System.Drawing.Color.White;
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.UseVisualStyleBackColor = false;
            this.btnSystem.Click += new System.EventHandler(this.btnSystem_Click);
            // 
            // SidePanelLeft
            // 
            this.SidePanelLeft.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.SidePanelLeft, "SidePanelLeft");
            this.SidePanelLeft.Name = "SidePanelLeft";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // transactionManagement11
            // 
            this.transactionManagement11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.transactionManagement11, "transactionManagement11");
            this.transactionManagement11.Name = "transactionManagement11";
            // 
            // stockManagement1
            // 
            this.stockManagement1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.stockManagement1, "stockManagement1");
            this.stockManagement1.Name = "stockManagement1";
            // 
            // artManagement11
            // 
            this.artManagement11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.artManagement11, "artManagement11");
            this.artManagement11.Name = "artManagement11";
            // 
            // productManagement11
            // 
            this.productManagement11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.productManagement11, "productManagement11");
            this.productManagement11.Name = "productManagement11";
            // 
            // orderManagement1
            // 
            this.orderManagement1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.orderManagement1, "orderManagement1");
            this.orderManagement1.Name = "orderManagement1";
            // 
            // login2
            // 
            this.login2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.login2, "login2");
            this.login2.Name = "login2";
            this.login2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.login2_KeyDown);
            // 
            // customerManagement11
            // 
            this.customerManagement11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.customerManagement11, "customerManagement11");
            this.customerManagement11.Name = "customerManagement11";
            // 
            // MainPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.customerManagement11);
            this.Controls.Add(this.transactionManagement11);
            this.Controls.Add(this.stockManagement1);
            this.Controls.Add(this.artManagement11);
            this.Controls.Add(this.productManagement11);
            this.Controls.Add(this.orderManagement1);
            this.Controls.Add(this.pnLeft);
            this.Controls.Add(this.pnMenu);
            this.Controls.Add(this.login2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainPage_KeyDown);
            this.pnMenu.ResumeLayout(false);
            this.pnMenu.PerformLayout();
            this.pnLeft.ResumeLayout(false);
            this.pnLeft.PerformLayout();
            this.pnStuff.ResumeLayout(false);
            this.pnSystem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnArt;
        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnPaint;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Panel SidePanelLeft;
        private System.Windows.Forms.Timer timer1;
        private Login login2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel pnSystem;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.Panel pnStuff;
        private System.Windows.Forms.Button btnStuff;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSignout;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private OrderManagement orderManagement1;
        private ProductManagement1 productManagement11;
        private ArtManagement1 artManagement11;
        private StockManagement stockManagement1;
        private TransactionManagement1 transactionManagement11;
        private CustomerManagement1 customerManagement11;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}