using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    public class OtpDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OTP { get; set; }
        public DateTime GeneratedOn { get; set; }
        public DateTime ValidTill { get; set; }

        public override string ToString()
        {
            return String.Format("Id:{0},UserId:{1},OTP:{2},GeratedOn:{3},ValidTill:{4}", Id, UserId, OTP, GeneratedOn, ValidTill);
        }
    }
}
