using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Division
    {
        [Key]
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string DivisionStatus { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int? AgencyId { get; set; }
       
        public virtual List<Property> Properties { get; set; }
    }
}
