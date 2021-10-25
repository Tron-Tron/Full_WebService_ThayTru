using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace MyPhamForm
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly Form Parent;
        private Form currentForm = null;
        public frmMain(Form form)
        {
            InitializeComponent();
            Parent = form;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private Form FindForm<T>() where T : Form
        {
            var Temps = typeof(T);
            return this.MdiChildren.FirstOrDefault(x => x.GetType() == Temps);
        }
        private void ShowForm<T>() where T : Form
        {
            if (currentForm != null)
            {
                currentForm.Hide();
            }

            currentForm = FindForm<T>();

            if (currentForm == null)
            {
                currentForm = Activator.CreateInstance<T>();
                currentForm.MdiParent = this;
            }
            currentForm.Show();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btDonHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmDonHang>();
        }

        private void btNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmUser>();
        }

        private void btSanPham_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmSanPham>();
        }

        private void btnLoaiSP_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmLoaiSP>();
        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát không?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Hide();
                frmDangNhap formDN = new frmDangNhap();
                formDN.Show();
            }
            else
            {
                this.Show();
            }
        }
    }
}