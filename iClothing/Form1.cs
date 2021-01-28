using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iClothing
{
    public partial class Form1 : Form
    {
        int PW1, PW2, PW3, PW4;
        bool submenuHided1, submenuHided2, submenuHided3, minimenuHided, enableMini;
        public Form1()
        {
            InitializeComponent();
            PW1 = pnSystem.Height;
            PW2 = pnStuff.Height;
            PW3 = pnLeft.Width;
            PW4 = pnInOutStock.Height;
            submenuHided1 = false;
            submenuHided2 = false;
            submenuHided3 = false;
            minimenuHided = false;
            enableMini = false;
            
            pnLeft.Visible = false;
            pnLeft.Width = 54;
            pnSystem.Visible = false;
            pnStuff.Visible = false;
            btnMini.Visible = false;
            btnMini.Enabled = false;
            pnSystem.Height = 50;
            pnStuff.Height = 50;
            pnInOutStock.Height = 50;
            pnSystem.Top = pnStuff.Height+50;
            SidePanelLeft.Visible = false;
            btnSignout.Visible = false;
            //btnStaff.Visible = false;
            btnMinimize.Visible = false;
            btnMaximize.Visible = false;
            pnInOutStock.Visible = false;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btnSignout, "Đăng xuất");
            tt.SetToolTip(btnClose, "Đóng");
            this.CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnNormal.Visible = false;
            pnRight.Controls.Clear();
            LoginForm loginfrm = new LoginForm() { TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            loginfrm.FormBorderStyle = FormBorderStyle.None;
            this.pnRight.Controls.Add(loginfrm);
            loginfrm.Show();
            Login loginUC = loginfrm.login1;
            this.ActiveControl = loginUC.btnLogin;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            MinimizeMenu();
            pnRight.Controls.Clear();
            OrderForm orderfrm = new OrderForm() { Dock=DockStyle.Fill, TopLevel = false, AutoScaleMode=AutoScaleMode.None };
            orderfrm.FormBorderStyle = FormBorderStyle.None;
            orderfrm.AutoScroll = true;
            this.pnRight.Controls.Add(orderfrm);
            //orderfrm.Location = new Point(250, 0);
            orderfrm.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn tắt chương trình ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            pnRight.Controls.Clear();
            LoginForm loginfrm = new LoginForm() { Dock = DockStyle.Fill, TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            //stockfrm.AutoScroll = true;
            this.pnRight.Controls.Add(loginfrm);
            //orderfrm.Location = new Point(-20, 0);
            loginfrm.Show();
            btnSignout.Visible = false;
            pnLeft.Width = 54;
            pnSystem.Visible = false;
            pnStuff.Visible = false;
            btnMini.Visible = false;
            btnMini.Enabled = false;
            btnMaximize.Visible = false;
            btnMinimize.Visible = false;
            lblCurrentUser.Visible = false;
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            MinimizeMenu();
            pnRight.Controls.Clear();
            Stock stockfrm = new Stock() { Dock=DockStyle.Fill, TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            //stockfrm.AutoScroll = true;
            this.pnRight.Controls.Add(stockfrm);
            //orderfrm.Location = new Point(-20, 0);
            stockfrm.Show();
            this.pnRight.AutoScroll = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (submenuHided1)
            {
                pnSystem.Height = pnSystem.Height + 120;
                if (pnSystem.Height >= PW1)
                {
                    timer1.Stop();
                    submenuHided1 = true;
                    this.Refresh();
                }
            }
            else
            {
                pnSystem.Height = pnSystem.Height - 120;
                if (pnSystem.Height < 70)
                {
                    timer1.Stop();
                    submenuHided1 = false;
                    this.Refresh();
                }

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (submenuHided2)
            {
                pnStuff.Height = pnStuff.Height + 50;
                if (pnStuff.Height >= PW2)
                {
                    timer2.Stop();
                    submenuHided2 = true;
                    this.Refresh();
                }
            }
            else
            {
                pnStuff.Height = pnStuff.Height - 50;
                if (pnStuff.Height < 80)
                {
                    timer2.Stop();
                    submenuHided2 = false;
                    this.Refresh();
                }


            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            MinimizeMenu();
            pnRight.Controls.Clear();
            ProductForm productfrm = new ProductForm() { TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            this.pnRight.Controls.Add(productfrm);
            productfrm.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            MinimizeMenu();
            pnRight.Controls.Clear();
            CustomerForm customerfrm = new CustomerForm() { TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            this.pnRight.Controls.Add(customerfrm);
            customerfrm.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            MinimizeMenu();
            pnRight.Controls.Clear();
            SupplierForm supplierfrm = new SupplierForm() { TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            this.pnRight.Controls.Add(supplierfrm);
            supplierfrm.Show();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            MinimizeMenu();
            pnRight.Controls.Clear();
            TransactionForm transfrm = new TransactionForm() { TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            this.pnRight.Controls.Add(transfrm);
            transfrm.Show();
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            MinimizeMenu();
            pnRight.Controls.Clear();
            TypeForm typefrm = new TypeForm() { TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            this.pnRight.Controls.Add(typefrm);
            typefrm.Show();
        }

        private void btnArt_Click(object sender, EventArgs e)
        {
            MinimizeMenu();
            pnRight.Controls.Clear();
            ArtForm artfrm = new ArtForm() { TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            this.pnRight.Controls.Add(artfrm);
            artfrm.Show();
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            MinimizeMenu();
            pnRight.Controls.Clear();
            PaintForm paintfrm = new PaintForm() { TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            this.pnRight.Controls.Add(paintfrm);
            paintfrm.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            MinimizeMenu();
            pnRight.Controls.Clear();
            StaffForm stafffrm = new StaffForm() { TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            this.pnRight.Controls.Add(stafffrm);
            stafffrm.Show();
        }

        private void btnCusOrder_Click(object sender, EventArgs e)
        {
            MinimizeMenu();
            pnRight.Controls.Clear();
            CustomerOrder custOrderfrm = new CustomerOrder() { TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            this.pnRight.Controls.Add(custOrderfrm);
            custOrderfrm.Show();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            btnNormal.Visible = true;
            btnMaximize.Visible = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            btnNormal.Visible = false;
            btnMaximize.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void btnInOutStock_Click(object sender, EventArgs e)
        {
            SidePanelLeft.Height = btnInOutStock.Height;
            SidePanelLeft.Top = btnInOutStock.Top+ btnInOutStock.Top;
            submenuHided3 = !(submenuHided3);
            timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (submenuHided3)
            {
                pnInOutStock.Height = pnInOutStock.Height + 50;
                if (pnInOutStock.Height >= PW4)
                {
                    timer4.Stop();
                    submenuHided3 = true;
                    this.Refresh();
                }
            }
            else
            {
                pnInOutStock.Height = pnInOutStock.Height - 50;
                if (pnInOutStock.Height < 80)
                {
                    timer4.Stop();
                    submenuHided3 = false;
                    this.Refresh();
                }


            }
        }

        private void btnInOutProduct_Click(object sender, EventArgs e)
        {
            MinimizeMenu();
            pnRight.Controls.Clear();
            NhapXuatKhoForm inoutstockfrm = new NhapXuatKhoForm() { TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            this.pnRight.Controls.Add(inoutstockfrm);
            inoutstockfrm.Show();
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            SidePanelLeft.Height = btnSystem.Height;
            SidePanelLeft.Top = pnSystem.Top + btnSystem.Top;
            submenuHided1 = !(submenuHided1);
            timer1.Start();

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (minimenuHided &!enableMini)
            {
                pnLeft.Width = pnLeft.Width + 20;
                if (pnLeft.Width >= PW3)
                {
                    timer3.Stop();
                    minimenuHided = false;
                    this.Refresh();
                }
            }
            else
            {
                if (!enableMini)
                {
                    pnLeft.Width = pnLeft.Width - 20;
                    if (pnLeft.Width < 60)
                    {
                        timer3.Stop();
                        minimenuHided = true;
                        enableMini = true;
                        this.Refresh();
                    }

                }
            }
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            enableMini = false;
            btnMini.Enabled = false;
            timer3.Start();
        }

        private void btnStuff_Click(object sender, EventArgs e)
        {
            SidePanelLeft.Height = btnStuff.Height;
            SidePanelLeft.Top = pnStuff.Top + btnStuff.Top;
            submenuHided2 = !(submenuHided2);
            if (submenuHided2) pnSystem.Top = PW2+54 ;
            else pnSystem.Top = 54+54;
            timer2.Start();
            
        }

        public void MinimizeMenu()
        {
            btnMini.Enabled = true;
            timer3.Start();
        }
    }
}
