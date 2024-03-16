using EntityModelsLib;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using UtilityLib;


namespace RepositoryLib
{
    public class MembershipRepository : IMembershipRepository
    {

        static string? ConnectionDetails { get; set; }
        public MembershipRepository()
        {
            ConnectionDetails = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ErrorDB2;Integrated Security=True";
        }
        //public MembershipRepository()
        //{
        //}
        //private IConfiguration? _configuration;
        //static string? ConnectionDetails { get; set; }
        //public MembershipRepository(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    ConnectionDetails = _configuration.GetConnectionString("MyConnectionDetails");
        //}

        public bool ChangePassword(string emailId, string oldPassword, string newPassword)
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Update T_User set Password  = @newPassword where EmailId = @email and Password = @oldPassword ", connection);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
            cmd.Parameters.AddWithValue("@oldPassword", oldPassword);
            cmd.Parameters.AddWithValue("@email", emailId);
            int rowsAffected = cmd.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public bool CreateUser(string username, string password, string mobileNo, string emailId, int roleId)
        {

            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            string query = "insert into T_User(Name,Password,MobileNo,EmailId,RoleId,IsLocked) values(@Name,@Password,@MobileNo,@EmailId,@RoleId,@IsLocked)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add(new SqlParameter("@Name", username));
            command.Parameters.Add(new SqlParameter("@Password", password));
            command.Parameters.Add(new SqlParameter("@MobileNo", mobileNo));
            command.Parameters.Add(new SqlParameter("@EmailId", emailId));
            command.Parameters.Add(new SqlParameter("@RoleId", roleId));
            command.Parameters.Add(new SqlParameter("@IsLocked", false));

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected == 1)
            {
                //Console.WriteLine("Rows Affected : "+rowsAffected);
                return true;
            }
            else
            {
                //Console.WriteLine("data not entered correctly !!!");
                return false;

            }
        }

        public bool DeleteUser(string emailId)
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            string query = "delete from T_User where EmailId = @Email";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add(new SqlParameter("Email", emailId));

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowsAffected == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string GenerateOTP(string emailId)
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            string query = "select UserId from T_User where EmailId=@emailId";
            SqlCommand commnd = new SqlCommand(query, connection);
            commnd.Parameters.Add(new SqlParameter("@emailId", emailId));
            int userId = (int)commnd.ExecuteScalar();

