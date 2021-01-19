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
    public partial class QuanLyNhapXuat : UserControl
    {
        public QuanLyNhapXuat()
        {
            InitializeComponent();
            quanLyNhap1.Visible = false;
            rbNhap.Checked = true;
        }

        private void rbNhap_CheckedChanged(object sender, EventArgs e)
        {
            quanLyNhap1.Visible = true;
        }

        private void rbXuat_CheckedChanged(object sender, EventArgs e)
        {
            quanLyXuat1.Visible = true;
        }
    }
}
