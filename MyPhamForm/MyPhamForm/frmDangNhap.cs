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
using System.Text.RegularExpressions;

namespace MyPhamForm
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                HelperApi.ShowWarning("email không được rổng!");
                return;
            }

            if (!Regex.IsMatch(textBox1.Text, @"[a-zA-Z0-9]+(@gmail.com)"))
            {
                HelperApi.ShowWarning("email không hợp lệ (ex: example@gmail.com)!");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                HelperApi.ShowWarning("Password không được rổng!");
                return;
            }

            var isLogin = HelperApi.Instance.SignIn(textBox1.Text, textBox2.Text);
            if (isLogin)
            {
                this.Hide();

                string Role = HelperApi.GetRoleFromToken(x => x.Type == JWTClaimsType.Role);

                if (GroupAccess.Admin == Role)
                {
                    frmMain frmMain = new frmMain();
                    frmMain.ShowDialog();       
                }
                else
                {
                    HelperApi.ShowWarning("Chỉ có admin mới được đăng nhập!");
                }
             
                Show();
            }
            else
            {
                HelperApi.ShowWarning("Vui lòng kiểm tra lại email  và mật khẩu!");
            }

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát không?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}