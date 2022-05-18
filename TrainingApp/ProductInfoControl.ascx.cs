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
        // unless you're actually doing something in the load, you don't need to have it defined
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void setLabels(IBusiness salesData, int productId)
        {
            Product product = salesData.GetProduct(productId);  // what happens if product ends up being null?  are you ok with an exception being thrown but the following statements?
            ProductName.Text = $"Product Name: {product.ProductName}";
            ProductColor.Text = $"Color: {product.Color}";
            ProductPrice.Text = $"Price: ${product.Price.ToString("#,##0.00")}";    // I think product.Price.ToString("C") might give you what you need
        }
    }
}