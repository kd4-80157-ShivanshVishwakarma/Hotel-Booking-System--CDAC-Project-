using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModelsLib
{
    [Table("T_User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string? EmailId { get; set; }

        public string? Password { get; set; }

        public string? MobileNo { get; set; }

        public bool IsOnline { get; set; }

        public bool? IsLocked { get; set; }

        public int RoleId { get; set; }

        public string? Name { get; set; }

        public override string ToString()
        {
            return string.Format("UserId : {0}, EmailId : {1}, Password : {2}, MobileNo : {3}, IsOnline : {4}, IsLocked : {5}, RoleId : {6}, Name : {7}",UserId,EmailId,Password,MobileNo,IsOnline,IsLocked,RoleId,Name);
        }
    }
}