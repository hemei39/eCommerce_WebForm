using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAPI.Models
{
    public class DAL
    {
        public string connString = ConfigurationManager.ConnectionStrings["NorthWndConn"].ConnectionString;

        public DataTable GetDataTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter dad = new SqlDataAdapter(new SqlCommand(sql, conn));

                DataSet dst = new DataSet();
                dad.Fill(dst);
                return dst.Tables[0];
            }
        }

        public DataTable GetDataTable(string spName, List<SqlParameter> sqlParams)
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

        
        

        public List<ShoppingCart> GetShoppingCart(string username)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            SqlParameter param = new SqlParameter("@Username", username);
            sqlParams.Add(param);

            DataTable dtbl = GetDataTable("spGetShoppingCart", sqlParams);

            List<ShoppingCart> shoppingCarts = dtbl.DataTableToList<ShoppingCart>();

            return shoppingCarts;
        }

        

        
    }
}