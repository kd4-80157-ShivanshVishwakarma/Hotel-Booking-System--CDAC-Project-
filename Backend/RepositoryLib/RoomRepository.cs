using EntityModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public class RoomRepository : IRoomRepository
    {
        ProjectDbContext dbContext;
        public RoomRepository()
        {
            dbContext = new ProjectDbContext();
        }

        public bool AddRoom(Room room)
        {
            dbContext.Rooms.Add(room);
            int RowsAffected = dbContext.SaveChanges();
            return RowsAffected > 0 ? true : false;
        }

        public bool Modify(Room room, int roomId)
        {
            Room _room = dbContext.Rooms.Find(roomId);
            _room.TotalRooms = room.TotalRooms;
            _room.RoomPrice = room.RoomPrice;
            int RowsAffected = dbContext.SaveChanges();
            return RowsAffected > 0 ? true : false;
        }

        public bool Remove(int roomId)
        {
            Room room = dbContext.Rooms.Find(roomId);
            dbContext.Rooms.Remove(room);
            int RowsAffected = dbContext.SaveChanges();
            return RowsAffected > 0 ? true : false;
        }

        public IEnumerable<Room> TotalRooms()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetAllRoomsByHotelId(int hotelId)
        {
            IEnumerable<Room> listOfRooms = dbContext.Rooms.ToList();
            return listOfRooms.Where(room => room.HotelId == hotelId).ToList();
        }
    }
}
