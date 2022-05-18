using AWProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    // interfaces and the classes that implement them should not be in the same assembly. interfaces are best defined in a common/shared assembly
    public interface IBusiness
    {
        IEnumerable<ProductCategory> GetProductCategories();
        IEnumerable<ProductSubCategory> GetProductSubCategories(int categoryId, string nameStartsWith = null);
        IEnumerable<Product> GetProducts(int subCategoryId, decimal? lowPrice = null, decimal? highPrice = null);
        Product GetProduct(int productId);
    }
}
