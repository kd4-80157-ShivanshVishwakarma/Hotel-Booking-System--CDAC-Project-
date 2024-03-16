using EntityModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IMembershipRepository
    {
        bool LockUser(string emailId);
        bool UnLockUser(string emailId);
        bool ValidateUser(string emailId, string password);
        bool CreateUser(string username,string password, string mobileNo, string emailId,int roleId);
        bool ChangePassword(string emailId, string oldPassword, string newPassword);
        int GetNumberOfUsersOnline();//--
        bool UpdateUser(User user,int userId);//--
        IEnumerable<User> GetAllUsers();
        //User GetUser(string emailId);
        User GetUserByEmail(string emailToMatch);
        User GetUserByMobileNo(string mobileNo);
        string GenerateOTP(string emailId);
        bool ResetPassword(string emailId, string otp, string newPassword);
        bool DeleteUser(string emailId);//--

    }
}
