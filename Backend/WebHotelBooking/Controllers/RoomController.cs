using EntityModelsLib;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using WebHotelBooking.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHotelBooking.Controllers
{
    [ApiController]
    public class RoomController : ControllerBase
    {
        IRoomRepository service = new RoomRepository();
        

        // POST api/<RoomController>
        [HttpPost]
        [Route("/room/addRoom")]
        public bool AddRoom(RoomDTO roomDto)
        {
            Room room = roomDto;
            return service.AddRoom(room);
        }

        [HttpPost]
        [Route("/room/modifyRoom/{roomId}")]
        public bool ModifyRoom(RoomDTO roomDto , int roomId)
        {
            Room room = roomDto;
            return service.Modify(room, roomId);
        }

        [HttpDelete]
        [Route("/room/removeRoom/{roomId}")]
        public bool DeleteRoom(int roomId)
        {
            return service.Remove(roomId);
        }

        [HttpGet]
        [Route("/room/getAllRoomsByHotelId/{HotelId}")]
        public IEnumerable<Room> GetAllRoomsByHotelId(int HotelId)
        {
            return service.GetAllRoomsByHotelId(HotelId);
        }
    }
}
