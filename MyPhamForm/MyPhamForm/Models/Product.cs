using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhamForm.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name_product { get; set; }
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
    }
}
