using System;
using System.Drawing;
using System.Windows.Forms;

namespace iClothing
{
    public partial class MainPage : Form
    {
        int PW1, PW2;
        bool submenuHided1, submenuHided2;
        public MainPage()
        {
            InitializeComponent();
            PW1 = pnSystem.Height;
            PW2 = pnStuff.Height;
            submenuHided1 = false;
            submenuHided2 = false;
            login2.BringToFront();
            pnSystem.Height = 54;
            pnStuff.Height = 54;
            pnSystem.Top = pnStuff.Height + 54;
            HideAllButton();
            SidePanelLeft.Visible = false;
            btnSignout.Visible = false;
            btnStaff.Visible = false;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btnSignout, "Đăng xuất");
            tt.SetToolTip(btnClose, "Đóng");

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

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            btnCustomer.Font = new Font(btnCustomer.Font.Name, btnCustomer.Font.Size, FontStyle.Bold);
            customerManagement11.Visible = true;
            customerManagement11.BringToFront();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            btnOrder.Font = new Font(btnOrder.Font.Name, btnOrder.Font.Size, FontStyle.Bold);
            orderManagement1.Visible = true;
            orderManagement1.BringToFront();
        }

        private void btnStuff_Click(object sender, EventArgs e)
        {
            SidePanelLeft.Height = btnStuff.Height;
            SidePanelLeft.Top = pnStuff.Top + btnStuff.Top;
            submenuHided2 = !(submenuHided2);
            if (submenuHided2) pnSystem.Top = PW2 + 54;
            else pnSystem.Top = 54 + 54;
            timer2.Start();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            btnProduct.Font = new Font(btnProduct.Font.Name, btnProduct.Font.Size, FontStyle.Bold);
            productManagement11.Visible = true;
            productManagement11.BringToFront();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            btnTransaction.Font = new Font(btnTransaction.Font.Name, btnTransaction.Font.Size, FontStyle.Bold);
            transactionManagement11.Visible = true;
            transactionManagement11.BringToFront();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            btnSupplier.Font = new Font(btnSupplier.Font.Name, btnSupplier.Font.Size, FontStyle.Bold);

        }

        private void btnType_Click(object sender, EventArgs e)
        {
            btnType.Font = new Font(btnType.Font.Name, btnType.Font.Size, FontStyle.Bold);
        }

        private void btnArt_Click(object sender, EventArgs e)
        {
            btnArt.Font = new Font(btnArt.Font.Name, btnArt.Font.Size, FontStyle.Bold);
            artManagement11.Visible = true;
            artManagement11.BringToFront();
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            ShowAllButton();
            btnPaint.Font = new Font(btnPaint.Font.Name, btnPaint.Font.Size, FontStyle.Bold);
            btnPaint.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            btnStaff.Font = new Font(btnStaff.Font.Name, btnStaff.Font.Size, FontStyle.Bold);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            btnStock.Font = new Font(btnStock.Font.Name, btnStock.Font.Size, FontStyle.Bold);

            stockManagement1.Visible = true;
            stockManagement1.BringToFront();
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            SidePanelLeft.Height = btnSystem.Height;
            SidePanelLeft.Top = pnSystem.Top + btnSystem.Top;
            submenuHided1 = !(submenuHided1);
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (submenuHided2)
            {
                pnStuff.Height = pnStuff.Height + 120;
                if (pnStuff.Height >= PW2)
                {
                    timer2.Stop();
                    submenuHided2 = true;
                    this.Refresh();
                }
            }
            else
            {
                pnStuff.Height = pnStuff.Height - 120;
                if (pnStuff.Height < 90)
                {
                    timer2.Stop();
                    submenuHided2 = false;
                    this.Refresh();
                }


            }
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
            login2.Visible = true;
            HideAllButton();
        }

        private void login2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserControl login = (this.Parent as MainPage).Controls["login2"] as UserControl;
                //login2.btn.Click += new EventHandler(login2);
            }
        }

        private void MainPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserControl login = (this.Parent as MainPage).Controls["login2"] as UserControl;
                //login2.btn.Click += new EventHandler(login2);
            }
        }

        private void HideAllButton()
        {
            customerManagement11.Visible = false;
            orderManagement1.Visible = false;
            //typeManagement1.Visible = false;
            //colorManagement1.Visible = false;
            stockManagement1.Visible = false;
            productManagement11.Visible = false;
            //staffManagement1.Visible = false;
            //supplierManagement1.Visible = false;
            artManagement11.Visible = false;
            transactionManagement11.Visible = false;
        }

        private void ShowAllButton()
        {
            //customerManagement1.Visible = true;
            //orderManagement1.Visible = true;
            //typeManagement1.Visible = true;
            //colorManagement1.Visible = true;
            //stockManagement1.Visible = true;
            //productManagment1.Visible = true;
            //staffManagement1.Visible = true;
            //supplierManagement1.Visible = true;
            //artManagement1.Visible = true;
            //transactionManagement1.Visible = true;
            //customerManagement1.BringToFront();
        }
    }
}
