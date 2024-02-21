using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public int DivisionId { get; set; }
        public virtual List<SaleBatchDetail> SaleBatchDetails { get; set; }
    }
}
