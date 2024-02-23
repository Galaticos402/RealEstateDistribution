using Core;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class SaleBatchService : ISaleBatchService
    {
        //private readonly IGenericRepository<SaleBatch> _saleBatchRepository;
        private readonly IGenericRepository<Division> _divisionRepository;
        public SaleBatchService(IGenericRepository<Division> divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }
        //private readonly IGenericRepository<Property> _propertyRepository;
        public List<SaleBatch> findAllOpenSaleBatchOfADivision(int divisionId)
        {
            List<SaleBatch> result = new List<SaleBatch>();
            var division = _divisionRepository.Filter(x => x.DivisionId == divisionId, 
                                                        0, 
                                                        int.MaxValue, 
                                                        null,
                                                        x => x.Include(p => p.Properties).ThenInclude(k => k.SaleBatchDetails).ThenInclude(t => t.SaleBatch)).FirstOrDefault();
            if(division == null || division.Properties.Count == 0) return new List<SaleBatch>();
            
            foreach (var property in division.Properties)
            {
                if (property == null || property.SaleBatchDetails.Count == 0) continue;
                foreach (var saleBatchDetail in property.SaleBatchDetails)
                {
                    if(saleBatchDetail == null || saleBatchDetail.SaleBatch == null) continue;
                    var saleBatch = saleBatchDetail.SaleBatch;
                    var today = DateTime.Now;
                    if(saleBatch.EndDate > today)
                    {
                        result.Add(saleBatch);
                    }
                    
                }
            }
            return result;
            
        }
    }
}
