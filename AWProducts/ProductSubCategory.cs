using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWProducts
{
    public class ProductSubCategory
    {
        public int SubCategoryId { get; }
        public int CategoryId { get; }
        public string SubCategoryName { get; }

        public ProductSubCategory(int subId, int Id, string name)
        {
            CategoryId = Id;
            SubCategoryId = subId;
            SubCategoryName = name;
        }
    }
}
