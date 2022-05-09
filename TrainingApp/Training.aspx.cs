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
        protected void updateClick(object sender, EventArgs e)
        {
            textLabel.Text = textBox.Text;
        }

        protected void getProductColors()
        {
            dropDownColor.Items.Clear();
            dropDownColor.Items.Add("Product Color");
            foreach (string c in getColorList())
            {
                dropDownColor.Items.Add(c);
            }
        }
        protected void getProductByColor(object sender, EventArgs e)
        {
            dropDownProduct.Items.Clear();
            dropDownProduct.Items.Add("Product Name");
            string selectedColor = $"= '{dropDownColor.SelectedValue}'";
            if (dropDownColor.SelectedValue == "No Color") selectedColor = "is null";

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
            }
            SortColumn = e.SortExpression.ToString();
            SortExpression = SortColumn + SortDirection;
            gridProduct.DataSource = createDataSource(dropDownProduct.SelectedValue, SortExpression);
            gridProduct.DataBind();
        }



    }
}