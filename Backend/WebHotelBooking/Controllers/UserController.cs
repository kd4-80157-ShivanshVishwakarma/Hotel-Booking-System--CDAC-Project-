using EntityModelsLib;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using System.Net;
using System.Net.Mail;
using UtilityLib;
using WebHotelBooking.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        MembershipRepository service;
        public UserController()
        {
            service = new MembershipRepository();
        }
        [HttpGet]
        [Route("/users/allUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> list = service.GetAllUsers();
            if (list != null)
            {
                return list;
            }
            return null;
        }
        [HttpGet]
        [Route("/users/getByEmail/{email}")]
        public User GetUserByEmail(string email)
        {
            User user = service.GetUserByEmail(email);
            return user;
        }

        [HttpGet]
        [Route("/users/getByMobileNo/{number}")]
        public User GetUserByMobileNo(string number)
        {
            User user = service.GetUserByMobileNo(number);
            return user;
        }

        [HttpPost]
        [Route("/users/updateUser/{userid}")]
        public bool UpdateUser(UserDTO user,int userid)
        {
            User usr = user;
            bool flag = service.UpdateUser(user, userid);
            return flag;
        }

        [HttpPost]
        [Route("/users/deleteUser")]
        public bool DeleteUser(string emailId)
        {
            bool flag = service.DeleteUser(emailId);
            return flag;
        }

        [HttpGet]
        [Route("/users/getOnlineUsers")]
        public int GetOnlineUsers() {
            int listOfOnlineUsers = service.GetNumberOfUsersOnline();

            if (listOfOnlineUsers != 0) { return listOfOnlineUsers; }
            return listOfOnlineUsers;
        }
    }
}
/*
 private void SendPasswordResetEmail(string userEmail)
{
    try
    {
        // Set up your SMTP client and credentials
        using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
        {
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("yourEmailAddress@gmail.com", "yourEmailPassword");
            smtpClient.EnableSsl = true;

            // Create the email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("yourEmailAddress@gmail.com");
            mailMessage.To.Add(userEmail);
            mailMessage.Subject = "Password Reset";
            mailMessage.Body = "Click the link to reset your password: [reset link here]";

            // Send the email
            smtpClient.Send(mailMessage);
        }
    }
    catch (Exception ex)
    {
        // Handle exceptions (log or return an error)
        Console.WriteLine($"Error sending email: {ex.Message}");
    }
}
 */