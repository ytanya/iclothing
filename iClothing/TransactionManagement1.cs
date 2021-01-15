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
        private int currentPageNumber = 1;
        private int pageSize = 1;
        private int rowPerPage = 10;
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
            GetAllTrans();
            //PopulateDataTransaction(currentPageNumber, rowPerPage, dtMain);
        }

        private void pbFirst_Click(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            PopulateDataTransaction(currentPageNumber, rowPerPage, dtMain);
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber -= 1;
                PopulateDataTransaction(currentPageNumber, rowPerPage, dtMain);
            }
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                PopulateDataTransaction(currentPageNumber, rowPerPage, dtMain);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                PopulateDataTransaction(currentPageNumber, rowPerPage, dtMain);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void GetAllTrans()
        {

            string fromDate = dtpFrom.Value.ToString("MM/dd/yyyy 00:00 ") + "AM";
            string toDate = dtpTo.Value.AddDays(1).ToString("MM/dd/yyyy 00:00 ") + "AM";
            string query = "SELECT [Barcode],Type.[Ten] [Loại],[Transaction].[Mota] [Mô Tả],[Soluong] [Số Lượng],[Xong],[Nhap] [Nhập/Xuất],[Ngaytao] [Ngày Tạo],[Ngaysua] [Ngày Sửa] FROM [Transaction] join Type on Transaction.LoaiID = Type.LoaiID" +
                "WHERE Ngaysua BETWEEN '" + fromDate + "' AND '" + toDate + "' Order by Ngaysua ;";
            using (SqlCeConnection connection = new SqlCeConnection(conn))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);

                    dvgTransaction.DataSource = dtMain;
                    
                    
                }
            }

            int rowCount = dtMain.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            lblTotalPage.Text = "Tổng số:" + dtMain.Rows.Count.ToString();
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }
        private void PopulateDataTransaction(int currentPageNumber, int rowPerPage, DataTable dt)
        {
            int skipRecord = (currentPageNumber - 1) * rowPerPage;

                    if (dt.Rows.Count > 0)
                    {
                        dvgTransaction.DataSource = dt.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();
                dvgTransaction.Columns["Xong"].ReadOnly = true;
                dvgTransaction.Columns["Nhap"].ReadOnly = true;
            }
                    else
                    {
                        dvgTransaction.DataSource = dt;
                    }
                
           

        }

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPageSize.SelectedItem);
            currentPageNumber = 1;
            PopulateDataTransaction(currentPageNumber, rowPerPage, dtMain);
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }
    }
}
