using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs.Contract
{
    public class ContractCreationModel
    {
        public int PropertyId { get; set; }
        public decimal ListedPrice { get; set; }
        public int Duration { get; set; }
        public int Period { get; set; }
    }
}
