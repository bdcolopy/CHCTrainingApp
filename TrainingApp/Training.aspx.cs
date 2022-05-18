using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static TrainingApp.SQLHandler;

namespace TrainingApp
{
    public partial class Training : System.Web.UI.Page
    {
        private static string SortExpression = "";
        private static string SortColumn = "Due Date";
        private static string SortDirection = " ASC";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                welcomeMessge.Text = DateTime.Now.ToString("HH:mm:ss:fff");
                getProductColors();
            }
        }

        // in C#, method names should use Pascal casing (i.e. UpdateClick)
        // see https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
        protected void updateClick(object sender, EventArgs e)
        {
            textLabel.Text = textBox.Text;
        }

        // in C#, method names should use Pascal casing (i.e. GetProductColors)
        // see https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
        protected void getProductColors()
        {
            dropDownColor.Items.Clear();
            dropDownColor.Items.Add("Product Color");

            // you should use blank lines to separate logical blocks in a method
            foreach (string c in getColorList())    // you should use more descriptive names, as in this case 'color' instead of 'c'
            {
                dropDownColor.Items.Add(c);
            }
        }

        // you should use blank lines to separate methods
        protected void getProductByColor(object sender, EventArgs e)
        {
            dropDownProduct.Items.Clear();
            dropDownProduct.Items.Add("Product Name");
            string selectedColor = $"= '{dropDownColor.SelectedValue}'";
            if (dropDownColor.SelectedValue == "No Color") selectedColor = "is null";   // this is probably personal taste, but I really prefer to have the action of an if on a separate line from the if itself - I really feel that it improves readability

            foreach (string p in getProductList(selectedColor))
            {
                dropDownProduct.Items.Add(p);
            }
        }

        protected void getProductInfo(object sender, EventArgs e)
        {
            dataGridLabel.Text = dropDownProduct.SelectedValue;
            gridProduct.DataSource = createDataSource(dropDownProduct.SelectedValue, SortExpression);
            gridProduct.DataBind();
        }

        protected void gridProduct_Sorted(object sender, GridViewSortEventArgs e)
        {
            if (SortColumn == e.SortExpression.ToString())
            {
                if (SortDirection == " DESC") SortDirection = " ASC";
                else SortDirection = " DESC";

                // you could also say SortDirection = (SortDirection == " DESC") ? " ASC" : " DESC";
            }
            SortColumn = e.SortExpression.ToString();
            SortExpression = SortColumn + SortDirection;    // I would use string interpolation instead of concatenation, so = $"{SortColumn}{SortDirection}"
            gridProduct.DataSource = createDataSource(dropDownProduct.SelectedValue, SortExpression);
            gridProduct.DataBind();
        }

        // avoid excess blank lines

    }
}