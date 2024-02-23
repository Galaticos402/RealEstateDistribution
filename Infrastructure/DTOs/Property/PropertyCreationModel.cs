using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs.Property
{
    public class PropertyCreationModel
    {
        public string PropertyName { get; set; }
        public string Brief { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        public int DivisionId { get; set; }
    }
}
