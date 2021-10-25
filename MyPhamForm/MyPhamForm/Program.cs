using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using MyPhamForm.Common;
using MyPhamForm.Models;

namespace MyPhamForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string id = Guid.NewGuid().ToString();
            //Product model = new Product
            //{
            //    Name = "dasyfdybj",
            //    Description = "dliashdias",
            //    Price = 789,
            //    Quantity = 09,
            //    Sku = "asugdb",
            //    Category = "asdasd",
            //    Id = id
            //};
            //HelperApi.Instance.Add(HelperApi.Url_Create_Product, model);
            //HelperApi.Instance.Update(HelperApi.Url_Create_Product,id, model);
            //HelperApi.Instance.Delete(HelperApi.Url_Create_Product, id);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDangNhap());
        }
    }
}
