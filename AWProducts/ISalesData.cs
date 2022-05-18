using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWProducts
{
    public interface ISalesData
    {
        // should use IEnumerable<ProductCategory>, etc.
        List<ProductCategory> GetProductCategories();
        List<ProductSubCategory> GetProductSubCategories(int CatId);    // parameter names should be camelcases, i.e. catId
        List<Product> GetProducts(int SubCatId);
        Product GetProduct(int ProductId);

    }
}
