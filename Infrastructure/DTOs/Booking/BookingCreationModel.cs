using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs.Booking
{
    public class BookingCreationModel
    {
        public int SaleBatchId { get; set; }
        public bool IsPaid { get; set; }
    }
}
