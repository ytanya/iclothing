﻿using System;
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
    public partial class ChiTietNhapXuat : UserControl
    {
        public string ConnectionString = DBAccess.ConnectionString;
        private bool ngayTuNgayFilterChanged = false, ngayDenNgayFilterChanged = false;
        private int currentPageNumber, rowPerPage, pageSize, rowCount;
        string strSearch = string.Empty;
        public ChiTietNhapXuat()
        {
            InitializeComponent();
        }

        private void ChiTietNhapXuat_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            currentPageNumber = 1;
            rowPerPage = 10;
            GetTotalRow(strSearch);
            GetAllOrder(currentPageNumber, rowPerPage,strSearch);
            cbPageSize.SelectedIndex = 0;

            // Init Ki hieu combobox
            DataTable dtProduct = DBHelper.GetAllProduct();
            if (dtProduct.Rows.Count > 0)
            {
                

                cbKyHieuFilter.DataSource = dtProduct;
                cbKyHieuFilter.ValueMember = "Barcode";
                cbKyHieuFilter.DisplayMember = "Kyhieu";
                cbKyHieuFilter.SelectedIndex = -1;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today;

            cbKyHieuFilter.SelectedIndex = -1;
            if (dvgOrder.DataSource != null)
            {
                (dvgOrder.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strSearch = string.Empty;
            string ngayNhapXuat = string.Format("NewAll.[Ngày Nhập/ Xuất] > '{0}' AND NewAll.[Ngày Nhập/ Xuất] < '{1}'", dtpTuNgay.Value.AddDays(-1).Date, dtpDenNgay.Value.Date);
            strSearch = ngayNhapXuat;

            string kihieuValue = cbKyHieuFilter.SelectedIndex ==-1?string.Empty: DBHelper.Lookup("Product", "Kyhieu", "Barcode", cbKyHieuFilter.SelectedValue.ToString());
            string kyhieu = string.IsNullOrEmpty(kihieuValue) ? string.Empty : " NewAll.[Ký Hiệu] like '" + kihieuValue + "'";
            strSearch = string.IsNullOrEmpty(strSearch) ? (string.IsNullOrEmpty(kyhieu) ? "" : kyhieu) : (string.IsNullOrEmpty(kyhieu) ? strSearch : strSearch + " AND " + kyhieu);

            if (!string.IsNullOrEmpty(strSearch)) strSearch = " WHERE " + strSearch;
            GetTotalRow(strSearch);
            GetAllOrder(currentPageNumber, rowPerPage, strSearch);
            //(dvgOrder.DataSource as DataTable).DefaultView.RowFilter = strSearch;
        }

        private void pbFirst_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber = 1;
                GetAllOrder(currentPageNumber, rowPerPage, strSearch);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber -= 1;
                GetAllOrder(currentPageNumber, rowPerPage, strSearch);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber += 1;
                GetAllOrder(currentPageNumber, rowPerPage, strSearch);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void pbLast_Click(object sender, EventArgs e)
        {
            if (currentPageNumber < pageSize)
            {
                currentPageNumber = pageSize;
                GetAllOrder(currentPageNumber, rowPerPage, strSearch);
                txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
            }
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            ngayTuNgayFilterChanged = true;
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            ngayDenNgayFilterChanged = true;
        }

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowPerPage = Convert.ToInt32(cbPageSize.SelectedItem.ToString());
            currentPageNumber = 1;
            GetAllOrder(currentPageNumber, rowPerPage, strSearch);
            pageSize = rowCount / rowPerPage;
            // if any row left after calculated pages, add one more page 
            if (rowCount % rowPerPage > 0)
                pageSize += 1;
            txtPaging.Text = currentPageNumber.ToString() + " /" + pageSize.ToString();
        }

        private void GetAllOrder(int currentPageNumber, int rowPerPage, string strSearch)
        {
            int skipRecord = currentPageNumber - 1;
            if (skipRecord != 0) skipRecord = skipRecord * rowPerPage;

            string query = "select * from (select * from (select  CONVERT(NVARCHAR(10), [order].ngayxong, 103) AS [Ngày Nhập/ Xuất], product.kyhieu [Ký Hiệu], product.masp [Mã Sản Phẩm], "
                            + "SUM(CASE WHEN LoaiID = 0000001 AND[order].NhacciD is not null Then Soluong else 0 end)[Nhập BTP Chưa in], "
                            + "SUM(CASE WHEN LoaiID = 0000002 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhập BTP Đã in], "
                            + "SUM(CASE WHEN LoaiID = 0000003 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhập Thành Phẩm], "
                            + "SUM(CASE WHEN LoaiID = 000004 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhập Sản phẩm lỗi], "
                            + "SUM(CASE WHEN LoaiID = 0000001 AND[order].KHID is not null Then Soluong else 0 end)[Xuất BTP Chưa in], "
                            + "SUM(CASE WHEN LoaiID = 0000002 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuất BTP Đã in], "
                            + "SUM(CASE WHEN LoaiID = 0000003 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuất Thành Phẩm], "
                            + "SUM(CASE WHEN LoaiID = 000004 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuất Sản phẩm lỗi] "
                            + "from orderdetail "
                            + "join [order] on orderdetail.donhangid = [order].donhangid "
                            + "join product on orderdetail.barcode = product.barcode "
                            + "where [order].xong = 1 "
                            + "GROUP BY CONVERT(NVARCHAR(10), [order].ngayxong, 103), product.kyhieu,product.masp) New ) NewAll " + strSearch + "order by NewAll.[Ngày Nhập/ Xuất]" + " OFFSET " + skipRecord.ToString() + " ROWS FETCH NEXT " + rowPerPage.ToString() + " ROWS ONLY; ";
            using (SqlCeConnection connection = new SqlCeConnection(ConnectionString))
            {
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dvgOrder.DataSource = dt;
                    dvgOrder.Columns[0].Width = 150;
                    //dvgOrder.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    //dvgOrder.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dvgOrder.Columns[1].Width = 130;
                    
                    //dgvOrderNhap.Columns["Xong"].ReadOnly = true;
                    dvgOrder.Columns["Ký Hiệu"].Width = 45;
                    dvgOrder.Columns["Nhập BTP Chưa in"].Width = 60;
                    this.dvgOrder.Columns["Nhập BTP Chưa in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgOrder.Columns["Nhập BTP Đã in"].Width = 60;
                    this.dvgOrder.Columns["Nhập BTP Đã in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgOrder.Columns["Nhập Thành Phẩm"].Width = 55;
                    this.dvgOrder.Columns["Nhập Thành Phẩm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgOrder.Columns["Nhập Sản phẩm lỗi"].Width = 60;
                    this.dvgOrder.Columns["Nhập Sản phẩm lỗi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgOrder.Columns["Xuất BTP Chưa in"].Width = 60;
                    this.dvgOrder.Columns["Xuất BTP Chưa in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgOrder.Columns["Xuất BTP Đã in"].Width = 50;
                    this.dvgOrder.Columns["Xuất BTP Đã in"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgOrder.Columns["Xuất Thành Phẩm"].Width = 60;
                    this.dvgOrder.Columns["Xuất Thành Phẩm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgOrder.Columns["Xuất Sản phẩm lỗi"].Width = 60;
                    this.dvgOrder.Columns["Xuất Sản phẩm lỗi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dvgOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dvgOrder.Sort(dvgOrder.Columns["Ngày Nhập/ Xuất"], ListSortDirection.Descending);
                }
            }
        }

        private void GetTotalRow(string query)
        {
            string queryAll = "SELECT COUNT(*) AS Total FROM (select * from (select CONVERT(NVARCHAR(10), [order].ngayxong, 101) AS [Ngày Nhập/ Xuất], product.kyhieu[Ký Hiệu], product.masp[Mã Sản Phẩm], "
                            + "SUM(CASE WHEN LoaiID = 0000001 AND[order].NhacciD is not null Then Soluong else 0 end)[Nhập BTP Chưa in], "
                            + "SUM(CASE WHEN LoaiID = 0000002 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhập BTP Đã in], "
                            + "SUM(CASE WHEN LoaiID = 0000003 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhập Thành Phẩm], "
                            + "SUM(CASE WHEN LoaiID = 000004 AND[order].NhacciD is not null Then Soluong ELSE 0 END)[Nhập Sản phẩm lỗi], "
                            + "SUM(CASE WHEN LoaiID = 0000001 AND[order].KHID is not null Then Soluong else 0 end)[Xuất BTP Chưa in], "
                            + "SUM(CASE WHEN LoaiID = 0000002 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuất BTP Đã in], "
                            + "SUM(CASE WHEN LoaiID = 0000003 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuất Thành Phẩm], "
                            + "SUM(CASE WHEN LoaiID = 000004 AND[order].KHID is not null Then Soluong ELSE 0 END)[Xuất Sản phẩm lỗi] "
                            + "from orderdetail "
                            + "join [order] on orderdetail.donhangid = [order].donhangid "
                            + "join product on orderdetail.barcode = product.barcode "
                            + "where [order].xong = 1 "
                            + "GROUP BY CONVERT(NVARCHAR(10), [order].ngayxong, 101), product.kyhieu,product.masp) New ) NewAll " + query;
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
    }
}
