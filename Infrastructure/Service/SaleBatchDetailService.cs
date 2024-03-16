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
    public class SaleBatchDetailService : ISaleBatchDetailService
    {
        private readonly IGenericRepository<SaleBatchDetail> _saleBatchDetailRepository;
        public SaleBatchDetailService(IGenericRepository<SaleBatchDetail> saleBatchDetailRepository)
        {
            _saleBatchDetailRepository = saleBatchDetailRepository;
        }
        public List<SaleBatchDetail> findSaleBatchDetailsBySaleBatchId(int saleBatchId)
        {
            return _saleBatchDetailRepository.Filter(x => x.SaleBatchId == saleBatchId, 0, int.MaxValue, null, x => x.Include(k => k.Property)).ToList();
        }
    }
}
