using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrainingApp
{
    public class SQLHandler
    {
        private static string connection = ConfigurationManager.ConnectionStrings["ConnectStrDB"].ConnectionString;
        private static SqlCommand cmd;
        private static SqlDataReader reader;
        private static SqlConnection con;

        public static List<string> getColorList()
        {
            string selectSQL = "select distinct pp.Color from Production.Product pp where exists (select * from Production.WorkOrder wo where pp.ProductID = wo.ProductID) ";
            List<string> colors = new List<string>();
            DBConnect(selectSQL);
            
            while (reader.Read())
            {
                string newColor = reader["Color"].ToString();
                if (newColor == "") newColor = "No Color";
                colors.Add(newColor);
            }

            DisposeClose();
            return colors;
        }

        public static List<string> getProductList(string color)
        {
            string selectSQL = $"select distinct pp.Name from Production.Product pp where exists (select * from Production.WorkOrder wo where pp.ProductID = wo.ProductID)  and pp.color {color}";
            List<string> products = new List<string>();
            DBConnect(selectSQL);

            while (reader.Read())
            {
                products.Add(reader["Name"].ToString());
            }

            DisposeClose();
            return products;
        }

        public static ICollection createDataSource(string productName, string sortExpression)
        {
            string selectSQL = "select StartDate, DueDate, OrderQty from Production.WorkOrder wo " +
                            "join Production.Product pp on wo.ProductID = pp.ProductID " +
                            $"where pp.Name = '{productName}' order by wo.DueDate";         
            DBConnect(selectSQL);

            DataTable productTable = new DataTable();
            productTable.Columns.Add("Start Date").DataType = Type.GetType("System.DateTime");
            productTable.Columns.Add("Due Date").DataType = Type.GetType("System.DateTime");
            productTable.Columns.Add("Order Quantity").DataType = Type.GetType("System.Int32");
            while (reader.Read())
            {
                productTable.Rows.Add(reader["StartDate"], reader["DueDate"], reader["OrderQty"]);
            }

            DataView dv = new DataView(productTable);
            dv.Sort = sortExpression;

            DisposeClose();
            return dv;
        }

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
    }
}