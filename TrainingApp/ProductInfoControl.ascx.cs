using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AWProducts;
using BusinessLogic;
using DataAccessMocker;

namespace TrainingApp
{
    public partial class ProductInfoControl : BaseUserControlWithIoC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void setLabels(IBusiness salesData, int productId)
        {
            Product product = salesData.GetProduct(productId);
            ProductName.Text = $"Product Name: {product.ProductName}";
            ProductColor.Text = $"Color: {product.Color}";
            ProductPrice.Text = $"Price: ${product.Price.ToString("#,##0.00")}";
        }
    }
}