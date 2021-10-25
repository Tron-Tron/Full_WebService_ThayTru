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
using System.Text.RegularExpressions;

namespace MyPhamForm
{
    public partial class frmUser : DevExpress.XtraEditors.XtraForm
    {
        public frmUser()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            var data = HelperApi.Instance.GetList<User>(HelperApi.Url_User_All);
            userBindingSource.DataSource = data;
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            loadData();
        }

   
        private void btnLuu_Click(object sender, EventArgs e)
        {
        }

           private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text))
            {
                HelperApi.ShowWarning("Tên người dùng không được rổng!");
                return;
            }

            if (string.IsNullOrEmpty(email.Text))
            {
                HelperApi.ShowWarning("email không được rổng!");
                return;
            }

            if (!Regex.IsMatch(email.Text, @"[a-zA-Z0-9]+(@gmail.com)"))
            {
                HelperApi.ShowWarning("email không hợp lệ (ex: example@gmail.com)!");
                loadData();
                return;
            }
            if (!Regex.IsMatch(sdt.Text, @"0\d{9,10}\s*$"))
            {
                HelperApi.ShowWarning("SĐT không hợp lệ (ex: 0123456789)!");
                loadData();
                return;
            }
            if (string.IsNullOrEmpty(role.Text))
            {
                HelperApi.ShowWarning("Quyền không được để trống");
                return;
            }
            if (string.IsNullOrEmpty(status.Text))
            {
                HelperApi.ShowWarning("Trạng thái không được để trống");
                return;
            }
            bool isStatus = bool.Parse(status.Text);
           
            id.Visible = true;
            password.Visible = true;
            var update = HelperApi.Instance.Update(HelperApi.Url_User, id.Text, new User
            {
                Name = name.Text,
                Email = email.Text,
                Password = password.Text,
                Role = role.Text,
                Phone = sdt.Text,
                Address = diachi.Text,
                IsActive = isStatus,
               
            });
            id.Visible = false;
            password.Visible = false;
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email.Text))
            {
                HelperApi.ShowWarning("Email không được rổng!");
                return;
            }
            id.Visible = true;
            bool delete = HelperApi.Instance.Delete(HelperApi.Url_User, id.Text);
            id.Visible = false;
            loadData();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}