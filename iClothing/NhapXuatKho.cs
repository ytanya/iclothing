using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronBarCode;
using System.Threading;
using System.Data.SqlServerCe;

namespace iClothing
{
    public partial class NhapXuatKho : UserControl
    {
        Thread delayedCalculationThread;
        int delay = 0;
        public string ConnectionString = DBAccess.ConnectionString;
        DataTable dtMain = new DataTable();
        string strFilter = string.Empty;
        bool isNhap = true;
        string barcode = string.Empty;
        public NhapXuatKho()
        {
            InitializeComponent();
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            btnNhapKho.Enabled = false;
            btnXuatKho.Enabled = true;
            lblTitle.Text = "NHẬP KHO";
            isNhap = true;
        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            btnXuatKho.Enabled = false;
            btnNhapKho.Enabled = true;
            lblTitle.Text = "XUẤT KHO";
            isNhap = false;
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarCode.Text))
            {
                ZXing.BarcodeWriter writer = new ZXing.BarcodeWriter() { Format = ZXing.BarcodeFormat.CODE_128 };
                pbBarcode.Image = writer.Write(txtBarCode.Text);
                CalculateAfterStopTyping();
            }
            
        }

        private void NhapXuatKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormEnter();
            }
        }

        private void NhapXuatKho_Load(object sender, EventArgs e)
        {
            btnNhapKho.Enabled = false;
            this.ActiveControl = txtBarCode;
            //txtBarCode.Text = "2546202104460088";
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormEnter();
            }
        }

        private void txtChuaIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormEnter();
            }
        }

        private void txtDaIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormEnter();
            }
        }

        private void txtTP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormEnter();
            }
        }

        private void txtSPLoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormEnter();
            }
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
                    barcode = txtBarCode.Text;
                    strFilter = "'" + barcode + "'";
                    GetAllData(strFilter);

                    txtBarCode.Text = string.Empty;
                    this.ActiveControl = txtBarCode;

                }));
            });

            delayedCalculationThread.Start();
        }

        private void GetAllData(string strSearch)
        {
            string query = "Select  DISTINCT(NewProduct.Kyhieu), NewProduct.MaSP, NewProduct.Dai, NewProduct.Rong, NewProduct.ARTID, NewProduct.SonID, New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi], Stock.Mieuta [Miêu tả]  from Stock  join(SELECT Barcode, Kyhieu, MaSP, Dai, Rong, ARTID, SonID from Product Group by Kyhieu, MaSP, Barcode, Dai, Rong, ARTID, SonID)NewProduct on Stock.Barcode = NewProduct.Barcode join(SELECT Barcode, SUM(CASE WHEN LoaiID = 0000001 Then Soluongcon ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluongcon ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluongcon ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluongcon ELSE 0 END)[Sản phẩm lỗi] FROM Stock  GROUP BY Barcode) New on New.Barcode = Stock.Barcode where Stock.Barcode = " + strSearch;
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtMain.Merge(dt);
                    txtKyhieu.Text = dt.Rows[0][0].ToString();
                    txtMaHang.Text= dt.Rows[0][1].ToString();
                    txtDai.Text = dt.Rows[0][2].ToString();
                    txtRong.Text = dt.Rows[0][3].ToString();
                    txtHoaTiet.Text = DBHelper.Lookup("ART", "Ten", "ARTID", dt.Rows[0][4].ToString());
                    txtSon.Text = dt.Rows[0][5].ToString();
                    txtChuaInKho.Text = dt.Rows[0][6].ToString();
                    txtDaInKho.Text = dt.Rows[0][7].ToString();
                    txtTPKho.Text = dt.Rows[0][8].ToString();
                    txtSPLoiKho.Text = dt.Rows[0][9].ToString();
                }
            }

        }
        private void FormEnter()
        {
            bool isSuccess = false;
            if (string.IsNullOrEmpty(txtChuaIn.Text)) txtChuaIn.Text = "0";
            if (string.IsNullOrEmpty(txtDaIn.Text)) txtDaIn.Text = "0";
            if (string.IsNullOrEmpty(txtTP.Text)) txtTP.Text = "0";
            if (string.IsNullOrEmpty(txtSPLoi.Text)) txtSPLoi.Text = "0";

            string DonhangID = CommonHelper.RandomString(8);
            string kihieu = txtKyhieu.Text;
            string BTPChuaInSL = txtChuaIn.Text;
            string BTPDaInSL = txtDaIn.Text;
            string TPSL = txtTP.Text;
            string SPLoiSL = txtSPLoi.Text;
            string ngayxong = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            string BTPChuaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
            string BTPDaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
            string TPID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
            string SPLoiID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
            if (DBHelper.checkValidField(BTPChuaInSL) && DBHelper.checkValidField(BTPDaInSL) && DBHelper.checkValidField(TPSL) && DBHelper.checkValidField(SPLoiSL))
                CommonHelper.showDialog("Mời nhập số lượng sản phẩm!", Color.FromArgb(255, 187, 51));
            else
            {
                string itemInStock = DBHelper.getStock(kihieu, DonhangID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL, DateTime.Now.ToString("dd/MM/yyyy"));
                if (string.IsNullOrEmpty(itemInStock))
                {
                    if (isNhap) isSuccess = DBHelper.AddIntoStock(barcode, DonhangID, ngayxong, BTPChuaInID, BTPDaInID, TPID, SPLoiID, BTPChuaInSL, BTPDaInSL, TPSL, SPLoiSL);
                    else isSuccess = DBHelper.AddIntoStock(barcode, DonhangID, ngayxong, BTPChuaInID, BTPDaInID, TPID, SPLoiID, "-" + BTPChuaInSL, "-" + BTPDaInSL, "-" + TPSL, "-" + SPLoiSL);
                }
                else
                {
                    CommonHelper.showDialog(itemInStock, Color.FromArgb(255, 187, 51));
                }
            }

            if (isSuccess)
            {
                GetAllData(strFilter);
                if (isNhap)
                    CommonHelper.showDialog("Đã nhập kho thành công!", Color.FromArgb(4, 132, 75));
                else
                    CommonHelper.showDialog("Đã xuất kho thành công!", Color.FromArgb(4, 132, 75));
                txtBarCode.Text = string.Empty;
            }
              
        }
    }
}
