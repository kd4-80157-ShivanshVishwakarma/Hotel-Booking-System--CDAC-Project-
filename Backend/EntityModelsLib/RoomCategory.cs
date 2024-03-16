using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    [Table("T_RoomCatagory")]
    public class RoomCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomCatagoryId { get; set; }
        public string? RoomCatagory { get; set; }

        public override string ToString()
        {
            return string.Format("RoomCatagoryId : {0}, RoomCatagory : {1}",RoomCatagoryId, RoomCatagory);
        }
    }
}
