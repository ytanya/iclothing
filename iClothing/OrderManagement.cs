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

namespace iClothing
{
    public partial class OrderManagement : UserControl
    {
        private DataTable dtTab1Input = new DataTable();
        private DataTable dtTab1Output = new DataTable();
        private DataTable dtCurrent = new DataTable();
        private DataTable OrignalADGVdt = null;
        private DataTable dtOrderNotDone = new DataTable();
        private DataTable dtTemp = new DataTable();
        private List<OrderStatus> orderStatusList = new List<OrderStatus>();
        private OrderStatus orderStatus = new OrderStatus();
        private int currentPageNumber = 1;
        private int pageSize = 1;
        private int rowPerPage = 10;
        private string currentOrderByItem = "Ngaytao";
        private int latestPanelBottom = 0;
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
                List<DBModel> dbModels = new List<DBModel>();
                DBModel itemModel = new DBModel();
                DataTable dtItem = (DataTable)(dgvOrder2.DataSource);
                string IsCompleted = "false";
                string DonhangID, barcode, BTPChuaIn, BTPDaIn, TP, SPLoi, KHID, modifyDate;
                List<string> InsertItemQryList = new List<string>();
                string InsertItemQry = "";
                bool isSuccess = false;
                int count = 0;
                var csv = new StringBuilder();
                // DonhangID
                DonhangID = CommonHelper.RandomString(8);
                itemModel.text = "DonhangID";
                itemModel.type = "string";
                itemModel.value = DonhangID;
                dbModels.Add(itemModel);
                // Barcode
                itemModel = new DBModel();
                barcode = cbKihieu2.SelectedValue.ToString();
                itemModel.text = "Kyhieu";
                itemModel.value = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                itemModel.type = "string";
                dbModels.Add(itemModel);
                // BTPChuaIn
                itemModel = new DBModel();
                BTPChuaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                itemModel.text = "BTP Chưa in";
                itemModel.type = "int";
                itemModel.value = txtChuaIn2.Text;
                dbModels.Add(itemModel);
                // BTPDaIn
                itemModel = new DBModel();
                BTPDaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                itemModel.text = "BTP Đã in";
                itemModel.type = "int";
                itemModel.value = txtDaIn2.Text;
                dbModels.Add(itemModel);
                // TP
                itemModel = new DBModel();
                TP = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                itemModel.text = "Thành Phẩm";
                itemModel.type = "int";
                itemModel.value = txtTP2.Text;
                dbModels.Add(itemModel);
                // SPLoi
                itemModel = new DBModel();
                SPLoi = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                itemModel.text = "Sản phẩm lỗi";
                itemModel.type = "int";
                itemModel.value = txtSPLoi2.Text;
                dbModels.Add(itemModel);
                // Xong
                itemModel = new DBModel();
                itemModel.text = "Xong";
                itemModel.type = "bool";
                itemModel.value = IsCompleted;
                dbModels.Add(itemModel);

