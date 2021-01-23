using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlServerCe;
using System.IO;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Action = System.Action;

namespace iClothing
{
    public partial class StockManagement : UserControl
    {
        Thread delayedCalculationThread;
        int delay = 0;
        DataTable dtMain = new DataTable();
        public string ConnectionString = DBAccess.ConnectionString;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;
        string strFilter = string.Empty;
        
        DataTable dtStockNew = new DataTable();

        public StockManagement()
        {
            InitializeComponent();
            cbPageSize.SelectedItem = "10";

        }

        private void GetTotalRow(string query)
        {
            string queryAll = "SELECT COUNT(*) AS Total FROM (Select  DISTINCT(NewProduct.Kyhieu) [Ký Hiệu], NewProduct.MaSP [Mã Sản Phẩm],New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi], Stock.Mieuta [Miêu tả]  from Stock  join(SELECT Barcode, Kyhieu, MaSP from Product Group by Kyhieu, MaSP, Barcode)NewProduct on Stock.Barcode = NewProduct.Barcode join(SELECT Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluongcon ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluongcon ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluongcon ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluongcon ELSE 0 END)[Sản phẩm lỗi] FROM Stock " + query + " GROUP BY Barcode) New on New.Barcode = Stock.Barcode) newtotal";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(queryAll, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    rowCount = Convert.ToInt32(dt.Rows[0][0].ToString());
                    pageSize = rowCount / rowPerPage;
                    // if any row left after calculated pages, add one more page 
                    if (rowCount % rowPerPage > 0)
                        pageSize += 1;
                    txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
                    lblTotalPage.Text = "Tổng số:" + rowCount.ToString();
                }
            }
        }
        private void StockManagement_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtBarcode;
            btnExport.Visible = false;

            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Value = DateTime.Now;

