using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    [Table("T_HotelReview")]
    public class HotelReview
    {
        private int _hotelReviewId;
        private Decimal _hotelRating;
        private String? _hotelComment;


        public int HotelId { get; set; }

        public int UserId { get; set; }
        public String? HotelComment
        {
            get { return _hotelComment; }
            set { _hotelComment = value; }
        }
        public Decimal HotelRating
        {
            get { return _hotelRating; }
            set { _hotelRating = value; }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelReviewId
        {
            get { return _hotelReviewId; }
            set { _hotelReviewId = value; }
        }

        public override string? ToString()
        {
            return String.Format("HotelReviewId:{0}, HotelRating:{1}, HotelComment:{2}, Hotel:{3}, User:{4}", _hotelReviewId, _hotelRating, _hotelComment, HotelId, UserId);
        }
    }
}
