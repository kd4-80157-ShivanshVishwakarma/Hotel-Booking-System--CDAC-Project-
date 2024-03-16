using EntityModelsLib;
using System.ComponentModel.DataAnnotations;

namespace WebHotelBooking.Models
{
    public class AmenityDTO
    {
        [Required]
        public String? AmenityDesc { get; set; }

        public static implicit operator Amenities(AmenityDTO amenityDto)
        {
            Amenities amty = new Amenities();
            amty.AmenityDesc = amenityDto.AmenityDesc;
            return amty;
        }
    }
}
