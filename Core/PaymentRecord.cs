using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PaymentRecord
    {
        [Key]
        public int PaymentRecordId { get; set; }
        public int ContractId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
