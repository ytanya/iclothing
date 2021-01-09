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
    public partial class TransactionManagement : UserControl
    {
        private DataTable dt = new DataTable();
        private DataTable dtnew = new DataTable();
        private DataTable OrignalADGVdt = null;
        private int currentPageNumber = 1;
        private int pageSize = 1;
        private int rowPerPage = 10;
        private string currentOrderByItem = "TransID";
        public TransactionManagement()
        {
            InitializeComponent();
        }

        private void TransactionManagement_Load(object sender, EventArgs e)
        {
            if (DBAccess.IsServerConnected())
            {
                PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
            }
            else
            {
                //string query = "Select `TransID,`Ten`.`MieuTa`,`NgayTao`,`NgaySua` from `Color`";
            }
        }
   

        private void pbFirst_Click(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            currentPageNumber -= 1;
            PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            currentPageNumber += 1;
            PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            currentPageNumber = pageSize;
            PopulateData(currentPageNumber, rowPerPage, currentOrderByItem);
        }



        private void PopulateData(int currentPageNumber, int rowPerPage, string orderbyItem)
        {
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = currentPageNumber * rowPerPage;
            string query = "SELECT ARTID, Ten, Mota, Anh, Ngaytao, Ngaysua FROM Art Order by " + orderbyItem + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            dt = new DataTable();
            dtnew = new DataTable();
            dtnew = DBAccess.FillDataTable(query, dt);

            dvgArt.AutoGenerateColumns = false;
            dvgArt.DataSource = dtnew;
            int rowCount = dtnew.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            lblTotalPage.Text = "Total rows:" + dtnew.Rows.Count.ToString();
            DisablePagingButton(currentPageNumber, pageSize);
        }

        void DisablePagingButton(int currentPageNumber, int pageSize)
        {
            // Show all paging button
            ShowAllPagingButton();

            // Disable First and Previous button if it's the first page
            if (currentPageNumber == 1)
            {
                pbFirst.Enabled = false;
                pbPrev.Enabled = false;
            }
            // Disable Last and Next button if it's the last page
            if (currentPageNumber == pageSize)
            {
                pbLast.Enabled = false;
                pbNext.Enabled = false;
            }

        }

        void ShowAllPagingButton()
        {
            pbFirst.Enabled = true;
            pbPrev.Enabled = true;
            pbLast.Enabled = true;
            pbNext.Enabled = true;
        }

        

        
    }
}
