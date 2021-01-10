using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iClothing
{
    public partial class OrderManagement : UserControl
    {
        private int latestPanelBottom = 0;
        public OrderManagement()
        {
            InitializeComponent();
            rbNhap.Checked = true;
            panel2.Visible = false;

        }

        private void rbNhap_CheckedChanged(object sender, EventArgs e)
        {
            //rbXuat.Checked = false;
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void rbXuat_CheckedChanged(object sender, EventArgs e)
        {
            //rbNhap.Checked = false;
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQuantity.Text, "[^0-9]"))
            {
                txtQuantity.Text = txtQuantity.Text.Remove(txtQuantity.Text.Length - 1);
            }
        }

        private void txtQuantity1_KeyDown(object sender, KeyEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQuantity1.Text, "[^0-9]"))
            {
                txtQuantity1.Text = txtQuantity1.Text.Remove(txtQuantity1.Text.Length - 1);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        //private List<string> GetAllCustomer()
        //{

        //}

        void GetAllSupplier()
        {

        }

        void GetAllKyHieu()
        {

        }

        void GetAllType()
        {

        }
    }
}
