using System.ComponentModel.DataAnnotations;

namespace WebHotelBooking.Models
{
    public class ResetPassword
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 5)]
        public string OTP { get; set; }

        [Required]
        [StringLength(maximumLength:20,MinimumLength =8)]
        public string NewPassword { get; set; }
    }
}
