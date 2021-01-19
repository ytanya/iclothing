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
            Form2 orderfrm = new Form2() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(orderfrm);
            orderfrm.Show();
        }
    }
}
