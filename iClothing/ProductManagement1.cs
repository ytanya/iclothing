using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ExcelDataReader;
using System.Data.SqlServerCe;
using System.Configuration;
using Microsoft.Office.Interop.Excel;
using IronBarCode;

namespace iClothing
{
    public partial class ProductManagement1 : UserControl
    {
        private System.Data.DataTable dtMain = new System.Data.DataTable();
        private System.Data.DataTable dtCurrent = new System.Data.DataTable();
        System.Data.DataTable dtProductNew = new System.Data.DataTable();
        bool isSuccess = true;
        public string ConnectionString = DBAccess.ConnectionString;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;
        string strSearch = string.Empty;
        public ProductManagement1()
        {
            InitializeComponent();
            cbPageSize.SelectedText = "10";
            txtBarcode.Enabled = true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string Barcode, Kyhieu, MaSP, Dai, Rong, ARTID, SonID, DVT, Mieuta, ngaytao, ngaysua;
            Barcode= Kyhieu= MaSP= Dai= Rong= ARTID= SonID= DVT= Mieuta= ngaytao= ngaysua = string.Empty;
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            IExcelDataReader reader;
                            if (ofd.FilterIndex == 2)
                            {
                                reader = ExcelReaderFactory.CreateBinaryReader(stream);
                            }
                            else
                            {
                                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                            }

                            DataSet ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });
                            
                                
                                string InsertItemQry = "";
                                int count = 0;
                                System.Data.DataTable dt = ds.Tables[0];
                                string[] columnNames = dt.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();
                                
