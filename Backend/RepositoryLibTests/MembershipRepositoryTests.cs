using EntityModelsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLib;
using static System.Net.WebRequestMethods;

namespace RepositoryLib.Tests
{
    [TestClass()]
    public class MembershipRepositoryTests
    {
        IMembershipRepository memrepo = new MembershipRepository();

        //[TestMethod()]
        //public void ValidateUserTest()
        //{
        //    Assert.AreEqual(true, memrepo.ValidateUser("kunal@gmail.com", "4572"));
        //}

        //[TestMethod()]
        //public void UpdateUserTest()
        //{
        //    User user = new User();
        //    user.UserId = 10;
        //    user.Name = "Suryansh";
        //    user.EmailId = "suryansh@gmail.com";
        //    user.MobileNo = "9921547896";
        //    Assert.AreEqual(true, memrepo.UpdateUser(user));
        //}

        //[TestMethod()]
        //public void GenerateOTPTest()
        //{
        //    Assert.AreEqual(true, memrepo.GenerateOTP("suryansh@gmail.com"));
        //}

        [TestMethod()]
        public void ResetPasswordTest()
        {
            string otp = memrepo.GenerateOTP("suryansh@gmail.com");
            Assert.AreEqual(true, memrepo.ResetPassword("suryansh@gmail.com", otp, "4827"));
        }

    }
}