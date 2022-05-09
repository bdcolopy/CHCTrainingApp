using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWProducts
{
    public class Product
    {
        public int ProductId { get; }
        public int SubCategoryId { get; }
        public string ProductName { get; }
        public string Color { get; }
        public decimal Price { get; }

        public Product(int Id, int subId, string name, string color, decimal price)
        {
            ProductId = Id;
            SubCategoryId = subId;
            ProductName = name;
            Color = color;
            Price = price;

        }

    }
}
