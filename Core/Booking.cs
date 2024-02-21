using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Booking
    {
        public int SaleBatchDetailId { get; set; }
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
    }
}
