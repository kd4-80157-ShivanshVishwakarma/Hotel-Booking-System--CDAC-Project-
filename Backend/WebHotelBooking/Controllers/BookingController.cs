﻿using EntityModelsLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using WebHotelBooking.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHotelBooking.Controllers
{
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        IBookingRepository service = new BookingRepository();

        [HttpPost]
        [Route("booking/add")]
        public bool AddBooking(BookingDTO booking)
        {
            Booking obj = booking;
            obj.BookingStatus = true;
            bool result = service.AddBooking(obj);
            return result;
        }
        [HttpDelete]
        [Route("/booking/delete/{bookingid}")]
        public bool CancelBooking(int bookingid)
        {
            int affectedrows = service.RemoveBooking(bookingid);
            return affectedrows > 0 ? true : false;
        }

        [HttpGet]
        [Route("/booking/getall")]
        public IEnumerable<Booking> GetBookings()
        {
            return service.GetBookings();
        }
        [HttpGet]
        [Route("/booking/getbyemail/{emailId}")]
        public IActionResult GetBookingByUserId(string emailId)
        {
            var r = service.GetBookingByUserId(emailId);
            return Ok(r);
        }
        [HttpGet]
        [Route("/booking/getbyroomid/{roomid}")]
        public IEnumerable<Booking> GetByRoomId(int roomid)
        {
            return service.GetBookingByRoomId(roomid);
        }
        [HttpGet]
        [Route("/booking/getbyhotelid/{hotelid}")]
        public IEnumerable<Booking> GetByHotelId(int hotelid)
        {
            return service.GetBookingByHotelId(hotelid);
        }
    }
}