                                for (int i = 7; i < dt.Rows.Count; i++)
                                {
                                    //BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                                    //pictureBox1.Image = writer.Write(textBox1.Text);
                                    //Barcode = BarcodeFormat.CODE_128;
                                    string now = DateTime.Now.ToString("ddmmyyyhhmmssff");
                                GeneratedBarcode newbarcode = BarcodeWriter.CreateBarcode(now, BarcodeWriterEncoding.Code128);
                                
                                    Barcode = newbarcode.ToString();
                                    Kyhieu = Convert.ToString(dt.Rows[i][1]).Trim();
                                    MaSP = Convert.ToString(dt.Rows[i][2]).Trim();
                                    Dai = Convert.ToString(dt.Rows[i][3]).Trim();
                                    Rong = Convert.ToString(dt.Rows[i][4]).Trim();
                                    ARTID = DBHelper.Lookup("ART", "ARTID", "Ten", Convert.ToString(dt.Rows[i][5]).Trim('\'').Trim());
                                if (string.IsNullOrEmpty(ARTID))
                                    MessageBox.Show(Convert.ToString(dt.Rows[i][5]).Trim('\''));
                                    SonID = DBHelper.Lookup("Color", "SonID", "Ten", Convert.ToString(dt.Rows[i][6]).Trim('\'').Trim());
                                if (string.IsNullOrEmpty(SonID))
                                    MessageBox.Show(Convert.ToString(dt.Rows[i][6]).Trim('\''));
                                DVT = Convert.ToString(dt.Rows[i][8]).Trim();
                                    Mieuta = string.Empty;
                                    ngaytao = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                                ngaysua = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                                if (Kyhieu != string.Empty)
                                {
                                    InsertItemQry = "Insert into Product([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) Values ('" + Barcode + "','" + Kyhieu + "','" + Dai + "','" + Rong + "','" + ARTID + "','" + SonID + "','" + DVT + "','" + "" + "','" + ngaysua + "','" + ngaytao + "','" + MaSP + "')";
                                    if (DBAccess.IsServerConnected())
                                    {
                                        if (InsertItemQry.Length > 5)
                                        {
                                            isSuccess = DBAccess.ExecuteQuery(InsertItemQry);

                                        }
                                    }
                                    if(isSuccess) count++;
                                    else
                                    {
                                        MessageBox.Show(InsertItemQry);
                                    }

                                }
                                else
                                {
                                    GetTotalRow();
                                    GetAllDataProduct(1, 50);
                                    MessageBox.Show("Import " + count + " dòng thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                
                                
                            }
                            if (isSuccess)
                            {
                                MessageBox.Show("Import " + count + " dòng thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               
                            }
                            else
                            {
                                MessageBox.Show("Import dòng " + count + " không thành công!Kyhieu = "+ Kyhieu, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("File không đúng format! Format Đúng: Dữ liệu bắt đầu từ dòng 7, cột 1: Ký Hiệu, cột 2: Mã SP, cột 3: Dài, cột 4: Rộng, cột 5: ART, cột 6: SON, cột 8:DVT ");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                bool isSuccess = false;
                string Barcode, Kyhieu, Dai, Rong, ARTID, SonID, DVT, MaSP, Mieuta;
                Barcode = Kyhieu = Dai = Rong = ARTID = SonID = DVT = MaSP = Mieuta = string.Empty;

                // Set value for number field
                if (string.IsNullOrEmpty(txtDai.Text)) txtDai.Text = "0";
                if (string.IsNullOrEmpty(txtRong.Text)) txtRong.Text = "0";


                // Barcode
                Barcode = txtBarcode.Text;
                //Kyhieu
                Kyhieu = txtKyhieu.Text;
                Dai = txtDai.Text;
                Rong = txtRong.Text;
                ARTID = cbArt.SelectedValue.ToString();
                SonID = cbSon.SelectedValue.ToString();
                DVT = txtDVT.Text;
                MaSP = txtMaSP.Text;
                Mieuta = txtMieuta.Text;

                string modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                query = "UPDATE [Product] SET[Kyhieu] ='" + Kyhieu + "',[Dai]= '" + Dai + "',[Rong]= '" + Rong + "',[ARTID]= '" + ARTID + "',[SonID]= '" + SonID + "',[DVT]= '" + DVT + "',[Mieuta]= '" + Mieuta + "',[Ngaysua]= '" + modifyDate + "' WHERE Barcode ='" + Barcode + "';";


                if (DBAccess.IsServerConnected())
                {

                    isSuccess = DBAccess.ExecuteQuery(query);
                }


                if (isSuccess)
                {
                    cbSon.SelectedIndex = 0;
                    cbArt.SelectedIndex = 0;
                    currentPageNumber = 1;
                    ClearText();
                    // Update datalist
                    GetAllDataProduct(currentPageNumber, rowPerPage);
                    MessageBox.Show("Đã cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private void ClearText()
        {
            txtBarcode.Text = string.Empty;
            txtKyhieu.Text = string.Empty;
            txtMaSP.Text = string.Empty;
            txtDai.Text = string.Empty;
            txtRong.Text = string.Empty;
            cbArt.SelectedIndex = 0;
            cbSon.SelectedIndex = 0;
            txtMieuta.Text = string.Empty;
            txtDVT.Text = string.Empty;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            if (dvgProduct.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dvgProduct.SelectedRows)
                {
                    string barcode = row.Cells[0].Value.ToString();

                    string orderID = row.Cells[0].Value.ToString();
                    string query = "DELETE FROM Product WHERE Barcode ='" + barcode + "';";
                    isSuccess = DBAccess.ExecuteQuery(query);
                    if (!isSuccess) return;
                    dvgProduct.Rows.Remove(row);
                }
                GetTotalRow();
                GetAllDataProduct(1, 50);
                ClearText();
            }
            else
            {
                MessageBox.Show("Mời chọn đơn hàng muốn xóa!");
            }

        }

        private void ClearTextBox()
        {
            txtBarcode.Text = string.Empty;
            txtBarcode.Enabled = true;
            txtDai.Text = string.Empty;
            txtRong.Text = string.Empty;
            txtDVT.Text = string.Empty;
            txtMaSP.Text = string.Empty;
            txtMieuta.Text = string.Empty;
            txtKyhieu.Text = string.Empty;
        }

        private void ProductManagement1_Load(object sender, EventArgs e)
        {
            GetAllInitData();
        }

        private void GetAllInitData()
        {
            currentPageNumber = 1;
            rowPerPage = 10;
            GetTotalRow();
            GetAllDataProduct(currentPageNumber, rowPerPage);
            cbPageSize.SelectedIndex = 0;
            // Init Color combobox
            System.Data.DataTable dtColor = DBHelper.GetAllColor();
            if (dtColor.Rows.Count > 0)
            {
                cbSon.DataSource = dtColor;
                cbSon.ValueMember = "SonID";
                cbSon.DisplayMember = "Ten";
                cbSon.SelectedIndex = 0;
            }

            // Init Art combobox
            System.Data.DataTable dtArt = DBHelper.GetAllArt();
            if (dtArt.Rows.Count > 0)
            {
                cbArt.DataSource = dtArt;
                cbArt.ValueMember = "ARTID";
                cbArt.DisplayMember = "Ten";
                cbArt.SelectedIndex = 0;
            }
        }
        private void GetTotalRow(string strSearch)
        {
            string queryAll = "SELECT COUNT(*) AS Total FROM [Product] " + strSearch;
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(queryAll, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    sda.Fill(dt);

                    rowCount = Convert.ToInt32(dt.Rows[0][0].ToString());
                    pageSize = rowCount / rowPerPage;
                    // if any row left after calculated pages, add one more page 
                    if (rowCount % rowPerPage > 0)
                        pageSize += 1;
                    if (pageSize >0) txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
                    lblTotalPage.Text = "Tổng số:" + rowCount.ToString();
                }
            }
        }
        private void GetAllDataProduct(int currentPageNumber, int rowPerPage, string strSearch)
        {
             dtMain = new System.Data.DataTable();
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = skipRecord * rowPerPage;

            string query = "SELECT Barcode, Kyhieu [Ký Hiệu], MASP [Mã Sản Phẩm], Dai [Dài], Rong [Rộng], ART.Ten [ART], Color.Ten [Sơn], DVT, Product.Mieuta [Miêu tả] FROM [Product] Join ART on ART.ArtID = Product.ArtID join Color on Color.SonID = Product.SonID Order by Product.Ngaysua " + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    dvgProduct.DataSource = dtMain;
                    dvgProduct.Columns["Dài"].Width = 60;
                    this.dvgProduct.Columns["Dài"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgProduct.Columns["Rộng"].Width = 60;
                    this.dvgProduct.Columns["Rộng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    if (dtMain.Rows.Count > 0)
                    {
                        txtKyhieuFilter.Visible = true;
                        txtMaSPFilter.Visible = true;
                        txtDaiFilter.Visible = true;
                        txtRongFilter.Visible = true;
                        txtArtFilter.Visible = true;
                        txtSonFilter.Visible = true;
                    }
                    else
                    {
                        txtKyhieuFilter.Visible = false;
                        txtMaSPFilter.Visible = false;
                        txtDaiFilter.Visible = false;
                        txtRongFilter.Visible = false;
                        txtArtFilter.Visible = false;
                        txtSonFilter.Visible = false;
                    }
                }
            }

        }



        private void pbFirst_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber = 1;
                GetAllDataProduct(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber -= 1;
                GetAllDataProduct(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                GetAllDataProduct(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                GetAllDataProduct(currentPageNumber, rowPerPage);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void dvgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dvgProduct.Rows[e.RowIndex];
                txtBarcode.Text = dgvRow.Cells[0].Value.ToString();
                txtKyhieu.Text = dgvRow.Cells[1].Value.ToString();
                txtMaSP.Text = dgvRow.Cells[2].Value.ToString();
                txtDai.Text = dgvRow.Cells[3].Value.ToString();
                txtRong.Text = dgvRow.Cells[4].Value.ToString();
                cbArt.Text = dgvRow.Cells[5].Value.ToString();
                cbArt.SelectedValue = DBHelper.Lookup("Art", "ArtID", "Ten", dgvRow.Cells[5].Value.ToString());
                cbSon.Text = dgvRow.Cells[6].Value.ToString();
                cbSon.SelectedValue = DBHelper.Lookup("Color", "SonID", "Ten", dgvRow.Cells[6].Value.ToString());
                txtDVT.Text = dgvRow.Cells[7].Value.ToString();
                txtMieuta.Text = dgvRow.Cells[8].Value.ToString();

                txtBarcode.Enabled = false;

            }
        }



        

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPageSize.SelectedItem.ToString().ToLower() == "all") { GetTotalRow(); rowPerPage = rowCount; }

            else rowPerPage = Convert.ToInt32(cbPageSize.SelectedItem.ToString());

            currentPageNumber = 1;
            GetAllDataProduct(currentPageNumber, rowPerPage);
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            if (pageSize > 0) txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }




        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!txtBarcode.Enabled)
            {
                if (MessageBox.Show("Bạn có muốn tạo mới không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    txtBarcode.Text = CommonHelper.RandomString(14);
                    CreateNew();
                }
                else
                {
                    ClearText();
                }
            }
            else
            {
                CreateNew();
            }
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
            int rowSuccess = 0;
            int row = 0, column = 0;
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), fileName + DateTime.Now.ToString("dd-MM-yyyy-HH.mm.ss") + ".xlsx");
                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = false;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Sheet1";
                // storing header part in Excel  
                //var columnHeadingsRange = worksheet.Range[worksheet.Cells[1, 4], worksheet.Cells[1, 8]];
                //columnHeadingsRange.Interior.Color = XlRgbColor.rgbOrange;
                Bitmap bmp;
                byte[] imgData;
                //using (var ms = new MemoryStream(imgData))
                //{
                //    bmp = new Bitmap(ms);
                //    System.Windows.Forms.Clipboard.SetDataObject(bmp, false);
                //    var rng = worksheet.Cells[2,1];
                //    worksheet.Paste(rng, bmp);
                //}
                int columnHeader = 0;
                
                for (int i = 0; i < dtProductNew.Columns.Count; i++)
                {
                    if (dtProductNew.Columns[i].ColumnName == "Barcode")
                    {
                        columnHeader += 1;
                    }
                    worksheet.Cells[1, columnHeader + 1] = dtProductNew.Columns[i].ToString();
                    columnHeader++;
                }
                
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dtProductNew.Rows.Count; i++)
                {
                    rowSuccess++;
                    for (int j = 0; j < dtProductNew.Columns.Count; j++)
                    {
                        if (dtProductNew.Columns[j].ColumnName == "Barcode")
                        {
                            imgData = (byte[])dtProductNew.Rows[i][j];
                            using (var ms = new MemoryStream(imgData))
                            {
                                bmp = new Bitmap(ms);
                                System.Windows.Forms.Clipboard.SetDataObject(bmp, false);
                                var rng = worksheet.Cells[row + 2, column + 1];
                                worksheet.Paste(rng, bmp);
                                column += 2;
                            }
                        }
                        else
                        {
                            worksheet.Cells[row + 2, column + 1] = dtProductNew.Rows[i][j].ToString();
                            //row++;
                            column++;
                        }
                    }
                    column = 0;
                    row += 5;
                }
                // save the application  
                workbook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                workbook.Close();
                // Exit from the application  
                app.Quit();
            }
            
