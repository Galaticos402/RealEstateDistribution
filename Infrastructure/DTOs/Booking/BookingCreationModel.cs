using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs.Booking
{
    public class BookingCreationModel
    {
        public int SaleBatchDetailId { get; set; }
        public int CustomerId { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
