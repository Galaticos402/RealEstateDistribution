using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core
{
    public class SaleBatch
    {
        [Key]
        public int SaleBatchId { get; set; }
        public string SaleBatchName { get; set; }
        public decimal BookingFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [JsonIgnore]
        public virtual List<SaleBatchDetail> SaleBatchDetails { get; set; }
        [JsonIgnore]
        public virtual List<Booking> Bookings { get; set; }
    }
}
