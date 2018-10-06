using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DAL
    {
        public string connString = ConfigurationManager.ConnectionStrings["NorthWndConn"].ConnectionString;

        public DataTable GetDataTable(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlDataAdapter dad = new SqlDataAdapter(new SqlCommand(sql, conn));

                    DataSet dst = new DataSet();
                    dad.Fill(dst);
                    return dst.Tables[0];
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataTable GetDataTable(string spName, List<SqlParameter> sqlParams)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {

                    SqlCommand cmd = new SqlCommand(spName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter param in sqlParams)
                    {
                        cmd.Parameters.Add(param);
                    }

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    DataSet dst = new DataSet();
                    dad.Fill(dst);
                    return dst.Tables[0];
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public int ExecuteSP (List<SqlParameter> sqlParams, string spName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(spName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter param in sqlParams)
                    {
                        cmd.Parameters.Add(param);
                    }
                    int retVal = 0;
                    retVal = cmd.ExecuteNonQuery();
                    conn.Close();
                    return retVal;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            
        }
        public List<Category> GetCategories()
        {
            DataTable dtbl = GetDataTable("spGetCategory");

            List<Category> categories = dtbl.DataTableToList<Category>();
            return categories;
        }

        public List<Product> GetProducts(int categoryID, string sortColumn)
        {
            string sql = "select * from Products where CategoryID=" + categoryID;
            if (!string.IsNullOrEmpty (sortColumn))
            {
                sql += " Order by " + sortColumn;
            }

            DataTable dtbl = GetDataTable(sql);
            List<Product> products = dtbl.DataTableToList<Product>();
            return products;
        }

        public int AddToShoppingCart(ShoppingCart cart)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();            
            
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Username";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Value = cart.Username;
            sqlParams.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@ProductID";
            param.SqlDbType = SqlDbType.Int;
            param.Value = cart.ProductID;
            sqlParams.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@UnitPrice";
            param.SqlDbType = SqlDbType.Money;
            param.Value = cart.UnitPrice;
            sqlParams.Add(param);

            int retVal = ExecuteSP(sqlParams, "spAddToShoppingCart");

            return retVal;
        }

        public List<ShoppingCart> GetShoppingCart(string username)
        {           
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            SqlParameter param = new SqlParameter("@Username", username);
            sqlParams.Add(param);

            DataTable dtbl = GetDataTable("spGetShoppingCart", sqlParams);

            List<ShoppingCart> shoppingCarts = dtbl.DataTableToList<ShoppingCart>();

            return shoppingCarts;
        }

        public int DeleteFromShoppingCart(string username, int productID)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Username";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Value = username;
            sqlParams.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@ProductID";
            param.SqlDbType = SqlDbType.Int;
            param.Value = productID;
            sqlParams.Add(param);

            int retVal = ExecuteSP(sqlParams, "spDeleteFromShoppingCart");

            return retVal;
        }

        public int UpdateShoppingCart(ShoppingCart cart)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Username";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Value = cart.Username;
            sqlParams.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@ProductID";
            param.SqlDbType = SqlDbType.Int;
            param.Value = cart.ProductID;
            sqlParams.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Quantity";
            param.SqlDbType = SqlDbType.Int;
            param.Value = cart.Quantity;
            sqlParams.Add(param);

            int retVal = ExecuteSP(sqlParams, "spUpdateShoppingCart");

            return retVal;
        }
    }
}