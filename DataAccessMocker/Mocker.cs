using AWProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessMocker
{
    public class Mocker : ISalesData
    {
        private List<Product> mockProduct = new List<Product>();
        private List<ProductCategory> mockCategory = new List<ProductCategory>();
        private List<ProductSubCategory> mockSubCat = new List<ProductSubCategory>();

        public Mocker()
        {
            insertMockData();
        }

        public void insertMockData()
        {
            mockCategory.Add(new ProductCategory(1, "Ball"));
            mockCategory.Add(new ProductCategory(2, "Shoes"));
            mockCategory.Add(new ProductCategory(3, "Uniform"));
            mockSubCat.Add(new ProductSubCategory(1, 1, "Soccer"));
            mockSubCat.Add(new ProductSubCategory(2, 1, "Football" ));
            mockSubCat.Add(new ProductSubCategory(3, 2, "Cleats"));
            mockSubCat.Add(new ProductSubCategory(4, 2, "Running"));
            mockSubCat.Add(new ProductSubCategory(5, 3, "Socks"));
            mockSubCat.Add(new ProductSubCategory(6, 3, "Jerseys"));
            mockProduct.Add(new Product(1, 1, "SB-Y", "Yellow", 25.99M));
            mockProduct.Add(new Product(2, 1, "SB-Blu", "Blue", 25.99M));
            mockProduct.Add(new Product(3, 1, "SB-Blk", "Black", 25.99M));
            mockProduct.Add(new Product(4, 2, "FB-B", "Brown", 34.99M));
            mockProduct.Add(new Product(5, 2, "FB-R", "Red", 34.99M));
            mockProduct.Add(new Product(6, 2, "FB-W", "White", 34.99M));
            mockProduct.Add(new Product(7, 3, "Clt-R", "Red", 85.99M));
            mockProduct.Add(new Product(8, 3, "Clt-Blu", "Blue", 79.99M));
            mockProduct.Add(new Product(9, 3, "Clt-Blk", "Black", 79.99M));
            mockProduct.Add(new Product(10, 4, "Rng-Blk", "Black", 60.99M));
            mockProduct.Add(new Product(11, 4, "Rng-Y", "Yellow", 60.99M));
            mockProduct.Add(new Product(12, 4, "Rng-W", "White", 60.99M));
            mockProduct.Add(new Product(13, 5, "Sk-W-Ank", "White", 14.99M));
            mockProduct.Add(new Product(14, 5, "Sk-Blk-Ank", "Black", 14.99M));
            mockProduct.Add(new Product(15, 5, "Sk-Blk-Long", "Black", 18.99M));
            mockProduct.Add(new Product(16, 6, "Jrsy-Blu", "Blue", 49.99M));
            mockProduct.Add(new Product(17, 6, "Jrsy-R", "Red", 49.99M));
            mockProduct.Add(new Product(18, 6, "Jrsy-Blk", "Black", 49.99M));
        }

        public Product GetProduct(int ProductId)
        {
            foreach(var product in mockProduct)
            {
                if (product.ProductId == ProductId)
                    return product;
            }
            return null;
        }

        public List<ProductCategory> GetProductCategories()
        {
            List<ProductCategory> pc = new List<ProductCategory>();
            foreach(var cat in mockCategory)
            {
                pc.Add(cat);
            }
            return pc;
        }

        public List<Product> GetProducts(int SubCatId)
        {
            List<Product> p = new List<Product>();
            foreach (var product in mockProduct)
            {
                if (product.SubCategoryId == SubCatId)
                {
                    p.Add(product);
                }
            }
            return p;
        }

        public List<ProductSubCategory> GetProductSubCategories(int CatId)
        {
            List<ProductSubCategory> pc = new List<ProductSubCategory>();
            foreach (var subCat in mockSubCat)
            {
                if (subCat.CategoryId == CatId)
                {
                    pc.Add(subCat);
                }
            }
            return pc;
        }
    }
}
