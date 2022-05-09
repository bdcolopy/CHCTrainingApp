using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWProducts
{
    public class ProductCategory
    {
        public int CategoryId { get; }
        public string CategoryName { get; }

        public ProductCategory(int Id, string name)
        {
            CategoryId = Id;
            CategoryName = name;
        }
    }
}
