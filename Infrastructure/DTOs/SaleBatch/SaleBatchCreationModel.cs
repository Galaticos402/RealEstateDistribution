using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs.SaleBatch
{
    public class SaleBatchCreationModel
    {
        public string SaleBatchName { get; set; }
        public decimal BookingFee { get; set; }
        public DateTime PremiumStartDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string ReceiverName { get; set; }
    }
}
