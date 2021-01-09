namespace iClothing
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnArt = new System.Windows.Forms.Button();
            this.btnType = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnPaint = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSignout = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.customerManagement1 = new iClothing.CustomerManagement();
            this.artManagement1 = new iClothing.ArtManagement();
            this.colorManagement1 = new iClothing.ColorManagement();
            this.orderManagement1 = new iClothing.OrderManagement();
            this.productManagment1 = new iClothing.ProductManagment();
            this.staffManagement1 = new iClothing.StaffManagement();
            this.stockManagement1 = new iClothing.StockManagement();
            this.supplierManagement1 = new iClothing.SupplierManagement();
            this.typeManagement1 = new iClothing.TypeManagement();
            this.transactionManagement1 = new iClothing.TransactionManagement();
            this.login1 = new iClothing.Login();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.btnStaff);
            this.panel1.Controls.Add(this.btnTransaction);
            this.panel1.Controls.Add(this.btnStock);
            this.panel1.Controls.Add(this.SidePanel);
            this.panel1.Controls.Add(this.btnCustomer);
            this.panel1.Controls.Add(this.btnArt);
            this.panel1.Controls.Add(this.btnType);
            this.panel1.Controls.Add(this.btnSupplier);
            this.panel1.Controls.Add(this.btnProduct);
            this.panel1.Controls.Add(this.btnPaint);
            this.panel1.Controls.Add(this.btnOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 583);
            this.panel1.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(3, 557);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(48, 18);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = "v1.0.0";
            // 
            // btnStaff
            // 
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.ForeColor = System.Drawing.Color.White;
            this.btnStaff.Image = ((System.Drawing.Image)(resources.GetObject("btnStaff.Image")));
            this.btnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.Location = new System.Drawing.Point(12, 496);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(197, 54);
            this.btnStaff.TabIndex = 7;
            this.btnStaff.Text = "       Nhân viên";
            this.btnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.FlatAppearance.BorderSize = 0;
            this.btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransaction.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransaction.ForeColor = System.Drawing.Color.White;
            this.btnTransaction.Image = ((System.Drawing.Image)(resources.GetObject("btnTransaction.Image")));
            this.btnTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransaction.Location = new System.Drawing.Point(12, 226);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(197, 54);
            this.btnTransaction.TabIndex = 6;
            this.btnTransaction.Text = "       Giao Dịch";
            this.btnTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btnStock
            // 
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.Color.White;
            this.btnStock.Image = ((System.Drawing.Image)(resources.GetObject("btnStock.Image")));
            this.btnStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.Location = new System.Drawing.Point(12, 172);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(197, 54);
            this.btnStock.TabIndex = 5;
            this.btnStock.Text = "       Tồn Kho";
            this.btnStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.White;
            this.SidePanel.Location = new System.Drawing.Point(1, 12);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(10, 54);
            this.SidePanel.TabIndex = 4;
            // 
            // btnCustomer
            // 
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.Location = new System.Drawing.Point(12, 10);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(197, 54);
            this.btnCustomer.TabIndex = 4;
            this.btnCustomer.Text = "       Khách Hàng";
            this.btnCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnArt
            // 
            this.btnArt.FlatAppearance.BorderSize = 0;
            this.btnArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArt.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArt.ForeColor = System.Drawing.Color.White;
            this.btnArt.Image = ((System.Drawing.Image)(resources.GetObject("btnArt.Image")));
            this.btnArt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArt.Location = new System.Drawing.Point(12, 388);
            this.btnArt.Name = "btnArt";
            this.btnArt.Size = new System.Drawing.Size(197, 54);
            this.btnArt.TabIndex = 4;
            this.btnArt.Text = "       Họa Tiết";
            this.btnArt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnArt.UseVisualStyleBackColor = true;
            this.btnArt.Click += new System.EventHandler(this.btnArt_Click);
            // 
            // btnType
            // 
            this.btnType.FlatAppearance.BorderSize = 0;
            this.btnType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnType.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnType.ForeColor = System.Drawing.Color.White;
            this.btnType.Image = ((System.Drawing.Image)(resources.GetObject("btnType.Image")));
            this.btnType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnType.Location = new System.Drawing.Point(12, 334);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(197, 54);
            this.btnType.TabIndex = 4;
            this.btnType.Text = "       Loại Sản Phẩm";
            this.btnType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnType.UseVisualStyleBackColor = true;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnSupplier.Image")));
            this.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplier.Location = new System.Drawing.Point(10, 280);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(207, 54);
            this.btnSupplier.TabIndex = 4;
            this.btnSupplier.Text = "       Nhà Cung Ứng";
            this.btnSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.Image")));
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.Location = new System.Drawing.Point(12, 118);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(197, 54);
            this.btnProduct.TabIndex = 4;
            this.btnProduct.Text = "       Sản Phẩm";
            this.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnPaint
            // 
            this.btnPaint.FlatAppearance.BorderSize = 0;
            this.btnPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaint.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaint.ForeColor = System.Drawing.Color.White;
            this.btnPaint.Image = ((System.Drawing.Image)(resources.GetObject("btnPaint.Image")));
            this.btnPaint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaint.Location = new System.Drawing.Point(12, 442);
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Size = new System.Drawing.Size(197, 54);
            this.btnPaint.TabIndex = 4;
            this.btnPaint.Text = "       Màu Sơn";
            this.btnPaint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPaint.UseVisualStyleBackColor = true;
            this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.Image")));
            this.btnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.Location = new System.Drawing.Point(12, 64);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(197, 54);
            this.btnOrder.TabIndex = 4;
            this.btnOrder.Text = "       Đơn Hàng";
            this.btnOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(209, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(820, 10);
            this.panel2.TabIndex = 1;
            // 
            // btnSignout
            // 
            this.btnSignout.FlatAppearance.BorderSize = 0;
            this.btnSignout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignout.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignout.ForeColor = System.Drawing.Color.White;
            this.btnSignout.Image = ((System.Drawing.Image)(resources.GetObject("btnSignout.Image")));
            this.btnSignout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSignout.Location = new System.Drawing.Point(928, 19);
            this.btnSignout.Name = "btnSignout";
            this.btnSignout.Size = new System.Drawing.Size(32, 35);
            this.btnSignout.TabIndex = 4;
            this.btnSignout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSignout.UseVisualStyleBackColor = true;
            this.btnSignout.Click += new System.EventHandler(this.btnSignout_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(977, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 35);
            this.btnClose.TabIndex = 4;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Location = new System.Drawing.Point(840, 36);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(0, 18);
            this.lblCurrentUser.TabIndex = 8;
            // 
            // customerManagement1
            // 
            this.customerManagement1.BackColor = System.Drawing.Color.White;
            this.customerManagement1.Location = new System.Drawing.Point(209, 47);
            this.customerManagement1.Name = "customerManagement1";
            this.customerManagement1.Size = new System.Drawing.Size(805, 423);
            this.customerManagement1.TabIndex = 5;
            // 
            // artManagement1
            // 
            this.artManagement1.BackColor = System.Drawing.Color.White;
            this.artManagement1.Location = new System.Drawing.Point(209, 47);
            this.artManagement1.Name = "artManagement1";
            this.artManagement1.Size = new System.Drawing.Size(817, 443);
            this.artManagement1.TabIndex = 9;
            // 
            // colorManagement1
            // 
            this.colorManagement1.BackColor = System.Drawing.Color.White;
            this.colorManagement1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorManagement1.ForeColor = System.Drawing.Color.Orange;
            this.colorManagement1.Location = new System.Drawing.Point(209, 47);
            this.colorManagement1.Name = "colorManagement1";
            this.colorManagement1.Size = new System.Drawing.Size(813, 643);
            this.colorManagement1.TabIndex = 10;
            // 
            // orderManagement1
            // 
            this.orderManagement1.Location = new System.Drawing.Point(209, 47);
            this.orderManagement1.Name = "orderManagement1";
            this.orderManagement1.Size = new System.Drawing.Size(817, 443);
            this.orderManagement1.TabIndex = 11;
            // 
            // productManagment1
            // 
            this.productManagment1.BackColor = System.Drawing.Color.White;
            this.productManagment1.Location = new System.Drawing.Point(209, 47);
            this.productManagment1.Name = "productManagment1";
            this.productManagment1.Size = new System.Drawing.Size(817, 443);
            this.productManagment1.TabIndex = 12;
            // 
            // staffManagement1
            // 
            this.staffManagement1.BackColor = System.Drawing.Color.White;
            this.staffManagement1.Location = new System.Drawing.Point(209, 47);
            this.staffManagement1.Name = "staffManagement1";
            this.staffManagement1.Size = new System.Drawing.Size(817, 443);
            this.staffManagement1.TabIndex = 13;
            // 
            // stockManagement1
            // 
            this.stockManagement1.BackColor = System.Drawing.Color.White;
            this.stockManagement1.Location = new System.Drawing.Point(209, 47);
            this.stockManagement1.Name = "stockManagement1";
            this.stockManagement1.Size = new System.Drawing.Size(817, 443);
            this.stockManagement1.TabIndex = 14;
            // 
            // supplierManagement1
            // 
            this.supplierManagement1.BackColor = System.Drawing.Color.White;
            this.supplierManagement1.Location = new System.Drawing.Point(209, 47);
            this.supplierManagement1.Name = "supplierManagement1";
            this.supplierManagement1.Size = new System.Drawing.Size(817, 443);
            this.supplierManagement1.TabIndex = 15;
            // 
            // typeManagement1
            // 
            this.typeManagement1.BackColor = System.Drawing.Color.White;
            this.typeManagement1.Location = new System.Drawing.Point(209, 47);
            this.typeManagement1.Name = "typeManagement1";
            this.typeManagement1.Size = new System.Drawing.Size(819, 543);
            this.typeManagement1.TabIndex = 16;
            // 
            // transactionManagement1
            // 
            this.transactionManagement1.BackColor = System.Drawing.Color.White;
            this.transactionManagement1.Location = new System.Drawing.Point(209, 47);
            this.transactionManagement1.Name = "transactionManagement1";
            this.transactionManagement1.Size = new System.Drawing.Size(817, 443);
            this.transactionManagement1.TabIndex = 4;
            // 
            // login1
            // 
            this.login1.BackColor = System.Drawing.Color.White;
            this.login1.Location = new System.Drawing.Point(0, -60);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(1030, 685);
            this.login1.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1029, 583);
            this.Controls.Add(this.typeManagement1);
            this.Controls.Add(this.supplierManagement1);
            this.Controls.Add(this.stockManagement1);
            this.Controls.Add(this.staffManagement1);
            this.Controls.Add(this.productManagment1);
            this.Controls.Add(this.orderManagement1);
            this.Controls.Add(this.colorManagement1);
            this.Controls.Add(this.artManagement1);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.customerManagement1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSignout);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.login1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPaint;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnArt;
        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnSignout;
        private System.Windows.Forms.Button btnClose;
        private CustomerManagement customerManagement1;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblVersion;
        private ArtManagement artManagement1;
        private ColorManagement colorManagement1;
        private OrderManagement orderManagement1;
        private ProductManagment productManagment1;
        private StaffManagement staffManagement1;
        private StockManagement stockManagement1;
        private SupplierManagement supplierManagement1;
        private TypeManagement typeManagement1;
        private TransactionManagement transactionManagement1;
        private Login login1;
    }
}

