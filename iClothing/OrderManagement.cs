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
using System.Configuration;
using System.IO;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace iClothing
{
    public partial class OrderManagement : UserControl
    {
        private DataTable dtTab1Input = new DataTable();
        private DataTable dtTab1Output = new DataTable();
        private DataTable dtManageInOut = new DataTable();
        private DataTable dtCurrent = new DataTable();
        private DataTable OrignalADGVdt = null;
        private DataTable dtOrderNotDone = new DataTable();
        private DataTable dtTemp = new DataTable();
        private DataTable dtManageOrderNew = new DataTable();
        private int currentPageNumber = 1;
        private int pageSize = 0;
        private int rowPerPage = 10;
        private string currentOrderByItem = "Ngaytao";
        private Bitmap bmp;
        public static string conn = "Data Source=" + ConfigurationManager.AppSettings["datapath"] + "; Persist Security Info=False";
        public OrderManagement()
        {
            InitializeComponent();
            rbNhap.Checked = true;
            panel1.Visible = false;
            //txtBTPChuaIn1.Enabled = false;
            //txtOrderID1.Enabled = false;
            dtTemp.Columns.Add("Donhang", typeof(string));
            dtTemp.Columns.Add("Xong", typeof(int));
            btnXong.Enabled = false;
        }
        /******************************** Start Common******************************************/
        private void rbNhap_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    panel2.Visible = true;
                    panel1.Visible = false;
                    dgvOrder1.Visible = false;
                    dgvOrder2.Visible = true;
                    currentPageNumber = 1;
                    rowPerPage = 10;

                    GetAllDataOrderOutput();
                    dtCurrent = dtTab1Output;
                    PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                    cbPageSize.SelectedIndex = 0;
                }
            }
        }

        private void rbXuat_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    panel1.Visible = true;
                    panel2.Visible = false;
                    dgvOrder1.Visible = true;
                    dgvOrder2.Visible = false;
                    currentPageNumber = 1;
                    rowPerPage = 10;

                    GetAllDataOrderInput();
                    dtCurrent = dtTab1Input;
                    PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                    cbPageSize.SelectedIndex = 0;
                }
            }
        }

        private void OrderManagement_Load(object sender, EventArgs e)
        {
            GetAllDataTab1();
        }
        private void GetAllDataTab1()
        {
            btnUpdate.Visible = false;
            btnUpdate1.Visible = false;

            dgvOrder1.Visible = false;
            // Input
            GetAllDataOrderInput();
            // Output
            GetAllDataOrderOutput();

            dtCurrent = dtTab1Output;
            PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);


            // Init Customer combobox
            DataTable dtCustomer = DBHelper.GetAllCustomer();
            if (dtCustomer.Rows.Count > 0)
            {
                cbCustomer.DataSource = dtCustomer;
                cbCustomer.ValueMember = "KHID";
                cbCustomer.DisplayMember = "HoTen";
                cbCustomer.SelectedIndex = 0;
            }

            // Init Ki hieu combobox
            DataTable dtProduct = DBHelper.GetAllProduct();
            if (dtProduct.Rows.Count > 0)
            {
                cbKihieu2.DataSource = dtProduct;
                cbKihieu2.ValueMember = "Barcode";
                cbKihieu2.DisplayMember = "Kyhieu";
                cbKihieu2.SelectedIndex = 0;
                cbKihieu1.DataSource = dtProduct;
                cbKihieu1.ValueMember = "Barcode";
                cbKihieu1.DisplayMember = "Kyhieu";
                cbKihieu1.SelectedIndex = 0;
            }

            // Init Supplier combobox
            DataTable dtSupplier = DBHelper.GetAllSupplier();
            if (dtSupplier.Rows.Count > 0)
            {
                cbNhacc.DataSource = dtSupplier;
                cbNhacc.ValueMember = "NhaccID";
                cbNhacc.DisplayMember = "Ten";
                cbNhacc.SelectedIndex = 0;
            }
            cbPageSize.SelectedIndex = 0;
        }
        /******************************** Start Common******************************************/

        /******************************** Start Panel 1******************************************/
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtItem = (DataTable)(dgvOrder2.DataSource);
                string IsCompleted = "false";
                string DonhangID, barcode, BTPChuaIn, BTPDaIn, TP, SPLoi, KHID, modifyDate;
                List<string> InsertItemQryList = new List<string>();
                string InsertItemQry = "";
                bool isSuccess = false;
                int count = 0;
                DataRow rd = dtTab1Input.NewRow();

                // Set value for number field
                if (string.IsNullOrEmpty(txtChuaIn2.Text)) txtChuaIn2.Text = "0";
                if (string.IsNullOrEmpty(txtDaIn2.Text)) txtDaIn2.Text = "0";
                if (string.IsNullOrEmpty(txtTP2.Text)) txtTP2.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoi2.Text)) txtSPLoi2.Text = "0";

                // DonhangID
                DonhangID = CommonHelper.RandomString(8);
                rd[0] = DonhangID;
                // KHID
                KHID = cbCustomer.SelectedValue.ToString();
                rd[1] = DBHelper.Lookup("Customer", "HoTen", "KHID", KHID);
                // Barcode
                barcode = cbKihieu2.SelectedValue.ToString();
                rd[2] = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                // BTPChuaIn
                BTPChuaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                rd[3] = txtChuaIn2.Text;
                // BTPDaIn
                BTPDaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                rd[4] = txtDaIn2.Text;
                // TP
                TP = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                rd[5] = txtTP2.Text;
                // SPLoi
                SPLoi = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                rd[6] = txtSPLoi2.Text;
                // Modify Date
                modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                rd[7] = modifyDate;
                // Xong
                rd[8] = IsCompleted;

                string orderDetailID1 = CommonHelper.RandomString(7) + 1;
                string orderDetailID2 = CommonHelper.RandomString(7) + 2;
                string orderDetailID3 = CommonHelper.RandomString(7) + 3;
                string orderDetailID4 = CommonHelper.RandomString(7) + 4;
                if (barcode != "")
                {
                    InsertItemQry = "INSERT INTO [Order] ([DonhangID],[KHID],[Xong],[Ngaytao],[Ngaysua])VALUES('" + DonhangID + "','" + KHID + "','" + IsCompleted + "','" + modifyDate + "','" + modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                    InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID1 + "','" + DonhangID + "','" + barcode + "','" + BTPChuaIn + "','" + txtChuaIn2.Text + "','" + modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                    InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID2 + "','" + DonhangID + "','" + barcode + "','" + BTPDaIn + "','" + txtDaIn2.Text + "','" + modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                    InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID3 + "','" + DonhangID + "','" + barcode + "','" + TP + "','" + txtTP2.Text + "','" + modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                    InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID4 + "','" + DonhangID + "','" + barcode + "','" + SPLoi + "','" + txtSPLoi2.Text + "','" + modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                }

                if (DBAccess.IsServerConnected())
                {
                    //bool isExisted = DBHelper.CheckItemExist("Order", "DonhangID", DonhangID);

                    //if (!isExisted)
                    //{
                    if (InsertItemQryList.Count > 0)
                    {
                        foreach (var item in InsertItemQryList)
                        {
                            isSuccess = DBAccess.ExecuteQuery(item);
                        }

                        if (isSuccess)
                        {
                            SaveOrderToTransactionDB(barcode, BTPChuaIn, "", txtChuaIn2.Text, "false", "false");
                            SaveOrderToTransactionDB(barcode, BTPDaIn, "", txtDaIn2.Text, "false", "false");
                            SaveOrderToTransactionDB(barcode, TP, "", txtTP2.Text, "false", "false");
                            SaveOrderToTransactionDB(barcode, SPLoi, "", txtSPLoi2.Text, "false", "false");

                            dtTab1Input.Rows.InsertAt(rd, 0);
                            cbCustomer.SelectedIndex = 0;
                            currentPageNumber = 1;
                            countPageSize(dtTab1Input);
                            ClearText();
                            // Update datalist
                            PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Input);
                            MessageBox.Show("Thêm Mới Thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Barcode da ton tai : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string orderID = txtOrder2.Text;
            string query;
            bool isSuccess = false;
            List<string> DeleteItemQryList = new List<string>();
            if (!string.IsNullOrEmpty(orderID))
            {
                query = "DELETE FROM[OrderDetail] WHERE DonhangID = '" + orderID + "'";
                DeleteItemQryList.Add(query);
                query = "DELETE FROM [Order] WHERE DonhangID ='" + orderID + "';";
                DeleteItemQryList.Add(query);
                if (DBAccess.IsServerConnected())
                {
                    DataRow row = dtTab1Input.Select("[Mã Đơn Hàng]=" + orderID, "[Mã Đơn Hàng]").FirstOrDefault();

                    if (query.Length > 5)
                    {
                        bool isExisted = DBHelper.CheckItemExist("[Order]", "DonhangID", orderID);

                        if (isExisted)
                        {
                            foreach (var item in DeleteItemQryList)
                            {
                                isSuccess = DBAccess.ExecuteQuery(item);
                            }
                            if (isSuccess)
                            {
                               
                                currentPageNumber = 1;
                                dtTab1Input.Rows.Remove(row);
                                countPageSize(dtTab1Input);
                                ClearText();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Input);
                                MessageBox.Show("Xóa Đơn Hàng Thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                            
                        }
                        else
                        {
                            MessageBox.Show("Mã đơn hàng này không tồn tại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }

        private void GetAllDataOrderInput()
        {
            string query = "Select New.DonhangID [Mã Đơn Hàng], Customer.HoTen [Tên Khách Hàng], Product.Kyhieu [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi], [New].Ngaysua [Ngày], [Order].Xong  from (SELECT DonhangID, Barcode, Ngaysua, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Customer on[Order].KHID = Customer.KHID where [Order].Xong = 0 order by New.Ngaysua;";
            dtTab1Input = new DataTable();
            using (SqlCeConnection connection = new SqlCeConnection(conn))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtTab1Input.Merge(dt);
                }
            }
            int rowCount = dtTab1Input.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            lblTotalPage.Text = "Tổng số:" + dtTab1Input.Rows.Count.ToString();
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }
        private void PopulateDataOrder(int currentPageNumber, int rowPerPage, DataTable dt)
        {
            int skipRecord = (currentPageNumber - 1) * rowPerPage;
            if (tbNewOrder.SelectedIndex == 0)
            {
                if (rbNhap.Checked)
                {
                    if (dt.Rows.Count > 0)
                    {
                        dgvOrder2.DataSource = dt.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();
                        dgvOrder2.Columns["Nhà Cung Cấp"].Width = 120;
                        dgvOrder2.Columns["Ký Hiệu"].Width = 60;
                        dgvOrder2.Columns["BTP Chưa in"].Width = 60;
                        dgvOrder2.Columns["BTP Đã in"].Width = 60;
                        dgvOrder2.Columns["Thành Phẩm"].Width = 60;
                        dgvOrder2.Columns["Sản phẩm lỗi"].Width = 60;
                        dgvOrder2.Columns["Xong"].Width = 50;
                        dgvOrder2.Sort(dgvOrder2.Columns["Ngày"], ListSortDirection.Descending);
                    }
                    else
                    {
                        dgvOrder2.DataSource = dt;
                    }
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        dgvOrder1.DataSource = dt.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();
                        dgvOrder1.Columns["Tên Khách Hàng"].Width = 120;
                        dgvOrder1.Columns["Ký Hiệu"].Width = 60;
                        dgvOrder1.Columns["BTP Chưa in"].Width = 60;
                        dgvOrder1.Columns["BTP Đã in"].Width = 60;
                        dgvOrder1.Columns["Thành Phẩm"].Width = 60;
                        dgvOrder1.Columns["Sản phẩm lỗi"].Width = 60;
                        dgvOrder1.Columns["Xong"].Width = 50;
                    }
                }
            }
            else
            {
                dvgManageInOut.DataSource = dtOrderNotDone.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();
                
            }
            
        }             
        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dgvOrder1.Rows[e.RowIndex];
                txtOrder2.Text = dgvRow.Cells[0].Value.ToString();
                txtChuaIn2.Text = dgvRow.Cells[3].Value.ToString();
                txtDaIn2.Text = dgvRow.Cells[4].Value.ToString();
                txtTP2.Text = dgvRow.Cells[5].Value.ToString();
                txtSPLoi2.Text = dgvRow.Cells[6].Value.ToString();
                cbCustomer.SelectedValue = DBHelper.Lookup("Customer", "KHID", "HoTen", dgvRow.Cells[1].Value.ToString());
                cbCustomer.Text = dgvRow.Cells[1].Value.ToString();
                cbCustomer.Enabled = false;

                cbKihieu1.SelectedValue = DBHelper.Lookup("Product", "Barcode", "Kyhieu", dgvRow.Cells[2].Value.ToString());
                cbKihieu1.Text = dgvRow.Cells[2].Value.ToString();


                btnAdd1.Visible = false;
                btnUpdate.Visible = true;
                if(e.ColumnIndex != -1)
                {
                    if (dgvOrder1.Columns[e.ColumnIndex].Name == "Xong")
                    {
                        btnXong.Enabled = true;
                    }
                }
                
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> UpdateItemQryList = new List<string>();
                DataTable dtItem = (DataTable)(dgvOrder2.DataSource);
                string DonhangID, barcode, BTPChuaIn, BTPDaIn, TP, SPLoi, createDate, modifyDate;
                string UpdateItemQry = "";
                bool isSuccess = false;
                int count = 0;
                var csv = new StringBuilder();
                // DonhangID
                DonhangID = txtOrder2.Text;
                DataRow row = dtTab1Input.Select("[Mã Đơn Hàng]=" + DonhangID, "[Mã Đơn Hàng]").FirstOrDefault();

                // Set value for number field
                if (string.IsNullOrEmpty(txtChuaIn2.Text)) txtChuaIn2.Text = "0";
                if (string.IsNullOrEmpty(txtDaIn2.Text)) txtDaIn2.Text = "0";
                if (string.IsNullOrEmpty(txtTP2.Text)) txtTP2.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoi2.Text)) txtSPLoi2.Text = "0";
                // Barcode
                barcode = cbKihieu2.SelectedValue.ToString();
                row[2] = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                // BTPChuaIn
                BTPChuaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                row[3] = txtChuaIn2.Text;
                // BTPDaIn
                BTPDaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                row[4] = txtDaIn2.Text;
                // TP
                TP = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                row[5] = txtTP2.Text;
                // SPLoi
                SPLoi = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                row[6] = txtSPLoi2.Text;
                // Modify Date
                modifyDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                row[7] = modifyDate;

                if (barcode != "")
                {
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtChuaIn2.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + BTPChuaIn + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtDaIn2.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + BTPDaIn + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtTP2.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + TP + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtSPLoi2.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + SPLoi + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                }

                if (DBAccess.IsServerConnected())
                {
                    bool isExisted = DBHelper.CheckItemExist("[Order]", "DonhangID", DonhangID);

                    if (isExisted)
                    {
                        if (UpdateItemQry.Length > 5)
                        {
                            foreach (var item in UpdateItemQryList)
                            {
                                isSuccess = DBAccess.ExecuteQuery(item);
                            }

                            if (isSuccess)
                            {
                                SaveOrderToTransactionDB(barcode, BTPChuaIn, "", txtChuaIn2.Text, "false", "false");
                                SaveOrderToTransactionDB(barcode, BTPDaIn, "", txtDaIn2.Text, "false", "false");
                                SaveOrderToTransactionDB(barcode, TP, "", txtTP2.Text, "false", "false");
                                SaveOrderToTransactionDB(barcode, SPLoi, "", txtSPLoi2.Text, "false", "false");
                                
                                currentPageNumber = 1;
                                countPageSize(dtTab1Input);
                                ClearText();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Input);
                                MessageBox.Show("Nhập Đơn Hàng Thành công!" + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đơn Hàng Này Chưa Tồn Tại!" + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private void pbFirst_Click(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            dtCurrent = dtTab1Output;
            PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            dtCurrent = dtTab1Output;
            if (currentPageNumber > 1)
            {
                currentPageNumber -= 1;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
            }
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            dtCurrent = dtTab1Output;
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            dtCurrent = dtTab1Input;
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }
        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPageSize.SelectedItem);
            currentPageNumber = 1;
            PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void countPageSize(DataTable dt)
        {
            int rowCount = dt.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            lblTotalPage.Text = "Tổng số:" + dt.Rows.Count.ToString();
        }

        private void ClearText()
        {
            btnAdd1.Visible = true;
            btnSave2.Visible = true;
            btnUpdate.Visible = false;
            btnUpdate1.Visible = false;
            txtOrderID1.Text = string.Empty;
            cbCustomer.SelectedIndex = 0;
            cbKihieu2.SelectedIndex = 0;
            cbNhacc.Enabled = true;
            cbKihieu2.SelectedIndex = 1;
            txtBTPChuaIn1.Text = string.Empty;
            txtBTPDaIn1.Text = string.Empty;
            txtTP1.Text = string.Empty;
            txtSPLoi1.Text = string.Empty;
            txtChuaIn2.Text = string.Empty;
            txtDaIn2.Text = string.Empty;
            txtTP2.Text = string.Empty;
            txtSPLoi2.Text = string.Empty;
            //txtQuantity.Text = string.Empty;
        }
        /******************************** End Panel 1 ******************************************/



        /******************************** Start Panel 2******************************************/
        private void btnXong_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> UpdateItemQryList = new List<string>();
                string UpdateItemQry = string.Empty;
                bool isSuccess = false;
                string DonhangID, Barcode, BTPChuaInID, BTPDaInID, TPID, SPLoiID,BTPChuaIn, BTPDaIn, TP, SPLoi;
                DonhangID = Barcode = BTPChuaInID = BTPDaInID = TPID = SPLoiID = BTPChuaIn = BTPDaIn = TP = SPLoi = string.Empty;
                DataRow row;
                int count = 0;
                var csv = new StringBuilder();

                // BTPChuaIn
                BTPChuaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                // BTPDaIn
                BTPDaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                // TP
                TPID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                // SPLoi
                SPLoiID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");

                if (rbXuat.Checked)
                {
                    DonhangID = txtOrder2.Text;
                    row = dtTab1Input.Select("[Mã Đơn Hàng]=" + DonhangID, "[Mã Đơn Hàng]").FirstOrDefault();
                    Barcode = cbKihieu2.SelectedValue.ToString();
                    // Convert soluong to negative
                    BTPChuaIn = "-" + txtChuaIn2.Text;
                    BTPDaIn = "-" + txtDaIn2.Text;
                    TP = "-" + txtTP2.Text;
                    SPLoi = "-" + txtSPLoi2.Text;
                    SaveOrderToTransactionDB(Barcode, BTPChuaInID, "", txtChuaIn2.Text, "true", "false");
                    SaveOrderToTransactionDB(Barcode, BTPDaIn, "", txtDaIn2.Text, "true", "false");
                    SaveOrderToTransactionDB(Barcode, TPID, "", txtTP2.Text, "true", "false");
                    SaveOrderToTransactionDB(Barcode, SPLoiID, "", txtSPLoi2.Text, "true", "false");
                }
                else
                {
                    DonhangID = txtOrderID1.Text;
                    row = dtTab1Output.Select("[Mã Đơn Hàng]=" + DonhangID, "[Mã Đơn Hàng]").FirstOrDefault();
                    Barcode = cbKihieu1.SelectedValue.ToString();
                    BTPChuaIn = txtBTPChuaIn1.Text;
                    BTPDaIn = txtBTPDaIn1.Text;
                    TP = txtTP1.Text;
                    SPLoi = txtSPLoi1.Text;
                    SaveOrderToTransactionDB(Barcode, BTPChuaInID, "", txtBTPChuaIn1.Text, "true", "false");
                    SaveOrderToTransactionDB(Barcode, BTPDaIn, "", txtBTPDaIn1.Text, "true", "false");
                    SaveOrderToTransactionDB(Barcode, TPID, "", txtTP1.Text, "true", "false");
                    SaveOrderToTransactionDB(Barcode, SPLoiID, "", txtSPLoi1.Text, "true", "false");
                }
                

                string modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

                string TonkhoID1 = CommonHelper.RandomString(7) + 1;
                string TonkhoID2 = CommonHelper.RandomString(7) + 2;
                string TonkhoID3 = CommonHelper.RandomString(7) + 3;
                string TonkhoID4 = CommonHelper.RandomString(7) + 4;

                UpdateItemQry = "UPDATE[Order] SET [Xong] = 1";
                UpdateItemQryList.Add(UpdateItemQry);
                UpdateItemQry = "INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Soluongcon],[Ngaytao])VALUES('" + TonkhoID1 + "','" + Barcode + "','" + BTPChuaInID + "','" + BTPChuaIn + "','" + modifyDate + "')";
                UpdateItemQryList.Add(UpdateItemQry);
                UpdateItemQry = "INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Soluongcon],[Ngaytao])VALUES('" + TonkhoID2 + "','" + Barcode + "','" + BTPDaInID + "','" + BTPDaIn + "','" + modifyDate + "')";
                UpdateItemQryList.Add(UpdateItemQry);
                UpdateItemQry = "INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Soluongcon],[Ngaytao])VALUES('" + TonkhoID3 + "','" + Barcode + "','" + TPID + "','" + TP + "','" + modifyDate + "')";
                UpdateItemQryList.Add(UpdateItemQry);
                UpdateItemQry = "INSERT INTO [Stock] ([TonkhoID],[Barcode],[LoaiID],[Soluongcon],[Ngaytao])VALUES('" + TonkhoID4 + "','" + Barcode + "','" + SPLoiID + "','" + SPLoi + "','" + modifyDate + "')";
                UpdateItemQryList.Add(UpdateItemQry);

                
                if (DBAccess.IsServerConnected())
                {
                    bool isExisted = DBHelper.CheckItemExist("[Order]", "DonhangID", DonhangID);

                    if (isExisted)
                    {
                        if (UpdateItemQry.Length > 5)
                        {
                            foreach (var item in UpdateItemQryList)
                            {
                                isSuccess = DBAccess.ExecuteQuery(item);
                            }
                            


                            if (isSuccess)
                            {
                                if (rbXuat.Checked)
                                {
                                    currentPageNumber = 1;
                                    dtTab1Input.Rows.Remove(row);
                                    countPageSize(dtTab1Input);
                                    PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Input);
                                   
                                }
                                else
                                {
                                    currentPageNumber = 1;
                                    dtTab1Output.Rows.Remove(row);
                                    countPageSize(dtTab1Output);
                                    PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Output);
                                    
                                }
                                ClearText();
                                // Update datalist
                                
                                MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đơn hàng này chưa tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }


        }
        private void btnDelete1_Click(object sender, EventArgs e)
        {
            //DBModel modelWhere = new DBModel();
            string orderID = txtOrderID1.Text;
            string query;
            bool isSuccess = false;
            List<string> DeleteItemQryList = new List<string>();
            if (!string.IsNullOrEmpty(orderID))
            {
                query = "DELETE FROM[OrderDetail] WHERE DonhangID = '" + orderID + "'";
                DeleteItemQryList.Add(query);
                query = "DELETE FROM [Order] WHERE DonhangID ='" + orderID + "';";
                DeleteItemQryList.Add(query);
                if (DBAccess.IsServerConnected())
                {
                    // Barcode
                    // modelWhere.text = "DonhangID";
                    //modelWhere.value = orderID;
                    //modelWhere.type = "string";
                    DataRow row = dtTab1Output.Select("[Mã Đơn Hàng]=" + orderID, "[Mã Đơn Hàng]").FirstOrDefault();
                    
                    if (query.Length > 5)
                    {
                        bool isExisted = DBHelper.CheckItemExist("[Order]", "DonhangID", orderID);

                        if (isExisted)
                        {
                            foreach (var item in DeleteItemQryList)
                            {
                                isSuccess = DBAccess.ExecuteQuery(item);
                            }
                            if (isSuccess)
                            {
                                //dtTab1Output = DBHelper.DeleteDatatable(dtTab1Output, modelWhere);
                                currentPageNumber = 1;
                                dtTab1Output.Rows.Remove(row);
                                countPageSize(dtTab1Output);
                               
                                ClearText();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Output);
                                MessageBox.Show("Số sản phẩm đã nhập Thành công: ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                            
                        }
                        else
                        {
                            MessageBox.Show("Đơn hàng này chưa tồn tại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }
        private void txtQuantity1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                List<DBModel> dbModels = new List<DBModel>();
                DataTable dtItem = (DataTable)(dgvOrder2.DataSource);
                string IsCompleted = "false";
                string DonhangID, barcode, BTPChuaIn, BTPDaIn, TP, SPLoi, NhaccID, modifyDate;
                List<string> InsertItemQryList = new List<string>();
                string InsertItemQry = "";
                bool isSuccess = false;
                int count = 0;
                DataRow rd = dtTab1Output.NewRow();
                

                // Set value for number field
                if (string.IsNullOrEmpty(txtBTPChuaIn1.Text)) txtBTPChuaIn1.Text = "0";
                if (string.IsNullOrEmpty(txtBTPDaIn1.Text)) txtBTPDaIn1.Text = "0";
                if (string.IsNullOrEmpty(txtTP1.Text)) txtTP1.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoi1.Text)) txtSPLoi1.Text = "0";

                // DonhangID
                DonhangID = CommonHelper.RandomString(8);
                rd[0] = DonhangID;
                // NhaccID
                NhaccID = cbNhacc.SelectedValue.ToString();
                rd[1] = DBHelper.Lookup("Supplier", "Ten", "NhaccID", NhaccID);

                // Barcode
                barcode = cbKihieu2.SelectedValue.ToString();
                rd[2] = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                // BTPChuaIn
                BTPChuaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                rd[3] = txtBTPChuaIn1.Text;
                // BTPDaIn
                BTPDaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                rd[4] = txtBTPDaIn1.Text;
                // TP
                TP = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                rd[5] = txtTP1.Text;
                // SPLoi
                SPLoi = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                rd[6] = txtSPLoi1.Text;
                
                // Created Date
                modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                rd[7] = modifyDate;
                // Xong
                rd[8] = IsCompleted;


                string orderDetailID1 = CommonHelper.RandomString(7)+1;
                string orderDetailID2 = CommonHelper.RandomString(7)+2;
                string orderDetailID3 = CommonHelper.RandomString(7)+3;
                string orderDetailID4 = CommonHelper.RandomString(7)+4;
                if (barcode != "")
                {
                    InsertItemQry = "INSERT INTO [Order] ([DonhangID],[NhaccID],[Xong],[Ngaytao],[Ngaysua])VALUES('" + DonhangID + "','" + NhaccID + "','" + IsCompleted + "','" + modifyDate + "','" + modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                    InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID1 + "','" + DonhangID + "','" + barcode + "','" + BTPChuaIn + "','" + txtBTPChuaIn1.Text + "','"  +  modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                    InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID2 + "','" + DonhangID + "','" + barcode + "','" + BTPDaIn + "','" + txtBTPDaIn1.Text  + "','" +  modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                    InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID3 + "','" + DonhangID + "','" + barcode + "','" + TP + "','" + txtTP1.Text +  "','" +  modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                    InsertItemQry = "INSERT INTO [OrderDetail] ([OrderDetailID],[DonhangID],[Barcode],[LoaiID],[Soluong],[Ngaysua])VALUES('" + orderDetailID4 + "','" + DonhangID + "','" + barcode + "','" +SPLoi + "','" + txtSPLoi1.Text +  "','" +  modifyDate + "')";
                    InsertItemQryList.Add(InsertItemQry);
                }

                if (DBAccess.IsServerConnected())
                {
                    //bool isExisted = DBHelper.CheckItemExist("Order", "DonhangID", DonhangID);

                    //if (!isExisted)
                    //{
                        if (InsertItemQryList.Count > 0)
                        {
                            foreach (var item in InsertItemQryList)
                            {
                                isSuccess = DBAccess.ExecuteQuery(item);
                            }
                            
                            if (isSuccess)
                            {
                            SaveOrderToTransactionDB(barcode, BTPChuaIn, "", txtBTPChuaIn1.Text, "true", "false");
                            SaveOrderToTransactionDB(barcode, BTPDaIn, "", txtBTPDaIn1.Text, "true", "false");
                            SaveOrderToTransactionDB(barcode, TP, "", txtTP1.Text, "true", "false");
                            SaveOrderToTransactionDB(barcode, SPLoi, "", txtSPLoi1.Text, "true", "false");

                            dtTab1Output.Rows.InsertAt(rd, 0);
                            //dtTab1Output = DBHelper.InsertDatatable(dtTab1Output, dbModels);
                                cbNhacc.SelectedIndex = 0;
                            currentPageNumber = 1;
                                countPageSize(dtTab1Output);
                                ClearText();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Output);
                                MessageBox.Show("Đơn hàng này đã thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Barcode da ton tai : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        

        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            try
            {
                //List<DBModel> dbModelsUpdate = new List<DBModel>();
                //DBModel itemModelUpdate = new DBModel();
                //List<DBModel> dbModelsLookupList = new List<DBModel>();
                //DBModel itemModelLookup = new DBModel();
                //DBModel modelWhere = new DBModel();
                List<string> UpdateItemQryList = new List<string>();
                DataTable dtItem = (DataTable)(dgvOrder2.DataSource);
                string DonhangID, barcode, BTPChuaIn, BTPDaIn, TP, SPLoi, createDate, modifyDate;
                string UpdateItemQry = "";
                bool isSuccess = false;
                int count = 0;

                // DonhangID
                DonhangID = txtOrderID1.Text;
                DataRow row = dtTab1Output.Select("[Mã Đơn Hàng]=" + DonhangID, "[Mã Đơn Hàng]").FirstOrDefault();
                
                // Set value for number field
                if (string.IsNullOrEmpty(txtBTPChuaIn1.Text)) txtBTPChuaIn1.Text = "0";
                if (string.IsNullOrEmpty(txtBTPDaIn1.Text)) txtBTPDaIn1.Text = "0";
                if (string.IsNullOrEmpty(txtTP1.Text)) txtTP1.Text = "0";
                if (string.IsNullOrEmpty(txtSPLoi1.Text)) txtSPLoi1.Text = "0";

                
                //modelWhere.text = "DonhangID";
                //modelWhere.type = "string";
                //modelWhere.value = DonhangID;

                // Barcode
                barcode = cbKihieu2.SelectedValue.ToString();
                //itemModelLookup.text = "DonhangID";
                //itemModelLookup.value = DonhangID;
                //dbModelsLookupList.Add(itemModelLookup);
                //itemModelUpdate.text = "Kyhieu";
                //itemModelUpdate.value = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                //itemModelUpdate.type = "string";
                //dbModelsUpdate.Add(itemModelUpdate);
                row[2]= DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                // BTPChuaIn
                //itemModelUpdate = new DBModel();
                BTPChuaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                //itemModelUpdate.text = "BTP Chưa in";
                //itemModelUpdate.type = "int";
                //itemModelUpdate.value = txtBTPChuaIn1.Text;
                //dbModelsUpdate.Add(itemModelUpdate);
                row[3]= txtBTPChuaIn1.Text;
                // BTPDaIn
                //itemModelUpdate = new DBModel();
                BTPDaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                //itemModelUpdate.text = "BTP Đã in";
                //itemModelUpdate.type = "int";
                //itemModelUpdate.value = txtBTPDaIn1.Text;
                //dbModelsUpdate.Add(itemModelUpdate);
                row[4]= txtBTPDaIn1.Text;
                // TP
                //itemModelUpdate = new DBModel();
                TP = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                //itemModelUpdate.text = "Thành Phẩm";
                //itemModelUpdate.type = "int";
                //itemModelUpdate.value = txtTP1.Text;
                //dbModelsUpdate.Add(itemModelUpdate);
                row[5] = txtTP1.Text;
                // SPLoi
                //itemModelUpdate = new DBModel();
                SPLoi = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                //itemModelUpdate.text = "Sản phẩm lỗi";
                //itemModelUpdate.type = "int";
                //itemModelUpdate.value = txtSPLoi1.Text;
                //dbModelsUpdate.Add(itemModelUpdate);
                row[6] = txtSPLoi1.Text;
                // Modify Date
                //itemModelUpdate = new DBModel();
                modifyDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                //itemModelUpdate.text = "Ngaysua";
                //itemModelUpdate.value = modifyDate;
                //itemModelUpdate.type = "datetime";

                //dbModelsUpdate.Add(itemModelUpdate);
                row[7] = modifyDate;


                if (barcode != "")
                {
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtBTPChuaIn1.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='"+ BTPChuaIn + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtBTPDaIn1.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + BTPDaIn + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtTP1.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + TP + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                    UpdateItemQry = "UPDATE[OrderDetail] SET [Barcode] = '" + barcode + "',[Soluong]= '" + txtSPLoi1.Text + "',[Ngaysua]= '" + modifyDate + "' WHERE DonhangID ='" + DonhangID + "' AND LoaiID='" + SPLoi + "';";
                    UpdateItemQryList.Add(UpdateItemQry);
                }

                if (DBAccess.IsServerConnected())
                {
                    bool isExisted = DBHelper.CheckItemExist("[Order]", "DonhangID", DonhangID);

                    if (isExisted)
                    {
                        if (UpdateItemQry.Length > 5)
                        {
                            foreach (var item in UpdateItemQryList)
                            {
                                isSuccess = DBAccess.ExecuteQuery(item);
                            }

                            if (isSuccess)
                            {
                                //dtTab1Output.Rows.InsertAt(row, 0);
                                SaveOrderToTransactionDB(barcode, BTPChuaIn, "", txtBTPChuaIn1.Text, "true", "false");
                                SaveOrderToTransactionDB(barcode, BTPDaIn, "", txtBTPDaIn1.Text, "true", "false");
                                SaveOrderToTransactionDB(barcode, TP, "", txtTP1.Text, "true", "false");
                                SaveOrderToTransactionDB(barcode, SPLoi, "", txtSPLoi1.Text, "true", "false");
                                //dtTab1Output = DBHelper.UpdateDatatable(dtTab1Output, modelWhere, dbModelsUpdate);
                                currentPageNumber = 1;
                                countPageSize(dtTab1Output);
                                ClearText();
                                
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Output);
                                
                                MessageBox.Show("Sửa đơn hàng này thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đơn hàng này chưa tồn tại!" + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Đang Hoàn Thiện Hệ Thống!");
            }
        }

        private void GetAllDataOrderOutput()
        {
            string query = "Select New.DonhangID [Mã Đơn Hàng], Supplier.Ten [Nhà Cung Cấp], Product.Kyhieu [Ký Hiệu], New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi], New.Ngaysua [Ngày] ,[Order].Xong  from (SELECT DonhangID, Barcode, Ngaysua, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaysua) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Supplier on[Order].NhaccID = Supplier.NhaccID where[Order].Xong = 0 order by New.Ngaysua";
            dtTab1Output = new DataTable();
            using (SqlCeConnection connection = new SqlCeConnection(conn))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtTab1Output.Merge(dt);
                }
            }
            int rowCount = dtTab1Output.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            lblTotalPage.Text = "Tổng số:" + dtTab1Output.Rows.Count.ToString();
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }
 
        private void dgvOrder2_FilterStringChanged(object sender, EventArgs e)
        {
            ADGV.AdvancedDataGridView fdgv = dgvOrder2;
            DataTable dt = null;
            if (OrignalADGVdt == null)
            {
                OrignalADGVdt = (DataTable)fdgv.DataSource;
            }
            else
            {
                int row = OrignalADGVdt.Rows.Count;
                fdgv.DataSource = OrignalADGVdt;
            }
            if (fdgv.FilterString.Length > 0)
            {
                dt = (DataTable)fdgv.DataSource;
            }
            else//Clear Filter
            {
                dt = OrignalADGVdt;
            }

            fdgv.DataSource = dt.Select(fdgv.FilterString).CopyToDataTable();
        }

        private void dgvOrder2_SortStringChanged(object sender, EventArgs e)
        {
            ADGV.AdvancedDataGridView fdgv = dgvOrder2;
            if (fdgv.SortString.Length == 0)
            {
                return;
            }
            string[] strtok = fdgv.SortString.Split(',');
            currentOrderByItem = String.Join(",", strtok);
            foreach (string str in strtok)
            {
                string[] columnorder = str.Split(']');
                ListSortDirection lds = ListSortDirection.Ascending;
                if (columnorder[1].Trim().Equals("DESC"))
                {
                    lds = ListSortDirection.Descending;
                }
                dgvOrder2.Sort(dgvOrder2.Columns[columnorder[0].Replace('[', ' ').Trim()], lds);
            }
        }

        private void dgvOrder2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dgvOrder2.Rows[e.RowIndex];
                txtOrderID1.Text= dgvRow.Cells[0].Value.ToString();
                txtBTPChuaIn1.Text = dgvRow.Cells[3].Value.ToString();
                txtBTPDaIn1.Text = dgvRow.Cells[4].Value.ToString();
                txtTP1.Text = dgvRow.Cells[5].Value.ToString();
                txtSPLoi1.Text = dgvRow.Cells[6].Value.ToString();
                cbNhacc.SelectedValue = DBHelper.Lookup("Supplier", "NhaccID", "Ten", dgvRow.Cells[1].Value.ToString());
                cbNhacc.Text = dgvRow.Cells[1].Value.ToString();
                cbNhacc.Enabled = false;

                cbKihieu1.SelectedValue = DBHelper.Lookup("Product", "Barcode", "Kyhieu", dgvRow.Cells[2].Value.ToString());
                cbKihieu1.Text = dgvRow.Cells[2].Value.ToString();


                btnSave2.Visible = false;
                btnUpdate1.Visible = true;
                if(e.ColumnIndex != -1)
                {
                    if (dgvOrder2.Columns[e.ColumnIndex].Name == "Xong")
                    {
                        btnXong.Enabled = true;
                    }
                }
                
            }
            
        }

        /********************************End Panel 2******************************************/

        private void GetAllOrder()
        {
            string query = "select * from (select[order].donhangid [Mã Đơn Hàng], barcode [Barcode], SUM(CASE WHEN LoaiID = 0000001 AND[order].NhacciD is not null Then Soluong else 0 end)[Nhap BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhap BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhap Thành Phẩm],SUM(CASE WHEN LoaiID = 000004 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhap Sản phẩm lỗi],SUM(CASE WHEN LoaiID = 0000001 AND[order].KHID is not null Then Soluong else 0 end)[Xuat BTP Chưa in],SUM(CASE WHEN LoaiID = 0000002 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuat BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuat Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuat Sản phẩm lỗi], [order].ngaysua from orderdetail join [order] on orderdetail.donhangid = [order].donhangid GROUP BY[order].donhangid, Barcode,[order].ngaysua) New order by New.ngaysua;";
            dtManageInOut = new DataTable();
            using (SqlCeConnection connection = new SqlCeConnection(conn))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dtManageInOut.Merge(dt);
                }
            }
            int rowCount = dtManageInOut.Rows.Count;
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            lblTotalPage1.Text = "Tổng số:" + dtManageInOut.Rows.Count.ToString();
            txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void PopulateDataOrderInOut(int currentPageNumber, int rowPerPage, DataTable dt)
        {
            int skipRecord = (currentPageNumber - 1) * rowPerPage;

            if (dt.Rows.Count > 0)
            {
                dvgManageInOut.DataSource = dt.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();
            }
            else
            {
                dvgManageInOut.DataSource = dt;
            }


        }
        private void pbFirst1_Click(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtManageInOut);
            txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbPrev1_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 0)
            {
                currentPageNumber -= 1;
                PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtManageInOut);
            }
            txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbNext1_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtManageInOut);
                txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLast1_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtManageInOut);
                txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void tbNewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbNewOrder.SelectedIndex)
            {
                case 0:
                    { GetAllDataTab1(); }
                    break;
                case 1:
                    {
                        currentPageNumber = 1;
                        rowPerPage = 10;
                        GetAllOrder();
                        PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtManageInOut);
                        cbPageSize1.SelectedItem = "10";
                    }
                    break;
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
            try
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
                worksheet.Name = "CHI TIẾT XUẤT NHẬP";
                // storing header part in Excel  
                var columnHeadingsRangeIn = worksheet.Range[worksheet.Cells[1, 5], worksheet.Cells[1, 8]];
                columnHeadingsRangeIn.Interior.Color = XlRgbColor.rgbPaleVioletRed;
                var columnHeadingsRangeOut = worksheet.Range[worksheet.Cells[1, 9], worksheet.Cells[1, 12]];
                columnHeadingsRangeOut.Interior.Color = XlRgbColor.rgbBlueViolet;
                for (int i = 0; i < dtManageOrderNew.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dtManageOrderNew.Columns[i].ToString();
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dtManageOrderNew.Rows.Count; i++)
                {
                    for (int j = 0; j < dtManageOrderNew.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dtManageOrderNew.Rows[i][j].ToString();
                    }
                }
                // save the application  
                workbook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Quit();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public System.Data.DataTable ExportToExcel()
        {
            dtManageOrderNew = new DataTable();
            dtManageOrderNew.Columns.Add("STT", typeof(int));
            dtManageOrderNew.Columns.Add("NGÀY", typeof(string));
            dtManageOrderNew.Columns.Add("KÝ HIỆU", typeof(string));
            dtManageOrderNew.Columns.Add("MÃ HÀNG", typeof(string));
            dtManageOrderNew.Columns.Add("NHẬP BTP Chưa in ", typeof(string));
            dtManageOrderNew.Columns.Add("NHẬP BTP Đã in ", typeof(string));
            dtManageOrderNew.Columns.Add("NHẬP Thành Phẩm ", typeof(string));
            dtManageOrderNew.Columns.Add("NHẬP SP Lỗi ", typeof(string));
            dtManageOrderNew.Columns.Add("XUẤT BTP Chưa in ", typeof(string));
            dtManageOrderNew.Columns.Add("XUẤT BTP Đã in ", typeof(string));
            dtManageOrderNew.Columns.Add("XUẤT Thành Phẩm ", typeof(string));
            dtManageOrderNew.Columns.Add("XUẤT SP Lỗi ", typeof(string));
            dtManageOrderNew.Columns.Add("GHI CHÚ", typeof(string));

            DataRow row;
            string ngay, kyhieu, masp, nhapbtpchuain, nhapbtpdain, nhaptp, nhapsploi, xuatbtpchuain, xuatbtpdain, xuattp, xuatsploi,ghichu;
            for (int i = 0; i < dtManageInOut.Rows.Count; i++)
            {
                ngay = DateTime.Parse(dtManageInOut.Rows[i][10].ToString()).ToString("dd/MM/yyy");
                kyhieu = DBHelper.Lookup("Product","Kyhieu","Barcode",dtManageInOut.Rows[i][1].ToString());
                masp = DBHelper.Lookup("Product", "MaSP", "Barcode", dtManageInOut.Rows[i][1].ToString());
                nhapbtpchuain = dtManageInOut.Rows[i][2].ToString();
                nhapbtpdain = dtManageInOut.Rows[i][3].ToString();
                nhaptp = dtManageInOut.Rows[i][4].ToString();
                nhapsploi = dtManageInOut.Rows[i][5].ToString();
                xuatbtpchuain = dtManageInOut.Rows[i][6].ToString();
                xuatbtpdain = dtManageInOut.Rows[i][7].ToString();
                xuattp = dtManageInOut.Rows[i][8].ToString();
                xuatsploi = dtManageInOut.Rows[i][9].ToString();
                ghichu = "";
                dtManageOrderNew.Rows.Add(i + 1, ngay, kyhieu, masp, nhapbtpchuain, nhapbtpdain, nhaptp, nhapsploi, xuatbtpchuain, xuatbtpdain, xuattp, xuatsploi, ghichu);
            }
            return dtManageOrderNew;
        }

        private void txtBTPChuaIn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDaIn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSPLoi2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBTPDaIn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtChuaIn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SaveOrderToTransactionDB(string barcode, string LoaiID, string Mota, string soluong, string Nhap, string Xong)
        {
            DBModel modelWhere = new DBModel();
            bool isSuccess = false;
            string InsertItemQry;
            string TransID = CommonHelper.RandomString(8);
            string modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
            string createDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
            if (!string.IsNullOrEmpty(barcode))
            {
                InsertItemQry = "INSERT INTO [Transaction]([TransID],[Barcode],[LoaiID],[Mota],[Soluong],[Nhap],[Xong],[Ngaytao],[Ngaysua])VALUES('"+ TransID + "','" + barcode + "','"+LoaiID+"','"+Mota +"','" + soluong + "','" + Nhap + "','"+Xong+ "','" + createDate + "','" + modifyDate + "')";
                if (DBAccess.IsServerConnected())
                {

                    if (InsertItemQry.Length > 5)
                    {
                        bool isExisted = DBHelper.CheckItemExist("[Product]", "Barcode", barcode);

                        if (isExisted)
                        {
                                isSuccess = DBAccess.ExecuteQuery(InsertItemQry);
                        }
                        else
                        {
                            MessageBox.Show("Barcode chưa tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (dgvOrder2.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Ký Hiệu] like '{0}%' OR [Nhà Cung Cấp] like '{0}%'", txtSearch.Text);
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            (dgvOrder1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Ký Hiệu] like '{0}%' OR [Tên Khách Hàng] like '{0}%'", txtSearch2.Text);
        }

        private void cbPageSize1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPageSize1.SelectedItem);
            currentPageNumber = 1;
            PopulateDataOrderInOut(currentPageNumber, rowPerPage, dtManageInOut);
            txtPaging1.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }
    }
}
