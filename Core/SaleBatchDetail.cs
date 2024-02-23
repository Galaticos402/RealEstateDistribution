using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class SaleBatchDetail
    {
        [Key]
        public int SaleBatchDetailId { get; set; }
        public int SaleBatchId { get; set; }
        public int PropertyId { get; set; }
        public virtual SaleBatch SaleBatch { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