                // KHID
                KHID = cbCustomer.SelectedValue.ToString();
                itemModel = new DBModel();
                itemModel.text = "HoTen";
                itemModel.type = "string";
                itemModel.value = DBHelper.Lookup("Customer", "HoTen", "KHID", KHID);
                dbModels.Add(itemModel);
                

                
                // Modify Date
                modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

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
                            dtTab1Input = DBHelper.InsertDatatable(dtTab1Input, dbModels);
                            cbNhacc.SelectedIndex = 0;
                            currentPageNumber = 1;
                            countPageSize(dtTab1Input);
                            ClearText();
                            // Update datalist
                            PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Input);
                            MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Exception " + ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBModel modelWhere = new DBModel();
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
                    modelWhere.text = "DonhangID";
                    modelWhere.value = orderID;
                    modelWhere.type = "string";

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
                                dtTab1Input = DBHelper.DeleteDatatable(dtTab1Input, modelWhere);
                                currentPageNumber = 1;
                                countPageSize(dtTab1Input);
                                ClearText();
                                
                            }
                            // Update datalist
                            PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Input);
                            MessageBox.Show("Số sản phẩm đã nhập Thành công: ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Barcode khong ton tai ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }

        private void GetAllDataOrderInput()
        {
            string query = "Select New.DonhangID, Customer.HoTen, Product.Kyhieu, New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi], [Order].Xong  from (SELECT DonhangID, Barcode, Ngaytao, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaytao) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Customer on[Order].KHID = Customer.KHID where [Order].Xong = 0 order by New.Ngaytao";
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
            lblTotalPage.Text = "Total rows:" + dtTab1Input.Rows.Count.ToString();
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
                        //dgvOrder2.Columns["Xong"].ReadOnly = true;
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
                        dgvOrder1.DataSource = dt;
                    }
                }
            }
            else
            {
                dvgChangeStatusOrder.DataSource = dtOrderNotDone.Rows.Cast<System.Data.DataRow>().Skip(skipRecord).Take(rowPerPage).CopyToDataTable();
                
            }
            
        }             
        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dgvOrder1.Rows[e.RowIndex];
                txtOrderID1.Text = dgvRow.Cells[0].Value.ToString();
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
                List<DBModel> dbModelsUpdate = new List<DBModel>();
                DBModel itemModelUpdate = new DBModel();
                List<DBModel> dbModelsLookupList = new List<DBModel>();
                DBModel itemModelLookup = new DBModel();
                DBModel modelWhere = new DBModel();
                List<string> UpdateItemQryList = new List<string>();
                DataTable dtItem = (DataTable)(dgvOrder2.DataSource);
                string DonhangID, barcode, BTPChuaIn, BTPDaIn, TP, SPLoi, createDate, modifyDate;
                string UpdateItemQry = "";
                bool isSuccess = false;
                int count = 0;
                var csv = new StringBuilder();
                // DonhangID
                DonhangID = txtOrderID1.Text;
                modelWhere.text = "DonhangID";
                modelWhere.type = "string";
                modelWhere.value = DonhangID;

                // Barcode
                barcode = cbKihieu1.SelectedValue.ToString();
                itemModelUpdate.text = "Kyhieu";
                itemModelUpdate.value = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                itemModelUpdate.type = "string";
                dbModelsUpdate.Add(itemModelUpdate);
                // BTPChuaIn
                itemModelUpdate = new DBModel();
                BTPChuaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                itemModelUpdate.text = "BTP Chưa in";
                itemModelUpdate.type = "int";
                itemModelUpdate.value = txtChuaIn2.Text;
                dbModelsUpdate.Add(itemModelUpdate);
                // BTPDaIn
                itemModelUpdate = new DBModel();
                BTPDaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                itemModelUpdate.text = "BTP Đã in";
                itemModelUpdate.type = "int";
                itemModelUpdate.value = txtDaIn2.Text;
                dbModelsUpdate.Add(itemModelUpdate);
                // TP
                itemModelUpdate = new DBModel();
                TP = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                itemModelUpdate.text = "Thành Phẩm";
                itemModelUpdate.type = "int";
                itemModelUpdate.value = txtTP2.Text;
                dbModelsUpdate.Add(itemModelUpdate);
                // SPLoi
                itemModelUpdate = new DBModel();
                SPLoi = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                itemModelUpdate.text = "Sản phẩm lỗi";
                itemModelUpdate.type = "int";
                itemModelUpdate.value = txtSPLoi2.Text;
                dbModelsUpdate.Add(itemModelUpdate);

                // Modify Date
                itemModelUpdate = new DBModel();
                modifyDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                itemModelUpdate.text = "Ngaysua";
                itemModelUpdate.value = modifyDate;
                itemModelUpdate.type = "datetime";

                dbModelsUpdate.Add(itemModelUpdate);


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
                                dtTab1Input = DBHelper.UpdateDatatable(dtTab1Input, modelWhere, dbModelsUpdate);
                                currentPageNumber = 1;
                                countPageSize(dtTab1Input);
                                ClearText();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Input);
                                MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Don hang nay da ton tai : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        private void pbFirst_Click(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 0)
            {
                currentPageNumber -= 1;
                PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
            }
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            currentPageNumber += 1;
            PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            currentPageNumber = pageSize;
            PopulateDataOrder(currentPageNumber, rowPerPage, dtCurrent);
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
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
            lblTotalPage.Text = "Total rows:" + dt.Rows.Count.ToString();
        }

        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(bmp, 0, 0);
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
            //txtQuantity.Text = string.Empty;
        }
        /******************************** End Panel 1 ******************************************/



        /******************************** Start Panel 2******************************************/
        private void btnXong_Click(object sender, EventArgs e)
        {
            try
            {
                List<DBModel> dbModelsUpdate = new List<DBModel>();
                DBModel itemModelUpdate = new DBModel();
                List<DBModel> dbModelsLookupList = new List<DBModel>();
                DBModel itemModelLookup = new DBModel();
                DBModel modelWhere = new DBModel();
                List<DBModel> dbModels = new List<DBModel>();
                DBModel itemModel = new DBModel();
                List<string> UpdateItemQryList = new List<string>();
                string UpdateItemQry = string.Empty;
                bool isSuccess = false;
                string DonhangID, Barcode, BTPChuaInID, BTPDaInID, TPID, SPLoiID,BTPChuaIn, BTPDaIn, TP, SPLoi;
                DonhangID = Barcode = BTPChuaInID = BTPDaInID = TPID = SPLoiID = BTPChuaIn = BTPDaIn = TP = SPLoi = string.Empty;

                int count = 0;
                var csv = new StringBuilder();
                // DonhangID
                DonhangID = txtOrderID1.Text;
                modelWhere.text = "DonhangID";
                modelWhere.type = "string";
                modelWhere.value = DonhangID;

                // Barcode
                Barcode = cbKihieu2.SelectedValue.ToString();

                if (rbXuat.Checked)
                {
                    // Convert soluong to negative
                    BTPChuaIn = "-" + txtChuaIn2.Text;
                    BTPDaIn = "-" + txtDaIn2.Text;
                    TP = "-" + txtTP2.Text;
                    SPLoi = "-" + txtSPLoi2.Text;
                }
                else
                {
                    BTPChuaIn = txtBTPChuaIn1.Text;
                    BTPDaIn = txtBTPDaIn1.Text;
                    TP = txtTP1.Text;
                    SPLoi = txtSPLoi1.Text;
                }
                // BTPChuaIn
                BTPChuaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                // BTPDaIn
                BTPDaInID = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                // TP
                TPID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                // SPLoi
                SPLoiID = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");

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
                                    dtTab1Output = DBHelper.DeleteDatatable(dtTab1Output, modelWhere);
                                    currentPageNumber = 1;
                                    countPageSize(dtTab1Output);
                                    PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Output);
                                }
                                else
                                {
                                    dtTab1Input = DBHelper.DeleteDatatable(dtTab1Input, modelWhere);
                                    currentPageNumber = 1;
                                    countPageSize(dtTab1Input);
                                    PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Input);
                                }
                                ClearText();
                                // Update datalist
                                
                                MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Don hang nay da ton tai : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }


        }
        private void btnDelete1_Click(object sender, EventArgs e)
        {
            DBModel modelWhere = new DBModel();
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
                    modelWhere.text = "DonhangID";
                    modelWhere.value = orderID;
                    modelWhere.type = "string";

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
                                dtTab1Output = DBHelper.DeleteDatatable(dtTab1Output, modelWhere);
                                currentPageNumber = 1;
                                countPageSize(dtTab1Output);
                                ClearText();
                                MessageBox.Show("Số sản phẩm đã nhập Thành công: ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            // Update datalist
                            PopulateDataOrder(currentPageNumber, rowPerPage,dtTab1Output);
                        }
                        else
                        {
                            MessageBox.Show("Barcode khong ton tai ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DBModel itemModel = new DBModel();
                DataTable dtItem = (DataTable)(dgvOrder2.DataSource);
                string IsCompleted = "false";
                string DonhangID, barcode, BTPChuaIn, BTPDaIn, TP, SPLoi, NhaccID, modifyDate;
                List<string> InsertItemQryList = new List<string>();
                string InsertItemQry = "";
                bool isSuccess = false;
                int count = 0;
                var csv = new StringBuilder();
                // DonhangID
                DonhangID = CommonHelper.RandomString(8);
                itemModel.text = "DonhangID";
                itemModel.type = "string";
                itemModel.value = DonhangID;
                dbModels.Add(itemModel);
                // Barcode
                itemModel = new DBModel();
                barcode = cbKihieu2.SelectedValue.ToString();
                itemModel.text = "Kyhieu";
                itemModel.value = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                itemModel.type = "string";
                dbModels.Add(itemModel);
                // BTPChuaIn
                itemModel = new DBModel();
                BTPChuaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                itemModel.text = "BTP Chưa in";
                itemModel.type = "int";
                itemModel.value = txtBTPChuaIn1.Text;
                dbModels.Add(itemModel);
                // BTPDaIn
                itemModel = new DBModel();
                BTPDaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                itemModel.text = "BTP Đã in";
                itemModel.type = "int";
                itemModel.value = txtBTPDaIn1.Text;
                dbModels.Add(itemModel);
                // TP
                itemModel = new DBModel();
                TP = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                itemModel.text = "Thành Phẩm";
                itemModel.type = "int";
                itemModel.value = txtTP1.Text;
                dbModels.Add(itemModel);
                // SPLoi
                itemModel = new DBModel();
                SPLoi = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                itemModel.text = "Sản phẩm lỗi";
                itemModel.type = "int";
                itemModel.value = txtSPLoi1.Text;
                dbModels.Add(itemModel);
                // Xong
                itemModel = new DBModel();
                itemModel.text = "Xong";
                itemModel.type = "bool";
                itemModel.value = IsCompleted;
                dbModels.Add(itemModel);

                // NhaccID
                NhaccID = cbNhacc.SelectedValue.ToString();
                itemModel = new DBModel();
                itemModel.text = "Ten";
                itemModel.type = "string";
                itemModel.value = DBHelper.Lookup("Supplier", "Ten", "NhaccID", NhaccID);
                dbModels.Add(itemModel);
                

                // Created Date
                //itemModel = new DBModel();
                //modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                //itemModel.text = "Ngaysua";
                //itemModel.value = modifyDate;
                //itemModel.type = "datetime";
                //dbModels.Add(itemModel);
                // Modify Date
                modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

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
                                dtTab1Output = DBHelper.InsertDatatable(dtTab1Output, dbModels);
                                cbNhacc.SelectedIndex = 0;
                            currentPageNumber = 1;
                                countPageSize(dtTab1Output);
                                ClearText();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Output);
                                MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Exception " + ex);
            }
        }

        

        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            try
            {
                List<DBModel> dbModelsUpdate = new List<DBModel>();
                DBModel itemModelUpdate = new DBModel();
                List<DBModel> dbModelsLookupList = new List<DBModel>();
                DBModel itemModelLookup = new DBModel();
                DBModel modelWhere = new DBModel();
                List<string> UpdateItemQryList = new List<string>();
                DataTable dtItem = (DataTable)(dgvOrder2.DataSource);
                string DonhangID, barcode, BTPChuaIn, BTPDaIn, TP, SPLoi, createDate, modifyDate;
                string UpdateItemQry = "";
                bool isSuccess = false;
                int count = 0;
                var csv = new StringBuilder();
                // DonhangID
                DonhangID = txtOrderID1.Text;
                modelWhere.text = "DonhangID";
                modelWhere.type = "string";
                modelWhere.value = DonhangID;

                // Barcode
                barcode = cbKihieu2.SelectedValue.ToString();
                itemModelLookup.text = "DonhangID";
                itemModelLookup.value = DonhangID;
                dbModelsLookupList.Add(itemModelLookup);
                itemModelUpdate.text = "Kyhieu";
                itemModelUpdate.value = DBHelper.Lookup("Product", "Kyhieu", "Barcode", barcode);
                itemModelUpdate.type = "string";
                dbModelsUpdate.Add(itemModelUpdate);
                // BTPChuaIn
                itemModelUpdate = new DBModel();
                BTPChuaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Chưa in");
                itemModelUpdate.text = "BTP Chưa in";
                itemModelUpdate.type = "int";
                itemModelUpdate.value = txtBTPChuaIn1.Text;
                dbModelsUpdate.Add(itemModelUpdate);
                // BTPDaIn
                itemModelUpdate = new DBModel();
                BTPDaIn = DBHelper.Lookup("Type", "LoaiID", "Ten", "BTP Đã in");
                itemModelUpdate.text = "BTP Đã in";
                itemModelUpdate.type = "int";
                itemModelUpdate.value = txtBTPDaIn1.Text;
                dbModelsUpdate.Add(itemModelUpdate);
                // TP
                itemModelUpdate = new DBModel();
                TP = DBHelper.Lookup("Type", "LoaiID", "Ten", "Thành Phẩm");
                itemModelUpdate.text = "Thành Phẩm";
                itemModelUpdate.type = "int";
                itemModelUpdate.value = txtTP1.Text;
                dbModelsUpdate.Add(itemModelUpdate);
                // SPLoi
                itemModelUpdate = new DBModel();
                SPLoi = DBHelper.Lookup("Type", "LoaiID", "Ten", "Sản phẩm lỗi");
                itemModelUpdate.text = "Sản phẩm lỗi";
                itemModelUpdate.type = "int";
                itemModelUpdate.value = txtSPLoi1.Text;
                dbModelsUpdate.Add(itemModelUpdate);

                // Modify Date
                itemModelUpdate = new DBModel();
                modifyDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                itemModelUpdate.text = "Ngaysua";
                itemModelUpdate.value = modifyDate;
                itemModelUpdate.type = "datetime";

                dbModelsUpdate.Add(itemModelUpdate);

                
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
                                dtTab1Output = DBHelper.UpdateDatatable(dtTab1Output, modelWhere, dbModelsUpdate);
                                currentPageNumber = 1;
                                countPageSize(dtTab1Output);
                                ClearText();
                                // Update datalist
                                PopulateDataOrder(currentPageNumber, rowPerPage, dtTab1Output);
                                MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Don hang nay da ton tai : " + count + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        private void GetAllDataOrderOutput()
        {
            string query = "Select New.DonhangID, Supplier.Ten, Product.Kyhieu, New.[BTP Chưa in], New.[BTP Đã in], New.[Thành Phẩm], New.[Sản phẩm lỗi], [Order].Xong  from (SELECT DonhangID, Barcode, Ngaytao, SUM(CASE WHEN LoaiID = 0000001 Then Soluong ELSE 0 END)[BTP Chưa in], SUM(CASE WHEN LoaiID = 0000002 Then Soluong ELSE 0 END)[BTP Đã in], SUM(CASE WHEN LoaiID = 0000003 Then Soluong ELSE 0 END)[Thành Phẩm], SUM(CASE WHEN LoaiID = 000004 Then Soluong ELSE 0 END)[Sản phẩm lỗi] FROM OrderDetail group by DonhangID, Barcode, Ngaytao) New join Product on New.Barcode = Product.Barcode join[Order] on[Order].DonhangID = New.DonhangID join Supplier on[Order].NhaccID = Supplier.NhaccID where [Order].Xong = 0 order by New.Ngaytao";
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
            lblTotalPage.Text = "Total rows:" + dtTab1Output.Rows.Count.ToString();
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
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        

        private void pbFirst1_Click(object sender, EventArgs e)
        {

        }

        private void pbPrev1_Click(object sender, EventArgs e)
        {

        }

        private void pbNext1_Click(object sender, EventArgs e)
        {

        }

        private void pbLast1_Click(object sender, EventArgs e)
        {

        }

        private void tbNewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbNewOrder.SelectedIndex)
            {
                case 0:
                    { GetAllDataTab1(); }
                    break;
                case 1:
                    {  }
                    break;
            }
        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {

        }
    }
}
