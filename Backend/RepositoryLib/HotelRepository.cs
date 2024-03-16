using EntityModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public class HotelRepository : IHotelRepository
    {
        public ProjectDbContext dbContext;

        public HotelRepository() {
            this.dbContext = new ProjectDbContext();
        }

        public IEnumerable<Hotel> GetHotelByManagerId(int ManagerId)
        {
            return dbContext.Hotels.ToList().Where(e => e.UserId == ManagerId).ToList();
        }

        public bool AddHotel(Hotel hotel)
        {
            dbContext.Hotels.Add(hotel);
            int RowsAffected = dbContext.SaveChanges();
            return RowsAffected>0 ? true : false;
        }

        public IEnumerable<Hotel> GetAllHotels()
        {

            return dbContext.Hotels.ToList();
        }
        public Object GetAllHotelsByUserId(int userId)
        {
            var res = (from h in dbContext.Hotels
                       join b in dbContext.Bookings
                       on h.HotelId equals b.HotelId
                       where b.UserId == userId && b.BookingStatus == true
                       select new { h.HotelName, h.Address }
                       ).ToList();
            return res;
        }
        
        public Hotel? GetHotel(int id)
        {
            return dbContext.Hotels.Find(id);
        }

        public bool Modify(Hotel hotel,int hotelId)
        {
            //Hotel htl = GetHotel(hotel.HotelId);
            //dbContext.Hotels.Add(hotel);
            Hotel? htl = dbContext.Hotels.Find(hotelId);
            htl.HotelName = hotel.HotelName;
            htl.State = hotel.State;
            htl.Address = hotel.Address;
            htl.PinCode = hotel.PinCode;
            htl.Email = hotel.Email;
            htl.Description = hotel.Description;
            htl.UserId = hotel.UserId;
            int RowsAffected = dbContext.SaveChanges();
            return RowsAffected > 0 ? true : false;
        }

        public int RemoveHotel(int hotelId)
        {
            Hotel? hotel = dbContext.Hotels.Find(hotelId);
            dbContext.Hotels.Remove(hotel);
            int RowsAffected = dbContext.SaveChanges();
            return RowsAffected;
        }
    }
}
