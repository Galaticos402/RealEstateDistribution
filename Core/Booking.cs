using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int SaleBatchId { get; set; }
        public int CustomerId { get; set; }
        public bool IsPaid { get; set; }
        public DateTime BookingDate { get; set; }
        public virtual SaleBatch SaleBatch { get; set; }
        public virtual Customer Customer { get; set; } 
        
    }
}
