using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    public class PasswordHistoryLog
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime ChangedOn { get; set; }

        public String? OldPassword { get; set; }

        public String? NewPassword { get; set; }

        public override string? ToString()
        {
            return String.Format("Id : {0}, UserId : {1}, ChangedOn : {2}, OldPassword : {3}, NewPassword : {4}", Id, UserId, ChangedOn, OldPassword, NewPassword);
        }
    }
}