            connection.Close();
            if (userId != 0)
            {
                connection.Open();
                string otp = OTP.GetOTP();
                string OtpQuery = "insert into T_OTP_Details(UserId,OTP,GeneratedOn,ValidTill) values(@userId,@otp,@generatedOn,@validTill)";
                SqlCommand cmnd = new SqlCommand(OtpQuery, connection);
                cmnd.Parameters.Add(new SqlParameter("@userId", userId));
                cmnd.Parameters.Add(new SqlParameter("@otp", otp));
                cmnd.Parameters.Add(new SqlParameter("@generatedOn", DateTime.Now));
                cmnd.Parameters.Add(new SqlParameter("@validTill", DateTime.Now.AddSeconds(300)));
                int RowsAffected = cmnd.ExecuteNonQuery();
                connection.Close();
                return otp;
            }
            return string.Empty;

        }

        public IEnumerable<User> GetAllUsers()
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            string query = "select * from T_User";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            List<User> users = new List<User>();

            while (reader.Read())
            {
                User user = new User();
                user.UserId = Convert.ToInt32(reader["UserId"]);
                user.Name = reader["Name"].ToString();
                user.MobileNo = reader["MobileNo"].ToString();
                user.Password = reader["Password"].ToString();
                user.EmailId = reader["EmailId"].ToString();

                users.Add(user);
            }

            connection.Close();
            return users;
        }

        public int GetNumberOfUsersOnline()
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select count(userId) from T_User where IsOnline = 1", connection);
            int count = (int)cmd.ExecuteScalar();
            connection.Close();
            return count;
        }

        //public User GetUser(string emailId)
        //{
        //    throw new NotImplementedException();
        //}

        public User GetUserByEmail(string emailToMatch)
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            SqlCommand command = new SqlCommand("select * from T_User where EmailId = @email",connection);
            command.Parameters.AddWithValue("@email", emailToMatch);

            SqlDataReader reader = command.ExecuteReader();

            User u = new User();
            if (reader.Read())
            {
                u.UserId = Convert.ToInt32(reader["UserId"]);
                u.EmailId = reader["EmailId"].ToString();
                u.Password = reader["Password"].ToString();
                u.MobileNo = reader["MobileNo"].ToString();
                u.IsOnline = Convert.ToBoolean(reader["IsOnline"]);
                u.IsLocked = Convert.ToBoolean(reader["IsLocked"]);
                u.RoleId = Convert.ToInt32(reader["RoleId"]);
                u.Name = reader["Name"].ToString();
            }
            connection.Close();
            return u;
        }

        public User GetUserByMobileNo(string mobileNo)
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            SqlCommand command = new SqlCommand("select * from T_User where MobileNo = @mobileNo", connection);
            command.Parameters.AddWithValue("@mobileNo", mobileNo);

            SqlDataReader reader = command.ExecuteReader();

            User u = new User();
            if (reader.Read())
            {
                u.UserId = Convert.ToInt32(reader["UserId"]);
                u.EmailId = reader["EmailId"].ToString();
                u.Password = reader["Password"].ToString();
                u.MobileNo = reader["MobileNo"].ToString();
                u.IsOnline = Convert.ToBoolean(reader["IsOnline"]);
                u.IsLocked = Convert.ToBoolean(reader["IsLocked"]);
                u.RoleId = Convert.ToInt32(reader["RoleId"]);
                u.Name = reader["Name"].ToString();
            }
            connection.Close();
            return u;
        }

        public bool LockUser(string emailId)
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            SqlCommand command = new SqlCommand("update T_User set IsLocked = @value where EmailId = @email", connection);
            command.Parameters.AddWithValue("@value", true);
            command.Parameters.AddWithValue("@email", emailId);

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
                return true;
            else
                return false;
        }

        public bool ResetPassword(string emailId, string otp, string newPassword)
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            string query = "select UserId from T_User where EmailId=@emailId";
            SqlCommand commnd = new SqlCommand(query, connection);
            commnd.Parameters.Add(new SqlParameter("@emailId", emailId));
            int userId = (int)commnd.ExecuteScalar();
            connection.Close();

            connection.Open();
            string query2 = "update T_User set Password=@newPassword where UserId=@userId and EXISTS (select 1 from T_OTP_Details where OTP=@otp AND GETDATE() <= ValidTill)";
            SqlCommand comnd = new SqlCommand(query2, connection);
            comnd.Parameters.Add(new SqlParameter("@newPassword", newPassword));
            comnd.Parameters.Add(new SqlParameter("@userId", userId));
            comnd.Parameters.Add(new SqlParameter("@otp", otp));
            int RowsAffected = comnd.ExecuteNonQuery();
            connection.Close();

            if (RowsAffected >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UnLockUser(string emailId)
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            SqlCommand command = new SqlCommand("update T_User set IsLocked = @value where EmailId = @email", connection);
            command.Parameters.AddWithValue("@value", false);
            command.Parameters.AddWithValue("@email", emailId);

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
                return true;
            else
                return false;
        }

        public bool UpdateUser(User user,int userId)
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            string query = "update T_User set EmailId=@emailId,MobileNo=@mobileNo,Name=@name where UserId=@userId";
            SqlCommand commnd = new SqlCommand(query, connection);
            commnd.Parameters.Add(new SqlParameter("@emailId", user.EmailId));
            commnd.Parameters.Add(new SqlParameter("@mobileNo", user.MobileNo));
            commnd.Parameters.Add(new SqlParameter("@name", user.Name));
            commnd.Parameters.Add(new SqlParameter("@userId", userId));

            int RowsAffected = commnd.ExecuteNonQuery();
            connection.Close();

            if (RowsAffected >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateUser(string emailId, string password)
        {
            SqlConnection connection = new SqlConnection(ConnectionDetails);
            connection.Open();

            string query = "select * from T_User where EmailId=@emailId";
            SqlCommand commnd = new SqlCommand(query, connection);
            commnd.Parameters.Add(new SqlParameter("@emailId", emailId));
            SqlDataReader reader = commnd.ExecuteReader();

            string passwd = string.Empty;
            while (reader.Read())
            {
                User user = new User();
                user.Password = reader["Password"].ToString();
                passwd = user.Password;
            }
            connection.Close();

            bool flag = false;
            if (passwd == password)
            {
                connection.Open();
                SqlCommand commnd2 = new SqlCommand("spForUpdateUserAsOnline", connection);

                commnd2.CommandType = System.Data.CommandType.StoredProcedure;
                commnd2.Parameters.Add(new SqlParameter("@isOnline", true));
                commnd2.Parameters.Add(new SqlParameter("@emailId", emailId));

                int RowsAffected = commnd2.ExecuteNonQuery();
                connection.Close();

                if (RowsAffected >= 1)
                    flag = true;

                return flag;
            }
            else
            {
                return false;
            }
        }
    }
}