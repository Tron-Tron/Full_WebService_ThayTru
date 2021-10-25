namespace MyPhamForm
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btDonHang = new DevExpress.XtraBars.BarButtonItem();
            this.btNguoiDung = new DevExpress.XtraBars.BarButtonItem();
            this.btSanPham = new DevExpress.XtraBars.BarButtonItem();
            this.btnLoaiSP = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btDonHang,
            this.btNguoiDung,
            this.btSanPham,
            this.btnLoaiSP,
            this.btnThoat});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(913, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btDonHang
            // 
            this.btDonHang.Caption = "ĐƠN ĐẶT HÀNG";
            this.btDonHang.Id = 1;
            this.btDonHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btDonHang.ImageOptions.Image")));
            this.btDonHang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btDonHang.ImageOptions.LargeImage")));
            this.btDonHang.Name = "btDonHang";
            this.btDonHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btDonHang_ItemClick);
            // 
            // btNguoiDung
            // 
            this.btNguoiDung.Caption = "NGƯỜI DÙNG";
            this.btNguoiDung.Id = 2;
            this.btNguoiDung.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btNguoiDung.ImageOptions.Image")));
            this.btNguoiDung.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btNguoiDung.ImageOptions.LargeImage")));
            this.btNguoiDung.Name = "btNguoiDung";
            this.btNguoiDung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btNguoiDung_ItemClick);
            // 
            // btSanPham
            // 
            this.btSanPham.Caption = "SẢN PHẨM";
            this.btSanPham.Id = 3;
            this.btSanPham.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btSanPham.ImageOptions.Image")));
            this.btSanPham.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btSanPham.ImageOptions.LargeImage")));
            this.btSanPham.Name = "btSanPham";
            this.btSanPham.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btSanPham_ItemClick);
            // 
            // btnLoaiSP
            // 
            this.btnLoaiSP.Caption = "LOẠI SẢN PHẨM";
            this.btnLoaiSP.Id = 4;
            this.btnLoaiSP.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLoaiSP.ImageOptions.Image")));
            this.btnLoaiSP.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLoaiSP.ImageOptions.LargeImage")));
            this.btnLoaiSP.Name = "btnLoaiSP";
            this.btnLoaiSP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoaiSP_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "THOÁT";
            this.btnThoat.Id = 5;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.LargeImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btDonHang);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btNguoiDung);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btSanPham);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnLoaiSP);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnThoat);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "ribbonPageGroup5";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 425);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(913, 24);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 449);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btDonHang;
        private DevExpress.XtraBars.BarButtonItem btNguoiDung;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btSanPham;
        private DevExpress.XtraBars.BarButtonItem btnLoaiSP;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
    }
}