using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iClothing
{

    public partial class OrderForm : Form
    {
        public string ConnectionString = DBAccess.ConnectionString;
        public OrderForm()
        {
            InitializeComponent();
        }

        private void rbNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNhap.Checked)
            {
                quanLyNhap1.Visible = true;
                quanLyXuat1.Visible = false;
            }
        }

        private void rbXuat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbXuat.Checked)
            {
                quanLyXuat1.Visible = true;
                quanLyNhap1.Visible = false;
            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            quanLyNhap1.Visible = true;
            quanLyXuat1.Visible = false;

            rbNhap.Checked = true;
        }

        private void quanLyXuat1_Load(object sender, EventArgs e)
        {

        }
    }
}
