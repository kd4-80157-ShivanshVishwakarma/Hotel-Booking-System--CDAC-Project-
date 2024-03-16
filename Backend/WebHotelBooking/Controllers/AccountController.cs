using EntityModelsLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepositoryLib;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using UtilityLib;
using WebHotelBooking.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IConfiguration config;
        MembershipRepository service;
        RoleRepository RoleService;
        public AccountController(IConfiguration config)
        {
            this.config = config;
            service = new MembershipRepository();
            RoleService = new RoleRepository();
        }


        // POST api/<AccountController>
        [HttpPost]
        [AllowAnonymous]
        [Route("/users/login")]
        public IActionResult Post(Login value)
        {
            IActionResult response = Unauthorized();
            bool result = false;
            if (ModelState.IsValid)
            {
                result = service.ValidateUser(value.EmailId, value.Password);

                if (result)
                {
                    var roleId = RoleService.getRoleByEmail(value.EmailId);
                    var token = GenerateJwtToken(value.EmailId);
                    User usr = new User();
                    usr= service.GetUserByEmail(value.EmailId);
                    return Ok(new { Token = token,Role=roleId,UserId = usr.UserId,Name=usr.Name });
                }
            }
            return response;
        }

        private string GenerateJwtToken(string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };

            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("/users/signup")]
        public bool SignUp(SignUp value)
        {
            if (ModelState.IsValid)
            {
                bool flag = service.CreateUser(value.UserName,value.Password,value.MobileNo,value.EmailId,value.RoleId);
                return flag;
            }
            return false;
        }

        [HttpPost]
        [Route("/users/ChangePassword")]
        public bool ChangePassword(ChangePassword value)
        {
            if (ModelState.IsValid)
            {
                bool flag = service.ChangePassword(value.EmailID,value.OldPassword,value.NewPassword);
                return flag;
            }
            return false;
        }

        [HttpGet]
        [Route("/users/forgotPassword/{email}")]
        public bool ForgotPassword(string email)
        {
            User? user = null;
            user = service.GetUserByEmail(email);

            if (user.UserId != 0)
            {
                try
                {
                    using (System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com"))
                    {
                        string TempOtp = service.GenerateOTP(email);
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress("shivanshvishwakarma59@gmail.com");
                        mailMessage.To.Add(email);
                        mailMessage.Subject = "Password Reset";
                        mailMessage.Body = $"Dear User, your OTP for Reset Password is {TempOtp}. Do Not share this one time OTP to anyone!";

                        smtpClient.Port = 587;
                        smtpClient.Credentials = new NetworkCredential("shivanshvishwakarma59@gmail.com", "olhq mtfb hasx oagu");
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(mailMessage);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Email sending error: {ex.Message}");
                }
            }
            return false;
        }

        [HttpPost]
        [Route("/users/resetPassword")]
        public bool ResetPassword(ResetPassword rstPass)
        {
            bool flag = service.ResetPassword(rstPass.EmailId, rstPass.OTP, rstPass.NewPassword);
            if (flag)
            {
                return true;
            }
            return false;
        }

        //[HttpPost]
        //[Route("/users/OtpGenerate/{emailId}")]
        //public string OtpGenerate(string emailId)
        //{
        //    Regex regx = new Regex("^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$");
        //    bool match = regx.IsMatch(emailId);
        //    if(match)
        //    {
        //        string TempOtp = service.GenerateOTP(emailId);
        //        return TempOtp;
        //    }
        //    return "Please Enter the correct EmailId or Resend the OTP!";
        //}

        //[HttpPost]
        //[Route("/users/ResetPassword")]
        //public bool ResetPassword(ResetPassword value)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bool flag = service.ResetPassword(value.EmailId, value.OTP, value.NewPassword);
        //        return flag;
        //    }
        //    return false;
        //}
    }
}