            // Init Ki hieu combobox
            DataTable dtProduct = DBHelper.GetAllProduct();
            if (dtProduct.Rows.Count > 0)
            {
                cbKyHieu.DataSource = dtProduct;
                cbKyHieu.ValueMember = "Barcode";
                cbKyHieu.DisplayMember = "Kyhieu";
                cbKyHieu.SelectedIndex = -1;
            }
            currentPageNumber = 1;
            rowPerPage = 10;
            cbPageSize.SelectedIndex = 0;
            strFilter = "Where  ngaytao <'" + dtpDenNgay.Value.AddDays(1).ToString("yyyy-MM-dd") +"'";
            GetTotalRow(strFilter);
            GetAllData(currentPageNumber, rowPerPage, strFilter);
        }

        public System.Data.DataTable ExportToExcel()
        {
            dtStockNew = new DataTable();
            dtStockNew.Columns.Add("STT", typeof(int));
            dtStockNew.Columns.Add("KÝ HIỆU", typeof(string));
            dtStockNew.Columns.Add("MÃ HÀNG", typeof(string));
            dtStockNew.Columns.Add("BTP Chưa in ", typeof(string));
            dtStockNew.Columns.Add("BTP Đã in ", typeof(string));
            dtStockNew.Columns.Add("Thành Phẩm ", typeof(string));
            dtStockNew.Columns.Add("SP Lỗi ", typeof(string));
            dtStockNew.Columns.Add("GHI CHÚ", typeof(string));

            DataRow row;
            string kyhieu, masp, btpchuain, btpdain, tp, sploi, ghichu;
            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                kyhieu = dtMain.Rows[i][0].ToString();
                masp = dtMain.Rows[i][1].ToString();
                btpchuain = dtMain.Rows[i][2].ToString();
                btpdain = dtMain.Rows[i][3].ToString();
                tp = dtMain.Rows[i][4].ToString();
                sploi = dtMain.Rows[i][5].ToString();
                ghichu = dtMain.Rows[i][6].ToString();
                dtStockNew.Rows.Add(i+1, kyhieu, masp, btpchuain, btpdain, tp, sploi, ghichu);
            }
            return dtStockNew;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Creating Save File Dialog
            SaveFileDialog save = new SaveFileDialog();
            //Showing the dialog
            save.ShowDialog();
            //Setting default directory
            save.InitialDirectory = @"C:\";
            save.RestoreDirectory = true;
            string fileName = save.FileName;
            save.AddExtension = true;
            save.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
            //Setting title
            save.Title = "Select save location and input file name";
            //filtering to only show .xlsx files in the directory
            save.DefaultExt = "xlsx";
            // Write Data to DataTable
            ExportToExcel();
            //Write Data To Excel
            ToExcel(fileName);
        }
        private void ToExcel(string fileName)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), fileName + DateTime.Now.ToString("M-dd-yyyy-HH.mm.ss") + ".xlsx");
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Sheet1";
            // storing header part in Excel  
            var columnHeadingsRange = worksheet.Range[worksheet.Cells[1, 4], worksheet.Cells[1, 8]];
            columnHeadingsRange.Interior.Color = XlRgbColor.rgbOrange;
            for (int i = 0; i < dtStockNew.Columns.Count; i++)
            {
                worksheet.Cells[1, i+1] = dtStockNew.Columns[i].ToString();
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dtStockNew.Rows.Count; i++)
            {
                for (int j = 0; j < dtStockNew.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dtStockNew.Rows[i][j].ToString();
                }
            }
            // save the application  
            workbook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
        }

        private void pbFirst_Click(object sender, EventArgs e)
        {
            if (currentPageNumber >1)
            {
                currentPageNumber = 1;
                GetAllData(currentPageNumber, rowPerPage, strFilter);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber -= 1;
                GetAllData(currentPageNumber, rowPerPage, strFilter);
            }
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }


        private void pbNext_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                GetAllData(currentPageNumber, rowPerPage, strFilter);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                GetAllData(currentPageNumber, rowPerPage, strFilter);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            CalculateAfterStopTyping();
        }

        private void CalculateAfterStopTyping()
        {
            delay += 30;
            if (delayedCalculationThread != null && delayedCalculationThread.IsAlive)
                return;

            delayedCalculationThread = new Thread(() =>
            {
                while (delay >= 20)
                {
                    delay = delay - 20;
                    try
                    {
                        Thread.Sleep(20);
                    }
                    catch (Exception) { }
                }
                Invoke(new Action(() =>
                {
                    string barcode = txtBarcode.Text;
                    strFilter = " WHERE Barcode ='" + barcode + "'";
                    GetTotalRow(strFilter);
                    GetAllData(currentPageNumber, rowPerPage, strFilter);
                    
                    this.ActiveControl = txtBarcode;

                }));
            });

            delayedCalculationThread.Start();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            this.ActiveControl = txtBarcode;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = string.Empty;
            cbKyHieu.SelectedIndex = -1;
            strFilter = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            strFilter = string.Empty;
            string Ngay =  string.Format("ngaytao < '{0}'", dtpDenNgay.Value.AddDays(1).ToString("yyyy-MM-dd"));
            strFilter = Ngay;
            string barcode = string.IsNullOrEmpty(txtBarcode.Text) ? string.Empty : " Barcode like '" + txtBarcode.Text + "'";
            strFilter = string.IsNullOrEmpty(strFilter) ? (string.IsNullOrEmpty(barcode) ? "" : barcode) : (string.IsNullOrEmpty(barcode) ? strFilter : strFilter + " AND " + barcode);
            string kihieuValue = cbKyHieu.SelectedIndex == -1 ? string.Empty :  cbKyHieu.SelectedValue.ToString();
            string kyhieu = string.IsNullOrEmpty(kihieuValue) ? string.Empty : " Barcode like '" + kihieuValue + "'";
            strFilter = string.IsNullOrEmpty(strFilter) ? (string.IsNullOrEmpty(kyhieu) ? "" : kyhieu) : (string.IsNullOrEmpty(kyhieu) ? strFilter : strFilter + " AND " + kyhieu);
            if (!string.IsNullOrEmpty(strFilter))
            {
                strFilter = " WHERE " + strFilter;
            }
            GetTotalRow(strFilter);
            GetAllData(currentPageNumber, rowPerPage, strFilter);
           
        }

        private void GetAllData(int currentPageNumber, int rowPerPage, string strSearch)
        {
            DataTable dtMain = new DataTable();
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = skipRecord * rowPerPage;

            
            string query = "Select  DISTINCT(NewProduct.Kyhieu) [Ký Hiệu], NewProduct.MaSP [Mã Sản Phẩm],New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi], Stock.Mieuta [Miêu tả]  from Stock  join(SELECT Barcode, Kyhieu, MaSP from Product Group by Kyhieu, MaSP, Barcode)NewProduct on Stock.Barcode = NewProduct.Barcode join(SELECT Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluongcon ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluongcon ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluongcon ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluongcon ELSE 0 END)[Sản phẩm lỗi] FROM Stock "+ strSearch + " GROUP BY Barcode) New on New.Barcode = Stock.Barcode  order by [Ký Hiệu] OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    dvgStock.DataSource = dtMain;
                    //dgvOrder.Columns[0].Visible = false;
                    //dgvOrder.Columns[1].Visible = false;
                    //dgvOrder.Columns[3].Width = 130;
                    dvgStock.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dvgStock.Columns[1].Width = 150;
                    //dgvOrder.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    //dgvOrder.Columns[2].Width = 150;
                    //dgvOrder.Columns["Ký Hiệu"].Width = 60;
                    dvgStock.Columns["BTP Chưa in"].Width = 100;
                    this.dvgStock.Columns["BTP Chưa in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgStock.Columns["BTP Đã in"].Width = 100;
                    this.dvgStock.Columns["BTP Đã in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgStock.Columns["Thành Phẩm"].Width = 100;
                    this.dvgStock.Columns["Thành Phẩm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgStock.Columns["Sản phẩm lỗi"].Width = 100;
                    this.dvgStock.Columns["Sản phẩm lỗi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgStock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

        }
    }
}
