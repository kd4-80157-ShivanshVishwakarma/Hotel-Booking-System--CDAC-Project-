using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    [Table("T_Amenities")]
    public class Amenities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AmenityId { get; set; }

        public string? AmenityDesc { get; set; }

        public override string? ToString()
        {
            return String.Format("AmenityId : {0}, AmenityDesc : {1}", AmenityId, AmenityDesc);
        }
    }
}

