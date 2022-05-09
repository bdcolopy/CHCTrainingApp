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
            if (lowPrice > highPrice) throw new ArgumentOutOfRangeException();
            if (lowPrice != null)
            {
                products = products.FindAll(x => x.Price >= lowPrice);
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
