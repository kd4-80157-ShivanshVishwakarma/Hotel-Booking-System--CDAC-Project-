using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    [Table("T_Roles")]
    public class Role
    {
        public Role()
        { }
        public Role(string roleName)
        {
            RoleName = roleName;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public override string? ToString()
        {
            return String.Format("RoleId:{0}, RoleName:{1}", RoleId, RoleName);
        }


    }
}
