using AWProducts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWConnect
{
    public class InjectedHandler : ISalesData
    {
        private static string connection = ConfigurationManager.ConnectionStrings["ConnectStrDB"].ConnectionString;
        private static SqlCommand cmd;
        private static SqlDataReader reader;
        private static SqlConnection con;

        private static void DisposeClose()
        {
            reader.Close();
            reader.Dispose();
            con.Close();
            con.Dispose();
            cmd.Dispose();
        }

        private static void DBConnect(string sql)
        {
            con = new SqlConnection(connection);
            cmd = new SqlCommand(sql, con);
            con.Open();
            reader = cmd.ExecuteReader();
        }

        public Product GetProduct(int ProductId)
        {
            string query = $"Select ProductID, ProductSubcategoryID, Name, Color, ListPrice From Production.Product Where ProductID = {ProductId}";
            DBConnect(query);
            Product product = null;

            while (reader.Read())
            {
                product = new Product(Int32.Parse(reader["ProductID"].ToString()), Int32.Parse(reader["ProductSubcategoryID"].ToString()), reader["Name"].ToString(), reader["Color"].ToString(), decimal.Parse(reader["ListPrice"].ToString()));
            }
            DisposeClose();
            return product;
        }

        public List<Product> GetProducts(int SubCatId)
        {
            string query;
            if (SubCatId == 0)
                query = "Select ProductID, ProductSubcategoryID, Name, Color, ListPrice From Production.Product";
            else 
                query = $"Select ProductID, ProductSubcategoryID, Name, Color, ListPrice From Production.Product Where ProductSubcategoryID = {SubCatId}";
            DBConnect(query);
            Product product = null;
            List<Product> pList = new List<Product>();

            while (reader.Read())
            {
                string nullColor = reader["Color"].ToString();
                if (nullColor == "") nullColor = "No Color";
                product = new Product(Int32.Parse(reader["ProductID"].ToString()), Int32.Parse(reader["ProductSubcategoryID"].ToString()), reader["Name"].ToString(), nullColor, decimal.Parse(reader["ListPrice"].ToString()));
                pList.Add(product);
            }
            DisposeClose();
            return pList;
        }

        public List<ProductCategory> GetProductCategories()
        {
            string query = "Select ProductCategoryID, Name From Production.ProductCategory";
            DBConnect(query);
            ProductCategory category = null;
            List<ProductCategory> pc = new List<ProductCategory>();

            while (reader.Read())
            {
                category = new ProductCategory(Int32.Parse(reader["ProductCategoryID"].ToString()), reader["Name"].ToString());
                pc.Add(category);
            }
            DisposeClose();
            return pc;
        }

        public List<ProductSubCategory> GetProductSubCategories(int CatId)
        {
            string query;
            if (CatId == 0)
                query = "Select ProductCategoryID, ProductSubcategoryID, Name From Production.ProductSubcategory";
            else
                query = $"Select ProductCategoryID, ProductSubcategoryID, Name From Production.ProductSubcategory Where ProductCategoryID = {CatId}";
            DBConnect(query);
            ProductSubCategory subCategory = null;
            List<ProductSubCategory> psc = new List<ProductSubCategory>();

            while (reader.Read())
            {
                subCategory = new ProductSubCategory(Int32.Parse(reader["ProductSubcategoryID"].ToString()), Int32.Parse(reader["ProductCategoryID"].ToString()), reader["Name"].ToString());
                psc.Add(subCategory);
            }
            DisposeClose();
            return psc;
        }
    }
}

