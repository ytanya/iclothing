using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace iClothing
{
    public partial class TransactionManagement1 : UserControl
    {
        DataTable dtMain = new DataTable();
        string conn = DBAccess.ConnectionString;
        public TransactionManagement1()
        {
            InitializeComponent();
        }

        private void TransactionManagement1_Load(object sender, EventArgs e)
        {
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "dd/MM/yyyy";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "dd/MM/yyyy";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fromDate = dtpFrom.Value.ToString("MM/dd/yyyy hh:mm tt");
            string toDate = dtpTo.Value.ToString("MM/dd/yyyy hh:mm tt");
            string query = "SELECT * FROM Product WHERE Ngaysua BETWEEN '" + fromDate + "' AND '" + toDate +"' Order by Ngaysua ;";
            using (SqlCeConnection connection = new SqlCeConnection(conn))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);

                    dvgTransaction.DataSource = dtMain;
                    lblTotalPage.Text = dtMain.Rows.Count.ToString();
                }
            }
        }
    }
}
