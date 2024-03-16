using EntityModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IHotelRepository
    {
        bool AddHotel(Hotel hotel);
        bool Modify(Hotel hotel,int hotelId);
        Hotel GetHotel(int hotelId);
        IEnumerable<Hotel> GetAllHotels();
        Object GetAllHotelsByUserId(int userId);
        int RemoveHotel(int hotelId);
        IEnumerable<Hotel> GetHotelByManagerId(int id);
    }
}
