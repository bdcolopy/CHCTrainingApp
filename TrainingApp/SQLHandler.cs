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

        // it's not a good idea to use these sorts of objects at a class level
        private static SqlCommand cmd;
        private static SqlDataReader reader;
        private static SqlConnection con;

        // it's a better idea to return a more generic return type. one example here would be returning IEnumerable<string>
        //  List implements IEnumerable, so using List inside the method to create the collection is fine, and then you can return the List collection
        //  This guarantees more of an immutable collection since IEnumerable doesn't allow adding to the collection by the client of the method 
        public static List<string> getColorList()
        {
            // a better approach to database access is to use 'using' expressions.
            // using blocks, in which an object is instantiated from a class that implements IDisposable, will automatically dispose of the object when the block is exited.
            // so, for example:
            //  using (var connection = new SqlConnection(connectionString))
            //  {
            //      connection.open();
            //      create a command
            //      execute the command, via a fill or a reader
            //      loop if necessary for all rows
            //  }
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
            return colors;      // I've been told by some folks that arrays are better performers, so returning a List as an IEnumerable can also be improved by return colors.ToArray()
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
            // unfortunately, there isn't a lot of agreement on T-SQL standards, but I find uppercasing commands, such as 'SELECT' helps with readability
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