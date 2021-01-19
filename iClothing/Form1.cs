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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            OrderForm orderfrm = new OrderForm() { TopLevel = false, AutoScaleMode=AutoScaleMode.None };
            orderfrm.FormBorderStyle = FormBorderStyle.None;
            orderfrm.AutoScroll = true;
            this.panel1.Controls.Add(orderfrm);
            //orderfrm.Location = new Point(-20, 0);
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
            
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Stock stockfrm = new Stock() { TopLevel = false, AutoScaleMode = AutoScaleMode.None };
            //stockfrm.AutoScroll = true;
            this.panel1.Controls.Add(stockfrm);
            //orderfrm.Location = new Point(-20, 0);
            stockfrm.Show();
            this.panel1.AutoScroll = true;
        }
    }
}
