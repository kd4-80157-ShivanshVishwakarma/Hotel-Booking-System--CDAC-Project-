using EntityModelsLib;
using System.ComponentModel.DataAnnotations;

namespace WebHotelBooking.Models
{
    public class HotelDTO
    {
        [Required]
        public string? HotelName { get; set; }

        [Required]
        [StringLength(maximumLength: 2)]
        public string? State { get; set; }

        [Required]
        [StringLength(maximumLength: 6)]
        public string? PinCode { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        [EmailAddress] 
        public string? EmailId { get; set;}

        [Required]
        public string? Description { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string? HotelImageSrc { get; set; }

        [Required]
        public IFormFile? HotelImageFile { get; set; }


        public static implicit operator Hotel(HotelDTO hotel)
        {
            Hotel htl = new Hotel();
            htl.HotelName = hotel.HotelName;
            htl.State = hotel.State;
            htl.PinCode = hotel.PinCode;
            htl.Address = hotel.Address;
            htl.Email = hotel.EmailId;
            htl.PinCode = hotel.PinCode;
            htl.Description = hotel.Description;
            htl.UserId = hotel.UserId;
            htl.HotelImageSrc = hotel.HotelImageSrc;
            return htl;
        }

    }
}
