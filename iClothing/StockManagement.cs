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
        string conn = DBAccess.ConnectionString;
        DataTable dtMain = new DataTable();
        string pathCSV = System.AppDomain.CurrentDomain.BaseDirectory + "taphoaviet.csv";
        DataTable dtStockNew = new DataTable();
        private int currentPageNumber = 1;
        private int pageSize = 0;
        private int rowPerPage = 10;

        public StockManagement()
        {
            InitializeComponent();
            cbPageSize.SelectedItem = "10";

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
                    string id = txtBarcode.Text;
                    if (DBAccess.IsServerConnected())
                    {
                        string query = "Select  DISTINCT(NewProduct.Kyhieu) [Ký Hiệu],NewProduct.MaSP [Mã Sản Phẩm],New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi], Stock.Mieuta [Miêu tả]  from Stock  join(SELECT Barcode, Kyhieu, MaSP from Product Group by Kyhieu, MaSP, Barcode)NewProduct on Stock.Barcode = NewProduct.Barcode join(SELECT Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluongcon ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluongcon ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluongcon ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluongcon ELSE 0 END)[Sản phẩm lỗi] FROM Stock GROUP BY Barcode) New on New.Barcode = Stock.Barcode; ";

                        using (SqlCeConnection connection = new SqlCeConnection(conn))
                        {
                            using (SqlCeCommand command = new SqlCeCommand(query, connection))
                            {
                                SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                dtMain.Merge(dt);
                                string barcode = txtBarcode.Text;
                                if (barcode != string.Empty)
                                {
                                    string filterString = "[Barcode] IN ('" + barcode + "')";
                                    dtMain = dtMain.Select(filterString).CopyToDataTable();
                                }
                                dvgStock.DataSource = dtMain;
                                lblTotalPage.Text = dtMain.Rows.Count.ToString();
                                
                            }
                        }
                    }


                    txtBarcode.Text = string.Empty;

                }));
            });

            delayedCalculationThread.Start();
        }

        private void StockManagement_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtBarcode;
            btnExport.Visible = false;
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

        private void pbSearch_Click(object sender, EventArgs e)
        {
            btnExport.Visible = true;
            dtMain = new DataTable();
            CalculateAfterStopTyping();
            PopulateDataStock(currentPageNumber, rowPerPage, dtMain);
        }

        private void pbFirst_Click(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            PopulateDataStock(currentPageNumber, rowPerPage, dtMain);
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 0)
            {
                currentPageNumber -= 1;
                PopulateDataStock(currentPageNumber, rowPerPage, dtMain);
            }
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void PopulateDataStock(int currentPageNumber, int rowPerPage, DataTable dtMain)
        {
            int skipRecord = (currentPageNumber - 1) * rowPerPage;

            if (dtMain.Rows.Count > 0)
            {
                dvgStock.DataSource = dtMain.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();
            }
            else
            {
                dvgStock.DataSource = dtMain;
            }
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                PopulateDataStock(currentPageNumber, rowPerPage, dtMain);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                PopulateDataStock(currentPageNumber, rowPerPage, dtMain);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }
    }
}
