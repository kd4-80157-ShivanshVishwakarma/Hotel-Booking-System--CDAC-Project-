using Azure.Core;
using EntityModelsLib;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public class BookingRepository : IBookingRepository
    {
        public ProjectDbContext dbContext;
        IMembershipRepository service=new MembershipRepository();
        public BookingRepository()
        {
            dbContext = new ProjectDbContext();
        }
        public bool AddBooking(Booking booking)
        {
            dbContext.Bookings.Add(booking);
            int affectedrows = dbContext.SaveChanges();
            if (affectedrows > 0)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Booking> GetBookingByHotelId(int HotelId)
        {
            return dbContext.Bookings.ToList().Where(e => e.HotelId == HotelId).ToList();
        }

        public IEnumerable<Booking> GetBookingByRoomId(int Id)
        {
            return dbContext.Bookings.ToList().Where(e => e.RoomId == Id).ToList();
        }

        public Object GetBookingByUserId(string email)
        {

            User usr = service.GetUserByEmail(email);
            var res = (from b in dbContext.Bookings
                       join h in dbContext.Hotels
                       on b.HotelId equals h.HotelId
                       where b.UserId == usr.UserId
                       select new { b.UserId,b.RoomId,b.BookingId,b.BookingStatus,b.BookingPrice,b.CheckIn,b.CheckOut,h.HotelName});

            return res;
        }

        public IEnumerable<Booking> GetBookings()
        {
            return dbContext.Bookings.ToList();
        }

        public int RemoveBooking(int Id)
        {
            Booking? booking = dbContext.Bookings.Find(Id);
            booking.BookingStatus = false;
            return dbContext.SaveChanges();
        }
    }
}
