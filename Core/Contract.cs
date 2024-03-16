using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        public int CustomerId { get; set; }
        public int PropertyId { get; set; }
        public decimal ListedPrice { get; set; }
        public int Duration { get; set; }
        public int Period { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Property Property { get; set; }
        public virtual List<PaymentRecord> PaymentRecords { get; set; }
    }
}
