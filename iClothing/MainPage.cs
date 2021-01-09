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
            pnStuff.Top = pnSystem.Height + 54;
            //pnRight.Visible = false;
            HideAllButton();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (submenuHided1)
            {
                pnSystem.Height = pnSystem.Height + 100;
                if (pnSystem.Height >= PW1)
                {
                    timer1.Stop();
                    submenuHided1 = true;
                    this.Refresh();
                }
            }
            else
            {
                pnSystem.Height = pnSystem.Height - 100;
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
            colorManagement1.SendToBack();
            customerManagement1.BringToFront();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            btnOrder.Font = new Font(btnOrder.Font.Name, btnOrder.Font.Size, FontStyle.Bold);
            orderManagement1.BringToFront();
        }

        private void btnStuff_Click(object sender, EventArgs e)
        {
            SidePanelLeft.Height = btnStuff.Height;
            SidePanelLeft.Top = btnStuff.Top;
            submenuHided2 = !(submenuHided2);
            timer2.Start();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            btnProduct.Font = new Font(btnProduct.Font.Name, btnProduct.Font.Size, FontStyle.Bold);
            productManagment1.BringToFront();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            btnTransaction.Font = new Font(btnTransaction.Font.Name, btnTransaction.Font.Size, FontStyle.Bold);
            transactionManagement1.BringToFront();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            btnSupplier.Font = new Font(btnSupplier.Font.Name, btnSupplier.Font.Size, FontStyle.Bold);
            supplierManagement1.BringToFront();

        }

        private void btnType_Click(object sender, EventArgs e)
        {
            btnType.Font = new Font(btnType.Font.Name, btnType.Font.Size, FontStyle.Bold);
            typeManagement1.BringToFront();
        }

        private void btnArt_Click(object sender, EventArgs e)
        {
            btnArt.Font = new Font(btnArt.Font.Name, btnArt.Font.Size, FontStyle.Bold);
            artManagement1.BringToFront();

        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            ShowAllButton();
            btnPaint.Font = new Font(btnPaint.Font.Name, btnPaint.Font.Size, FontStyle.Bold);
            btnPaint.ForeColor = Color.FromArgb(255,128,0);
            colorManagement1.BringToFront();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            btnStaff.Font = new Font(btnStaff.Font.Name, btnStaff.Font.Size, FontStyle.Bold);
            staffManagement1.BringToFront();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            btnStock.Font = new Font(btnStock.Font.Name, btnStock.Font.Size, FontStyle.Bold);
            stockManagement1.BringToFront();
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            SidePanelLeft.Height = btnSystem.Height;
            SidePanelLeft.Top = btnSystem.Top;
            submenuHided1 = !(submenuHided1);
            if (submenuHided1) pnStuff.Top = PW1 + 54;
            else pnStuff.Top = 54 + 54;
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if (submenuHided2)
            {
                pnStuff.Height = pnStuff.Height + 100;
                if (pnStuff.Height >= PW2)
                {
                    timer2.Stop();
                    submenuHided2 = true;
                    this.Refresh();
                }
            }
            else
            {
                pnStuff.Height = pnStuff.Height - 100;
                if (pnStuff.Height < 70)
                {
                    timer2.Stop();
                    submenuHided2 = false;
                    this.Refresh();
                }


            }
        }

        private void HideAllButton()
        {
            //customerManagement1.Visible = false;
            //orderManagement1.Visible = false;
            //typeManagement1.Visible = false;
            colorManagement1.Visible = false;
            //stockManagement1.Visible = false;
            //productManagment1.Visible = false;
            //staffManagement1.Visible = false;
            //supplierManagement1.Visible = false;
            //artManagement1.Visible = false;
            //transactionManagement1.Visible = false;
        }

        private void ShowAllButton()
        {
            customerManagement1.Visible = true;
            //orderManagement1.Visible = true;
            //typeManagement1.Visible = true;
            colorManagement1.Visible = true;
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
