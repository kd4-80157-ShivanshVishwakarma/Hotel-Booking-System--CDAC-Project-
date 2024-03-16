using EntityModelsLib;
using System.ComponentModel.DataAnnotations;

namespace WebHotelBooking.Models
{
    public class HotelReviewDTO
    {
        [Required]
        [Range(1,5)]
        public Decimal HotelRating { get; set; }

        [Required]
        public String HotelComment { get; set; }

        [Required]
        public int UserId { get; set; }

        public static implicit operator HotelReview(HotelReviewDTO hotelReviewDTO)
        {
            HotelReview hotelReview = new HotelReview();
            hotelReview.HotelRating = hotelReviewDTO.HotelRating;
            hotelReview.HotelComment = hotelReviewDTO.HotelComment;
            hotelReview.UserId = hotelReviewDTO.UserId;
            return hotelReview;
        }
    }
}
