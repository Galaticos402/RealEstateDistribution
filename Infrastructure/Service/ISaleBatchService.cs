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
        public List<SaleBatch> findAvailableSaleBatchOfADivision(int divisionId);
        public List<SaleBatch> findOpeningSaleBatchOfADivision(int divisionId);
        public List<SaleBatch> findUpcomingSaleBatchOfADivision(int divisionId);
    }
}
