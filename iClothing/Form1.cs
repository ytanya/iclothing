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
        int PW1, PW2, PW3;
        bool submenuHided1, submenuHided2, verticalMenuHided;
        public Form1()
        {
            InitializeComponent();
            PW1 = pnSystem.Height;
            PW2 = pnStuff.Height;
            PW3 = pnLeft.Width-5;
            submenuHided1 = false;
            submenuHided2 = false;
            verticalMenuHided = false;
            pnSystem.Height = 54;
            pnStuff.Height = 54;
            pnSystem.Top = pnStuff.Height + 54;
            SidePanelLeft.Visible = false;
            btnSignout.Visible = false;
            btnStaff.Visible = false;
            btnMini.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            btnMini.Visible = true;
            verticalMenuHided = true;
            timer3.Start();
            panel1.Controls.Clear();
            OrderForm orderfrm = new OrderForm() { TopLevel = false, AutoScaleMode=AutoScaleMode.None };
            orderfrm.FormBorderStyle = FormBorderStyle.None;
            orderfrm.AutoScroll = true;
            this.panel1.Controls.Add(orderfrm);
            //orderfrm.Location = new Point(250, 0);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (submenuHided1)
            {
                pnSystem.Height = pnSystem.Height + 120;
                if (pnSystem.Height >= PW1)
                {
                    timer1.Stop();
                    submenuHided1 = true;
                    this.Refresh();
                }
            }
            else
            {
                pnSystem.Height = pnSystem.Height - 120;
                if (pnSystem.Height < 70)
                {
                    timer1.Stop();
                    submenuHided1 = false;
                    this.Refresh();
                }

            }
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            btnMini.Visible = false;
            verticalMenuHided = false;
            timer3.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (submenuHided2)
            {
                pnStuff.Height = pnStuff.Height + 120;
                if (pnStuff.Height >= PW2)
                {
                    timer2.Stop();
                    submenuHided2 = true;
                    this.Refresh();
                }
            }
            else
            {
                pnStuff.Height = pnStuff.Height - 120;
                if (pnStuff.Height < 90)
                {
                    timer2.Stop();
                    submenuHided2 = false;
                    this.Refresh();
                }


            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (!verticalMenuHided)
            {
                pnLeft.Width = pnLeft.Width + 20;
                if (pnLeft.Width >= PW3)
                {
                    timer3.Stop();
                    verticalMenuHided = true;
                    this.Refresh();
                }
            }
            else
            {
                pnLeft.Width = pnLeft.Width - 20;
                if (pnLeft.Width < 60)
                {
                    timer3.Stop();
                    verticalMenuHided = false;
                    this.Refresh();
                }

            }
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            SidePanelLeft.Height = btnSystem.Height;
            SidePanelLeft.Top = pnSystem.Top + btnSystem.Top;
            submenuHided1 = !(submenuHided1);
            timer1.Start();

        }

        private void btnStuff_Click(object sender, EventArgs e)
        {
            SidePanelLeft.Height = btnStuff.Height;
            SidePanelLeft.Top = pnStuff.Top + btnStuff.Top;
            submenuHided2 = !(submenuHided2);
            if (submenuHided2) pnSystem.Top = PW2 + 54;
            else pnSystem.Top = 54 + 54;
            timer2.Start();
            
        }
    }
}
