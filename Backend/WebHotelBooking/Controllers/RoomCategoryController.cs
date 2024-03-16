using EntityModelsLib;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using WebHotelBooking.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHotelBooking.Controllers
{
    [ApiController]
    public class RoomCategoryController : ControllerBase
    {
        IRoomCategoryRepository service = new RoomCategoryRepository();

        [HttpPost]
        [Route("roomcatagory/addRoomCategory")]
        public bool AddRoomCategory(RoomCategoryDTO rmCatDto)
        {
            RoomCategory rmCat = rmCatDto;
            return service.AddRoomCategory(rmCat);
        }
        [HttpPost]
        [Route("roomcatagory/updateRoomCategory/{roomCatId}")]
        public bool UpdateRoomCategory(RoomCategoryDTO rmCatDto,int roomCatId)
        {
            RoomCategory rmCat = rmCatDto;
            return service.ModifyRoomCategory(rmCat,roomCatId);
        }
    }
}
