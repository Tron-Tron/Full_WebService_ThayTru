using System.Collections;
using System.Collections.Generic;
namespace MyPhamForm.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public List<OrderDetail> Product { get; set; }
        public string order_desc { get; set; }
        public double Total { get; set; }

    }
}
