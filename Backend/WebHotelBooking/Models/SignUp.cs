using System.ComponentModel.DataAnnotations;

namespace WebHotelBooking.Models
{
    public class SignUp
    {
        [Required]
        public string UserName { get; set; }
         
        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(10)]
        public string MobileNo { get; set; }
        
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
