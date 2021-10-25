using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhamForm.Models
{
   public class OrderDetail
    {


        public string Id { get; set; }
        public string Sku { get; set; }
        public int Amount { get; set; }
        public double Total { get; set; }
        public OrderDetail(string masp, int sl, double gia)
        {
            this.Sku = masp;
            this.Amount = sl;
            this.Total = gia;
        }
        public OrderDetail()
        {
            
        }
    }
}
