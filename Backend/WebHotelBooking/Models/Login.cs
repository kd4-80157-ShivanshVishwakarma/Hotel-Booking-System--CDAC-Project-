using System.ComponentModel.DataAnnotations;

namespace WebHotelBooking.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string? EmailId { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
