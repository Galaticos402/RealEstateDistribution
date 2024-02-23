using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface ISaleBatchService 
    {
        public List<SaleBatch> findAllOpenSaleBatchOfADivision(int divisionId);
    }
}
