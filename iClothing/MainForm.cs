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
        public MainForm()
        {
            InitializeComponent();
        }

        public void closeForm()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

        }

        public void showFrm(Form frm)
        {
            this.IsMdiContainer = true;
            frm.MdiParent = this;
            
            frm.Show();
            frm.Location = new Point(238, 40);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            CustomerOrder orderfrm = new CustomerOrder() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true } ;
            this.pnRight.Controls.Add(orderfrm);
            orderfrm.Show();
            //closeForm();
            //showFrm(new OrderForm());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {

        }
    }
}
