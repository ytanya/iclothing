﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace iClothing
{
    public partial class QuanLyNhapXuat : UserControl
    {
        public static string currentpath = System.IO.Directory.GetCurrentDirectory();
        public static string ConnectionString = "Data Source=" + currentpath + ConfigurationManager.AppSettings["datapath"] + "; Persist Security Info=False";
        public QuanLyNhapXuat()
        {
            InitializeComponent();
            quanLyNhap1.dgvOrder.ScrollBars = ScrollBars.Both;
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

        private void QuanLyNhapXuat_Load(object sender, EventArgs e)
        {
            quanLyNhap1.Visible = true;
            quanLyXuat1.Visible = false;

            rbNhap.Checked = true;
        }
    }
}
