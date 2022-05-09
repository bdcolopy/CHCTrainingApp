using DataAccessMocker;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static TrainingApp.SQLHandler;
using AWProducts;
using System.Linq;
using BusinessLogic;

namespace TrainingApp
{
    public partial class _Default : BasePageWithIoC
    {
        private static string SortColumn = "Price";
        private static string SortDirection = " ASC";
        //public ISalesData Mocker { get; set; }
        public IBusiness BL { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getProductCategory();
            }
        }

        protected void getProductCategory()
        {
                DropDownCategory.Items.Clear();
                DropDownCategory.Items.Add("Product Category");
                DropDownCategory.AppendDataBoundItems = true;
                DropDownCategory.DataSource = BL.GetProductCategories();
                DropDownCategory.DataTextField = "CategoryName";
                DropDownCategory.DataValueField = "CategoryId";
                DropDownCategory.DataBind();
        }

        protected void getProductSubCategory(object sender, EventArgs e)
        {
            ProductInfo.Visible = false;
            GridViewProducts.DataSource = null;
            GridViewProducts.DataBind();
            DropDownSubCategory.DataSource = null;
            DropDownSubCategory.DataBind();
            DropDownSubCategory.Items.Clear();
            if (DropDownCategory.SelectedIndex != 0)
            {
                DropDownSubCategory.Items.Add("Product Subcategory");
                DropDownSubCategory.AppendDataBoundItems = true;
                DropDownSubCategory.DataSource = BL.GetProductSubCategories(Int32.Parse(DropDownCategory.SelectedValue));
                DropDownSubCategory.DataTextField = "SubCategoryName";
                DropDownSubCategory.DataValueField = "SubCategoryId";
                DropDownSubCategory.DataBind();
            }            
        }

        protected void getProduct(object sender, EventArgs e)
        {
            ProductInfo.Visible = false;
            if (DropDownSubCategory.SelectedIndex != 0)
            {
                getSortedProducts(SortColumn);
            } else
            {
                GridViewProducts.DataSource = null;
                GridViewProducts.DataBind();
            }
        }


        protected void GridProductRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Sort")
            {
                ProductInfo.Visible = true;
                ProductInfoControl.setLabels(BL, Convert.ToInt32(GridViewProducts.DataKeys[Convert.ToInt32(e.CommandArgument)].Value));
            }
        }

        protected void GridViewProducts_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortColumn = e.SortExpression.ToString();
            getSortedProducts(SortColumn);
        }

        private void getSortedProducts(string SortColumn)
        {
            BindingSource bs = new BindingSource();
            var prods = BL.GetProducts(Int32.Parse(DropDownSubCategory.SelectedValue));;
            if (SortDirection == " DESC")
            {
                SortDirection = " ASC";
                if (SortColumn == "ProdcutID") bs.DataSource = prods.OrderByDescending(x => x.ProductName);
                else if (SortColumn == "Color") bs.DataSource = prods.OrderByDescending(x => x.Color);
                else bs.DataSource = prods.OrderByDescending(x => x.Price);
            }
            else
            {
                SortDirection = " DESC";
                if (SortColumn == "ProdcutID") bs.DataSource = prods.OrderBy(x => x.ProductName);
                else if (SortColumn == "Color") bs.DataSource = prods.OrderBy(x => x.Color);
                else bs.DataSource = prods.OrderBy(x => x.Price);
            }
            GridViewProducts.DataSource = bs;
            GridViewProducts.DataBind();
        }
    }
}
