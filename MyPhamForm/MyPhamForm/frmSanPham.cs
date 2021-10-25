using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MyPhamForm.Common;
using MyPhamForm.Models;

namespace MyPhamForm
{
    public partial class frmSanPham : DevExpress.XtraEditors.XtraForm
    {
        private string control = "";
        public frmSanPham()
        {
            InitializeComponent();
            //id.Visible = false;
        }
        private void LoadData()
        {
            maSP.Enabled = false;
            id.Visible = false;
            var data = HelperApi.Instance.GetList<Product>(HelperApi.Url_List_Product);
            productBindingSource.DataSource = data;
        }
        private void LoadCombobox()
        {
            var data = HelperApi.Instance.GetList<Category>(HelperApi.Url_Category);
            loaiSP.DataSource = data;
            loaiSP.DisplayMember = "Name";
            loaiSP.ValueMember = "Id";
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCombobox();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            maSP.Enabled = true;
            productBindingSource.AddNew();
        }
       
      private void deleteSP (Product product)
        {
            
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            
           if (string.IsNullOrEmpty(maSP.Text))
            {
                HelperApi.ShowWarning("Mã sản phẩm không được rổng!");
                return;
            }
            id.Visible = true;
            bool delete = HelperApi.Instance.Delete(HelperApi.Url_List_Product,id.Text);
            id.Visible = false;
            LoadData();


        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maSP.Text))
            {
                HelperApi.ShowWarning("Mã sản phẩm không được rổng!");
                return;
            }

            if (string.IsNullOrEmpty(tenSP.Text))
            {
                HelperApi.ShowWarning("Tên sản phẩm không được rổng!");
                return;
            }
            if (string.IsNullOrEmpty(gia.Text))
            {
                HelperApi.ShowWarning("Gía không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(soLuong.Text))
            {
                HelperApi.ShowWarning("Số lượng không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(loaiSP.Text))
            {
                HelperApi.ShowWarning("Loai san pham khong duoc de trong");
                return;
            }
            if (string.IsNullOrEmpty(moTa.Text))
            {
                HelperApi.ShowWarning("Mô tả không được để trống");
                return;
            }
           
            int quantity = int.Parse(soLuong.Text);
            double price = double.Parse(gia.Text);
            var add = HelperApi.Instance.Add(HelperApi.Url_List_Product, new Product
            {
                Name_product = tenSP.Text,
                Description = moTa.Text,
                Quantity = quantity,
                Price = price,
                Sku = maSP.Text,
                Category = loaiSP.Text,
                Image = hinhAnh.Text
            });
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maSP.Text))
            {
                HelperApi.ShowWarning("Mã sản phẩm không được rổng!");
                return;
            }

            if (string.IsNullOrEmpty(tenSP.Text))
            {
                HelperApi.ShowWarning("Tên sản phẩm không được rổng!");
                return;
            }
            if (string.IsNullOrEmpty(gia.Text))
            {
                HelperApi.ShowWarning("Gía không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(soLuong.Text))
            {
                HelperApi.ShowWarning("Số lượng không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(loaiSP.Text))
            {
                HelperApi.ShowWarning("Loại sản phẩm khồn được để trống");
                return;
            }
            if (string.IsNullOrEmpty(moTa.Text))
            {
                HelperApi.ShowWarning("Mô tả không được để trống");
                return;
            }

            int quantity = int.Parse(soLuong.Text);
            double price = double.Parse(gia.Text);
            id.Visible = true;
            var add = HelperApi.Instance.Update(HelperApi.Url_List_Product, id.Text, new Product
            {
                Name_product= tenSP.Text,
                Description = moTa.Text,
                Quantity = quantity,
                Price = price,
                Sku = maSP.Text,
                Category = loaiSP.Text,
                Image = hinhAnh.Text
            });
            id.Visible = false;
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void loaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}