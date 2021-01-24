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
    public partial class DialogForm : Form
    {
        public DialogForm(string message, Color bgColor)
        {
            InitializeComponent();
            this.BackColor = bgColor;
            lblMessage.Text = message;
        }

        private void DialogForm_Load(object sender, EventArgs e)
        {
            Top = 70;
            Left = Screen.PrimaryScreen.Bounds.Width - Width - 110;
            timerClose.Start();
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
