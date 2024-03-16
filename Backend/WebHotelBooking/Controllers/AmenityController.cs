using EntityModelsLib;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using WebHotelBooking.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHotelBooking.Controllers
{
    [ApiController]
    public class AmenityController : ControllerBase
    {
        IAmenityRepository service = new AmenityRepository();

        [HttpGet]
        [Route("amenity/GetAll")]
        public IEnumerable<Amenities> GetAllAmenities()
        {
            return service.GetAllAmenities();
        }

        [HttpPost]
        [Route("amenity/AddAmenity")]
        public void AddAmenity([FromBody] AmenityDTO amenity)
        {
            Amenities amty = amenity;
            service.AddAmenity(amty);
        }

        [HttpPut("amenity/UpdateAmenity{id}")]

        public void UpdateAmenity(int AmenityId, [FromBody] Amenities amenities)
        {
            Amenities amty = amenities;
            service.UpdateAmenity(AmenityId, amenities);
        }

        [HttpDelete("amenity/DeleteAmenity{id}")]

        public void Delete(int AmenityId)
        {
            service.DeleteAmenity(AmenityId);
        }
    }
}
