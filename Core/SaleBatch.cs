using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class SaleBatch
    {
        [Key]
        public int SaleBatchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual List<SaleBatchDetail> SaleBatchDetails { get; set; }
    }
}
