using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    public class HotelAmenities
    {

        public int HotelAmenityId { get; set; }

        public Hotel? HotelId { get; set; }

        public Amenities? AmenityId { get; set; }

        public Byte[]? AmenityPhoto { get; set; }

        public override string? ToString()
        {
            return String.Format("HotelAmenityId : {0}, HotelId : {1}, AmenityId : {2}, AmenityPhoto : {3}", HotelAmenityId, HotelId.ToString(), AmenityId, AmenityPhoto);
        }
    }
}
