using AWProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BusinessLogic : IBusiness
    {
        private ISalesData salesData;

        public BusinessLogic(ISalesData salesData)
        {
            this.salesData = salesData;
        }

        public Product GetProduct(int productId)
        {
            return salesData.GetProduct(productId);
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return salesData.GetProductCategories();
        }

        public IEnumerable<Product> GetProducts(int subCategoryId, decimal? lowPrice = null, decimal? highPrice = null)
        {
            var products = salesData.GetProducts(subCategoryId);
            if (lowPrice > highPrice) throw new ArgumentOutOfRangeException();  // checks like this should be the very first thing you do. why call GetProducts if you end up throwing an exception?
            if (lowPrice != null)   // should use lowPrice.HasValue
            {
                products = products.FindAll(x => x.Price >= lowPrice);  // I'm surprised you didn't get a compile error without using lowPrice.Value - which you should use
            }
            if (highPrice != null)
            {
                products = products.FindAll(x => x.Price <= highPrice);
            }
            return products;
        }

        public IEnumerable<ProductSubCategory> GetProductSubCategories(int categoryId, string nameStartsWith = null)
        {
            return salesData.GetProductSubCategories(categoryId);
        }
    }
}
