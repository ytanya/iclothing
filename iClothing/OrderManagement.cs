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
        public OrderManagement()
        {
            InitializeComponent();
            rbNhap.Checked = true;
        }

        private void rbNhap_CheckedChanged(object sender, EventArgs e)
        {
            rbXuat.Checked = false;
        }

        private void rbXuat_CheckedChanged(object sender, EventArgs e)
        {
            rbNhap.Checked = false;
        }
    }
}
