using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib
{
    public class Roles
    {
        public string connectionDetails { get; set; }
        public Roles() {
            connectionDetails = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ErrorDB2;Integrated Security=True";
        }
        public bool InsertRole(string role)
        {

            SqlConnection con = new SqlConnection(connectionDetails);
            con.Open();

            SqlCommand commnd = new SqlCommand("spInsertRole", con);
            commnd.CommandType = System.Data.CommandType.StoredProcedure;

            commnd.Parameters.AddWithValue("@role", role);

            int RowsAffected = commnd.ExecuteNonQuery();
            con.Close();

            if (RowsAffected >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public bool UpdateRole(int roleid,string role) {
            
        //}


    }
}
