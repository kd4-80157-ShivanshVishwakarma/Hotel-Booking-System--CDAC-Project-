using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public User? UserId { get; set; }
        public Booking? BookingId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        public override string? ToString()
        {
            return String.Format("Id : {0}, Customer Id : {1}, BookingId : {2}, Amount : {3}, Date : {4}, Status : {5}, ", PaymentId, UserId, BookingId, Amount, Date, Date);
        }
    }
}
