using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs.Division
{
    public class DivisionCreationModel
    {
        public string DivisionName { get; set; }
        public string DivisionStatus { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int? AgencyId { get; set; }

    }
}
