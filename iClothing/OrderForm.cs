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
        public static string currentpath = System.IO.Directory.GetCurrentDirectory();
        public static string ConnectionString = "Data Source=" + currentpath + ConfigurationManager.AppSettings["datapath"] + "; Persist Security Info=False";
        public OrderForm()
        {
            InitializeComponent();
        }
    }
}
