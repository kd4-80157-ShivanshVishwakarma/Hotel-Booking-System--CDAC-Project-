using EntityModelsLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using WebHotelBooking.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHotelBooking.Controllers
{
    
    [ApiController]
    public class HotelController : ControllerBase
    {
        IHotelRepository service = new HotelRepository();
        IWebHostEnvironment _hostingEnvironment;
        public HotelController(IWebHostEnvironment _hostingEnvironment)
        {
            this._hostingEnvironment = _hostingEnvironment;
        }
        

        [HttpGet]
        [Route("/hotels/getAll")]
        public IEnumerable<Hotel> GetAllHotels()
        {
            IEnumerable<Hotel> list = service.GetAllHotels();
            if (list != null)
            {
                return list;
            }
            return null;
        }

        [HttpGet]
        [Route("/hotel/getHotelsByUserId/{userId}")]
        public IActionResult GetHotelsByUserId(int userId)
        {
            var result = service.GetAllHotelsByUserId(userId);
            return Ok(result);
        }

        [HttpGet("/hotel/GetHotelByManagerId/{id}")]
        public IEnumerable<Hotel> GetHotelByManagerId(int id)
        {
            IEnumerable<Hotel> htls = service.GetHotelByManagerId(id);
            return htls;
        }

        //[HttpPost]
        //[Route("/hotel/AddHotel")]
        //public bool AddHotel(HotelDTO hotelDto)
        //{
        //    Hotel htl = hotelDto;
        //    return service.AddHotel(htl);
        //}

        [HttpGet]
        [Route("/hotel/gethotel/{hotelId}")]
        public Hotel GetHotelById(int hotelId)
        {
            return service.GetHotel(hotelId);
        }

        [HttpPost]
        [Route("/hotel/updateHotel/{hotlId}")]
        public bool Modify(HotelDTO hotelDto,int hotlId)
        {
            Hotel htl = hotelDto;
            return service.Modify(htl,hotlId);
        }

        [HttpPost]
        [Route("/hotel/deleteHotel/{htlId}")]
        public int DeleteHotel(int htlId)
        {
            int RowsAffected = service.RemoveHotel(htlId);
            return RowsAffected;
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile hotelimageFile)
        {

            string hotelImageSrc = new string(Path.GetFileNameWithoutExtension(hotelimageFile.FileName).Take(15).ToArray()).Replace(' ', '-');
            hotelImageSrc = Path.Combine(hotelImageSrc + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(hotelimageFile.FileName));

            string s = _hostingEnvironment.ContentRootPath;
            string imagePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Image", hotelImageSrc);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await hotelimageFile.CopyToAsync(fileStream);
            }
            hotelImageSrc = string.Format("{0}://{1}/Image/{2}", Request.Scheme, Request.Host, hotelImageSrc);
            return hotelImageSrc;
        }

        [HttpPost("/hotel/AddHotel")]
        public async Task<IActionResult> AddHotel([FromForm] HotelDTO hotelDto)
        {
            hotelDto.HotelImageSrc = await SaveImage(hotelDto.HotelImageFile);
            Hotel htl = hotelDto;
            service.AddHotel(htl);
            return StatusCode(201);
        }
    }
}
