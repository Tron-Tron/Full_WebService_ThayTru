using MyPhamForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TracNghiem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ không?", "OK", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Hide();
                frmMain formM = new frmMain();
                formM.Show();
            }
        }

        private void btnTaoLogin_Click(object sender, EventArgs e)
        {
            /*
            if (login(txtLogin.Text, txtPass.Text))
            {
                var reader = Program.ExecSqlDataReader($"EXEC [dbo].[SP_TAOTAIKHOAN] @TENLOGIN = N'{Program.mlogin}'");
                if (reader.Read())
                {
                    Program.username = reader["USERNAME"].ToString();
                    Program.mGroup = reader["Quyen"].ToString();
                    Program.mHoten = reader["HOTEN"].ToString();

                    this.Hide();
                    frmMain frmMain = new frmMain(this);
                    frmMain.Show();
                }

            }
            else
            {

            }
            */
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxHIENPASS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHIENPASS.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }   
}
