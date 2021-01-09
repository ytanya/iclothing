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
    public partial class MainForm : Form
    {
        private DataTable dt = new DataTable();
        private DataTable dtnew = new DataTable();
        public MainForm()
        {
            InitializeComponent();
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btnSignout, "Đăng xuất");
            tt.SetToolTip(btnClose, "Đóng");                   
            //HideAllButton();
            //colorManagement1.BringToFront();
            //login1.BringToFront();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnOrder.Height;
            SidePanel.Top = btnOrder.Top;
            orderManagement1.BringToFront();
            if (DBAccess.IsServerConnected())
            {

            }
            else
            {

            }
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnPaint.Height;
            SidePanel.Top = btnPaint.Top;
            colorManagement1.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn tắt chương trình ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }                       
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCustomer.Height;
            SidePanel.Top = btnCustomer.Top;
            ShowAllButton();
            //lblCurrentUser.Text = txtUsername.Text;
        }
        private void HideAllButton()
        {
            btnCustomer.Visible = false;
            btnOrder.Visible = false;
            btnProduct.Visible = false;
            btnSupplier.Visible = false;
            btnType.Visible = false;
            btnArt.Visible = false;
            btnPaint.Visible = false;
            btnStock.Visible = false;
            btnTransaction.Visible = false;
            btnStaff.Visible = false;
            SidePanel.Visible = false;
            customerManagement1.Visible = false;
            orderManagement1.Visible = false;
            typeManagement1.Visible = false;
            //colorManagement1.Visible = false;
            stockManagement1.Visible = false;
            productManagment1.Visible = false;
            staffManagement1.Visible = false;
            supplierManagement1.Visible = false;
            artManagement1.Visible = false;
            transactionManagement1.Visible = false;
        }
        private void ShowAllButton()
        {
            btnCustomer.Visible = true;
            btnOrder.Visible = true;
            btnProduct.Visible = true;
            btnSupplier.Visible = true;
            btnType.Visible = true;
            btnArt.Visible = true;
            btnPaint.Visible = true;
            btnStock.Visible = true;
            btnTransaction.Visible = true;
            btnStaff.Visible = true;
            SidePanel.Visible = true;
            customerManagement1.Visible = true;
            orderManagement1.Visible = true;
            typeManagement1.Visible = true;
            colorManagement1.Visible = true;
            stockManagement1.Visible = true;
            productManagment1.Visible = true;
            staffManagement1.Visible = true;
            supplierManagement1.Visible = true;
            artManagement1.Visible = true;
            transactionManagement1.Visible = true;
            customerManagement1.BringToFront();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCustomer.Height;
            SidePanel.Top = btnCustomer.Top;
            customerManagement1.BringToFront();
            if (DBAccess.IsServerConnected())
            {
                string query = "Select `products`.`id`,`name`,`description`,`expiration_date`, `manufacturer`, `pricemanagement`.`price` from `products` join `pricemanagement` on `products`.`id` = `pricemanagement`.`productid`";
                dt = new DataTable();
                dtnew = new DataTable();
                dtnew = DBAccess.FillDataTable(query, dt);
            }
            else
            {

            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnProduct.Height;
            SidePanel.Top = btnProduct.Top;
            productManagment1.BringToFront();
            if (DBAccess.IsServerConnected())
            {
                string query = "Select `products`.`id`,`name`,`description`,`expiration_date`, `manufacturer`, `pricemanagement`.`price` from `products` join `pricemanagement` on `products`.`id` = `pricemanagement`.`productid`";
                dt = new DataTable();
                dtnew = new DataTable();
                dtnew = DBAccess.FillDataTable(query, dt);
            }
            else
            {

            }
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnSupplier.Height;
            SidePanel.Top = btnSupplier.Top;
            supplierManagement1.BringToFront();
            if (DBAccess.IsServerConnected())
            {
                string query = "Select `products`.`id`,`name`,`description`,`expiration_date`, `manufacturer`, `pricemanagement`.`price` from `products` join `pricemanagement` on `products`.`id` = `pricemanagement`.`productid`";
                dt = new DataTable();
                dtnew = new DataTable();
                dtnew = DBAccess.FillDataTable(query, dt);
            }
            else
            {

            }
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnType.Height;
            SidePanel.Top = btnType.Top;
            typeManagement1.BringToFront();
            if (DBAccess.IsServerConnected())
            {
                string query = "Select `products`.`id`,`name`,`description`,`expiration_date`, `manufacturer`, `pricemanagement`.`price` from `products` join `pricemanagement` on `products`.`id` = `pricemanagement`.`productid`";
                dt = new DataTable();
                dtnew = new DataTable();
                dtnew = DBAccess.FillDataTable(query, dt);
            }
            else
            {

            }
        }

        private void btnArt_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnArt.Height;
            SidePanel.Top = btnArt.Top;
            artManagement1.BringToFront();
            if (DBAccess.IsServerConnected())
            {
                string query = "Select `products`.`id`,`name`,`description`,`expiration_date`, `manufacturer`, `pricemanagement`.`price` from `products` join `pricemanagement` on `products`.`id` = `pricemanagement`.`productid`";
                dt = new DataTable();
                dtnew = new DataTable();
                dtnew = DBAccess.FillDataTable(query, dt);
            }
            else
            {

            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnStock.Height;
            SidePanel.Top = btnStock.Top;
            stockManagement1.BringToFront();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnTransaction.Height;
            SidePanel.Top = btnTransaction.Top;
            transactionManagement1.BringToFront();
            if (DBAccess.IsServerConnected())
            {
                string query = "Select `products`.`id`,`name`,`description`,`expiration_date`, `manufacturer`, `pricemanagement`.`price` from `products` join `pricemanagement` on `products`.`id` = `pricemanagement`.`productid`";
                dt = new DataTable();
                dtnew = new DataTable();
                dtnew = DBAccess.FillDataTable(query, dt);
            }
            else
            {

            }
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnStaff.Height;
            SidePanel.Top = btnStaff.Top;
            staffManagement1.BringToFront();
            if (DBAccess.IsServerConnected())
            {
                string query = "Select `products`.`id`,`name`,`description`,`expiration_date`, `manufacturer`, `pricemanagement`.`price` from `products` join `pricemanagement` on `products`.`id` = `pricemanagement`.`productid`";
                dt = new DataTable();
                dtnew = new DataTable();
                dtnew = DBAccess.FillDataTable(query, dt);
            }
            else
            {

            }
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn đăng xuất? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                HideAllButton();
            }                        
        }

    }
}
