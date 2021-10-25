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
using Microsoft.Azure.Management.Cdn.Fluent.Models;


namespace MyPhamForm
{
      public partial class frmDonHang : DevExpress.XtraEditors.XtraForm
    {
        //int length=0;

        public frmDonHang()
        {
            InitializeComponent();
        }
       private void LoadDataOrder()
        {
            maDH.Enabled = false;
               var data = HelperApi.Instance.GetList<Order>(HelperApi.Url_Order_Loadfrm);
            orderBindingSource.DataSource = data;
            
        }
    /*    private void LoadComboboxSP()
        {
            var data = HelperApi.Instance.GetList<Product>(HelperApi.Url_Create_Product);
            cmbMaSP.DataSource = data;
            cmbMaSP.DisplayMember = "Name";
            cmbMaSP.ValueMember = "Sku";
        }*/
        private void frmDonHang_Load(object sender, EventArgs e)
        {

            LoadDataOrder();
        //    LoadComboboxSP();
        }
        public void LoadDetailOrder()
        {
            var data = HelperApi.Instance.GetListById<OrderDetail>(HelperApi.Url_Order, maDH.Text);
            if (data == null)
            {
                HelperApi.ShowWarning("giỏ hàng chưa có sản phẩm");
                return;
            }
            else
            {
                orderDetailBindingSource.DataSource = data;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDetailOrder();

       }

        private void orderBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtmaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            orderBindingSource.AddNew();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderDetailBindingSource.AddNew();
        }
        private void buttonLuu_Click(object sender, EventArgs e)
        {
         /* if (string.IsNullOrEmpty(cmbMaSP.Text))
            {
                HelperApi.ShowWarning("Mã sản phẩm không được rổng!");
                return;
            }

            if (string.IsNullOrEmpty(soLuong.Text))
            {
                HelperApi.ShowWarning("Tên sản phẩm không được rổng!");
                return;
            }
            if (string.IsNullOrEmpty(total.Text))
            {
                HelperApi.ShowWarning("Gía không được để trống");
                return;
            }
         //   var data = HelperApi.Instance.GetListById<OrderDetail>(HelperApi.Url_Order, maDH.Text);

            string masp = cmbMaSP.Text;
            int quantity = int.Parse(soLuong.Text);
            double price = double.Parse(total.Text);
            double priceOr = double.Parse(gia.Text);
        
            var add = HelperApi.Instance.Update(HelperApi.Url_Order, maDH.Text, new OrderDetail
            {
                Id = proId.Text,
                Sku = masp,
                Amount = quantity,
                Total = price
                
            });
            priceOr = priceOr + price;
            LoadDetailOrder();
            LoadDataOrder();*/
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maDH.Text))
            {
                HelperApi.ShowWarning("Mã sản phẩm không được rổng!");
                return;
            }

            if (string.IsNullOrEmpty(tenUser.Text))
            {
                HelperApi.ShowWarning("Tên sản phẩm không được rổng!");
                return;
            }
            if (string.IsNullOrEmpty(gia.Text))
            {
                HelperApi.ShowWarning("Gía không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(des.Text))
            {
                HelperApi.ShowWarning("Số lượng không được để trống");
                return;
            }

            double price = double.Parse(gia.Text);
              //id.Visible = true;
            var add = HelperApi.Instance.Add(HelperApi.Url_Order, new Order
            {
                Id = maDH.Text,
                Email = tenUser.Text,
                order_desc = des.Text,
                Total = price,
              
            });
        //     id.Visible = false;
            LoadDataOrder();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
        /*    if (string.IsNullOrEmpty(cmbMaSP.Text))
            {
                HelperApi.ShowWarning("Mã sản phẩm không được rổng!");
                return;
            }

            if (string.IsNullOrEmpty(soLuong.Text))
            {
                HelperApi.ShowWarning("Tên sản phẩm không được rổng!");
                return;
            }
            if (string.IsNullOrEmpty(total.Text))
            {
                HelperApi.ShowWarning("Gía không được để trống");
                return;
            }
            string masp = cmbMaSP.Text;
            int quantity = int.Parse(soLuong.Text);
            double price = double.Parse(total.Text);
               
            bool delete = HelperApi.Instance.Delete1(HelperApi.Url_Order, maDH.Text,proId.Text);
            LoadDetailOrder();
            LoadDataOrder();*/
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void orderDetailBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void orderDetailBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
          /*  if (string.IsNullOrEmpty(cmbMaSP.Text))
            {
                HelperApi.ShowWarning("Mã sản phẩm không được rổng!");
                return;
            }

            if (string.IsNullOrEmpty(soLuong.Text))
            {
                HelperApi.ShowWarning(" số lượng không được rổng!");
                return;
            }
            if (string.IsNullOrEmpty(total.Text))
            {
                HelperApi.ShowWarning("Gía không được để trống");
                return;
            }
            string masp = cmbMaSP.Text;
            int quantity = int.Parse(soLuong.Text);
            double price = double.Parse(total.Text);

            bool update = HelperApi.Instance.Update1(HelperApi.Url_Order, maDH.Text, proId.Text,new OrderDetail { 
                Sku = masp,
                Amount = quantity,
                Total = price
            });
            Console.WriteLine(update);
            LoadDetailOrder();
            LoadDataOrder();*/
        }
    }
}