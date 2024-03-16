using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    [Table("T_Hotel")]
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }
        
        public string HotelName { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }


        [Column(name:"ManagerId")]
        public int UserId { get; set; }
        public string? HotelImageSrc { get; set; }

        public override string? ToString()
        {
            return string.Format("Id : {0}, Hotel Name : {1}, State : {2}, Pin Code : {3}, Address: {4}, Email : {5}, Description {6}, UserId : {7}", HotelId, HotelName, State, PinCode, Address, Email, Description, UserId);
        }
    }
}
