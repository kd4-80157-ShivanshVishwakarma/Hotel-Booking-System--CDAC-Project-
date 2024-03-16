 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    [Table("T_Room")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [ForeignKey("RoomCatagoryId")]
        public int RoomCatagoryId { get; set; }
        //public RoomCatagory? RoomCat { get; set; }

        public int TotalRooms { get; set; }

        public decimal RoomPrice { get; set; }

        [ForeignKey("HotelId")]
        public int HotelId { get; set; }
        //public Hotel? Hotel { get; set; }

        public override string ToString()
        {
            return string.Format("RoomNo : {0},RoomCatagory : {1}, TotalRooms : {2}, RoomPrice : {3}, HotelId : {4}",RoomId,RoomCatagoryId, RoomCatagoryId, TotalRooms,RoomPrice,HotelId);
        }
    }
}
