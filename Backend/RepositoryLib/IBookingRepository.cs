using EntityModelsLib;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IBookingRepository
    {
        public bool AddBooking(Booking booking);
        public IEnumerable<Booking> GetBookings();
        public Object GetBookingByUserId(string email);
        public IEnumerable<Booking> GetBookingByHotelId(int HotelId);
        public IEnumerable<Booking> GetBookingByRoomId(int Id);
        public int RemoveBooking(int Id);
    }
}
