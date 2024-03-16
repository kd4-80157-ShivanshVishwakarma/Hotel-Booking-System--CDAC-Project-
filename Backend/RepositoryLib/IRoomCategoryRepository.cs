using EntityModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IRoomCategoryRepository
    {
        bool AddRoomCategory(RoomCategory room);
        bool ModifyRoomCategory(RoomCategory room, int roomCatId);
        //bool RemoveRoomCategory(int roomCatId);
    }
}
