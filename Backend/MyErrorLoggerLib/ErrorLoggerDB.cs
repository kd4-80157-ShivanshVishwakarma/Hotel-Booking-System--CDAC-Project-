using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyErrorLoggerLib
{
    public sealed class ErrorLoggerDB : IErrorLogger
    {
        public string ConnectionDetails { get; set; }
        public ErrorLoggerDB() {
            ConnectionDetails = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ErrorDB2;Integrated Security=True";
        }
        public bool LogEntry(Exception e)
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            string query = "insert into T_ErrorLogs(Source,Method,ErrorOn,Message,StackTrace) values(@Source,@Method,@ErrorOn,@Message,@StackTrace)";
            SqlCommand commnd = new SqlCommand(query, connection);
            commnd.Parameters.Add(new SqlParameter("@Source", e.Source == null ? DBNull.Value : e.Source));
            commnd.Parameters.Add(new SqlParameter("@Method", "Method"));
            commnd.Parameters.Add(new SqlParameter("@ErrorOn", DateTime.Now));
            commnd.Parameters.Add(new SqlParameter("@Message", e.Message));
            commnd.Parameters.Add(new SqlParameter("@StackTrace", e.StackTrace));

            int RowsAffected = commnd.ExecuteNonQuery();
            connection.Close();

            if (RowsAffected>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
