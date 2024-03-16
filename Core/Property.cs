using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string Brief { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; set; }
        public int DivisionId { get; set; }
        [JsonIgnore]
        public virtual List<SaleBatchDetail> SaleBatchDetails { get; set; }
    }
}
