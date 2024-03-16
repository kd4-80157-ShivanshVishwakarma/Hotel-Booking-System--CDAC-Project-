using EntityModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public class RoomCategoryRepository : IRoomCategoryRepository
    {
        ProjectDbContext dbContext;
        public RoomCategoryRepository()
        {
            dbContext = new ProjectDbContext();
        }

        public bool AddRoomCategory(RoomCategory roomCat)
        {
            dbContext.RoomCategories.Add(roomCat);
            int RowsAffected = dbContext.SaveChanges();
            return RowsAffected > 0 ? true : false;
        }

        public bool ModifyRoomCategory(RoomCategory roomCat, int roomCatId)
        {
            RoomCategory _roomCat = dbContext.RoomCategories.Find(roomCatId);
            _roomCat.RoomCatagory = roomCat.RoomCatagory;
            int RowsAffected = dbContext.SaveChanges();
            return RowsAffected > 0 ? true : false;
        }

        //public bool Remove(int roomId)
        //{
        //    RoomCategory room = dbContext.RoomCategories.Find(roomId);
        //    dbContext.Rooms.Remove(room);
        //    int RowsAffected = dbContext.SaveChanges();
        //    return RowsAffected > 0 ? true : false;
        //}
    }
}