            catch (Exception ex)
            {

                MessageBox.Show("NOT SUCCESS" + rowSuccess);
            }
        }

        public System.Data.DataTable ExportToExcel()
        {
            dtProductNew = new System.Data.DataTable();
            dtProductNew.Columns.Add("STT", typeof(int));
            dtProductNew.Columns.Add("Barcode", typeof(byte[]));
            dtProductNew.Columns.Add("Ký Hiệu", typeof(string));
            dtProductNew.Columns.Add("Mã Sản Phẩm", typeof(string));
            dtProductNew.Columns.Add("Dài", typeof(int));
            dtProductNew.Columns.Add("Rộng", typeof(int));
            dtProductNew.Columns.Add("ART", typeof(string));
            dtProductNew.Columns.Add("Sơn", typeof(string));
            dtProductNew.Columns.Add("DVT", typeof(string));
            dtProductNew.Columns.Add("Miêu tả", typeof(string));

            DataRow row;
            string kyhieu, masp, dai, rong, art, son, dvt, mieuta;
            Bitmap bmbarcode;
            byte[] barcode;
            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                //BarcodeResult[] Results = BarcodeReader.
                ZXing.BarcodeWriter writer = new ZXing.BarcodeWriter() { Format = ZXing.BarcodeFormat.CODE_128 };
                bmbarcode = writer.Write(dtMain.Rows[i][0].ToString());
                byte[] byteArray = CommonHelper.imageToByteArray(bmbarcode);
                //Stream stream = new MemoryStream(byteArray, false);
                barcode = byteArray;
                    //Bitmap bmbarcode = new Bitmap(barcode.Length * 50, 90);                
                    kyhieu = dtMain.Rows[i][1].ToString();
                masp = dtMain.Rows[i][2].ToString();
                dai = dtMain.Rows[i][3].ToString();
                rong = dtMain.Rows[i][4].ToString();
                art = dtMain.Rows[i][5].ToString();
                son = dtMain.Rows[i][6].ToString();
                dvt = dtMain.Rows[i][7].ToString();
                mieuta = dtMain.Rows[i][7].ToString();
                dtProductNew.Rows.Add(i + 1, barcode, kyhieu, masp, dai, rong, art, son, dvt, mieuta);
            }
            return dtProductNew;
        }

        private void txtKyhieuFilter_TextChanged(object sender, EventArgs e)
        {
            (dvgProduct.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("[Ký Hiệu] like '{0}%'", txtKyhieuFilter.Text);
        }

        private void txtMaSPFilter_TextChanged(object sender, EventArgs e)
        {
            (dvgProduct.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("[Mã Sản Phẩm] like '{0}%'", txtMaSPFilter.Text);
        }

        private void txtDaiFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDaiFilter.Text)) (dvgProduct.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Empty;
            else (dvgProduct.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("[Dài] = {0}", Convert.ToInt32(txtDaiFilter.Text));
        }

        private void txtRongFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRongFilter.Text)) (dvgProduct.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Empty;
            else
                (dvgProduct.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("[Rộng] = {0}", Convert.ToInt32(txtRongFilter.Text));
        }

        private void txtArtFilter_TextChanged(object sender, EventArgs e)
        {
            (dvgProduct.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("[ART] like '{0}%'", txtArtFilter.Text);
        }

        private void txtSonFilter_TextChanged(object sender, EventArgs e)
        {
            (dvgProduct.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("[Sơn] like '{0}%'", txtSonFilter.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitSearch();
            GetTotalRow(strSearch);
            GetAllDataOrder(currentPageNumber, rowPerPage, strSearch);
        }
        private void InitSearch()
        {
            txtKyhieuFilter.Text = string.Empty;
            txtMaSPFilter.Text = string.Empty;
            txtDaiFilter.Text = string.Empty;
            txtRongFilter.Text = string.Empty;
            txtArtFilter.Text = string.Empty;
            txtSonFilter.Text = string.Empty;
        }
        private void CreateNew()
        {
            string query = "";
            bool isSuccess = false;
            string Barcode, Kyhieu, Dai, Rong, ARTID, SonID, DVT, MaSP, Mieuta;
            Barcode = Kyhieu = Dai = Rong = ARTID = SonID = DVT = MaSP = Mieuta = string.Empty;

            // Set value for number field
            if (string.IsNullOrEmpty(txtDai.Text)) txtDai.Text = "0";
            if (string.IsNullOrEmpty(txtRong.Text)) txtRong.Text = "0";


            // Barcode
            if (string.IsNullOrEmpty(txtBarcode.Text)) Barcode = CommonHelper.RandomString(14);
            else Barcode = txtBarcode.Text;
            //Kyhieu
            Kyhieu = txtKyhieu.Text;
            Dai = txtDai.Text;
            Rong = txtRong.Text;
            ARTID = cbArt.SelectedValue.ToString();
            SonID = cbSon.SelectedValue.ToString();
            DVT = txtDVT.Text;
            MaSP = txtMaSP.Text;
            Mieuta = txtMieuta.Text;
            // Created Date
            string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");

            query = "Insert into Product([Barcode],[Kyhieu],[Dai],[Rong],[ArtID],[SonID],[DVT],[Mieuta],[Ngaytao],[Ngaysua],[MaSP]) Values ('" + Barcode + "','" + Kyhieu + "','" + Dai + "','" + Rong + "','" + ARTID + "','" + SonID + "','" + DVT + "','" + Mieuta + "','" + createDate + "','" + createDate + "','" + MaSP + "')";
            if (DBAccess.IsServerConnected())
            {

                isSuccess = DBAccess.ExecuteQuery(query);

                if (isSuccess)
                {
                    cbSon.SelectedIndex = 0;
                    cbArt.SelectedIndex = 0;
                    currentPageNumber = 1;
                    ClearText();
                    // Update datalist
                    GetTotalRow();
                    GetAllDataProduct(currentPageNumber, rowPerPage);

                    MessageBox.Show("Đã thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void txtDai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
