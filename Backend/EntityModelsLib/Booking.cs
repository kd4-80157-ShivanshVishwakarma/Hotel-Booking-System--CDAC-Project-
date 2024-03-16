using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    [Table("T_Booking")]
    public class Booking
    {
        private int _bookingId;
        [ForeignKey("HotelId")]
        public int HotelId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("RoomId")]
        public int RoomId { get; set; }

        private DateTime _checkIn;
        private DateTime _checkOut;
        private bool _bookingStatus;
        private decimal _bookingPrice;
        private int _numberOfRoom;

        public int NumberOfRoom
        {
            get { return _numberOfRoom; }
            set { _numberOfRoom = value; }
        }


        public decimal BookingPrice
        {
            get { return _bookingPrice; }
            set { _bookingPrice = value; }
        }


        public bool BookingStatus
        {
            get { return _bookingStatus; }
            set { _bookingStatus = value; }
        }


        public DateTime CheckOut
        {
            get { return _checkOut; }
            set { _checkOut = value; }
        }


        public DateTime CheckIn
        {
            get { return _checkIn; }
            set { _checkIn = value; }
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }
        public override string? ToString()
        {
            return String.Format("BookingId:{0}, HotelId:{1}, RoomNo:{2}, UserId:{3}, CheckIn:{4}, CheckOut:{5},BookingStatus:{6}, BookingPrice:{7}, NumberOfRoom:{8}, ", _bookingId, HotelId, RoomId, UserId, _checkIn, _checkOut, _bookingStatus, _bookingPrice, _numberOfRoom);
        }

    }
}
