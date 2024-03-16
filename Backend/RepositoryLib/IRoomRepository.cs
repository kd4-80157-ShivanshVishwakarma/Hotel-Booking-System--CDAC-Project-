using EntityModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IRoomRepository
    {
        bool AddRoom(Room room);
        bool Modify(Room room,int roomId);
        bool Remove(int roomId);
        IEnumerable<Room> TotalRooms();
        IEnumerable<Room> GetAllRoomsByHotelId(int hotelId);
    }
}
