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
    public partial class frmLoaiSP : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaiSP()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            id.Visible = false;
            var data = HelperApi.Instance.GetList<Category>(HelperApi.Url_Category);
            categoryBindingSource.DataSource = data;
        }
        private void frmLoaiSP_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           categoryBindingSource.AddNew();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tenLoai.Text))
            {
                HelperApi.ShowWarning("Tên loại sản phẩm không được để trống");
            }
            if (string.IsNullOrEmpty(mota.Text))
            {
                HelperApi.ShowWarning("Mô tả không được để trống!");
            }
            var add = HelperApi.Instance.Add(HelperApi.Url_Category, new Category
            {
                Name = tenLoai.Text,
                Description = mota.Text,
            });
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tenLoai.Text))
            {
                HelperApi.ShowWarning("Tên loại sản phẩm không được rổng!");
                return;
            }
            id.Visible = true;
            bool delete = HelperApi.Instance.Delete(HelperApi.Url_Category, id.Text);
            id.Visible = false;
            loadData();


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tenLoai.Text))
            {
                HelperApi.ShowWarning("Tên loại sản phẩm không được để trống");
            }
            if (string.IsNullOrEmpty(mota.Text))
            {
                HelperApi.ShowWarning("Mô tả không được để trống!");
            }
            id.Visible = true;
            var update = HelperApi.Instance.Update(HelperApi.Url_Category,id.Text, new Category
            {
                Name = tenLoai.Text,
                Description = mota.Text,
            });
            id.Visible = false;
            loadData();
        }

        private void mota_TextChanged(object sender, EventArgs e)
        {

        }
    }
}