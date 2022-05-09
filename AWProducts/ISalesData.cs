using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWProducts
{
    public interface ISalesData
    {
        List<ProductCategory> GetProductCategories();
        List<ProductSubCategory> GetProductSubCategories(int CatId);
        List<Product> GetProducts(int SubCatId);
        Product GetProduct(int ProductId);

    }
}
