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
    public class PropertyService : IPropertyService
    {
        private readonly IGenericRepository<Property> _propertyRepository;
        private readonly IGenericRepository<SaleBatchDetail> _saleBatchDetailRepository;
        public PropertyService(IGenericRepository<Property> propertyRepository, IGenericRepository<SaleBatchDetail> saleBatchDetailRepository)
        {
            _saleBatchDetailRepository = saleBatchDetailRepository;
            _propertyRepository = propertyRepository;
        }
        public List<Property> findPropertiesOfASaleBatch(int saleBatchId)
        {
            List<Property> properties = new List<Property>();
            var saleBatchDetails = _saleBatchDetailRepository.Filter(sbd => sbd.SaleBatchId == saleBatchId, 0, int.MaxValue, null, sbd => sbd.Include(x => x.Property)).ToList();
            if (saleBatchDetails == null) return properties;
            foreach(var saleBatchDetail in saleBatchDetails) {
                if(saleBatchDetail.Property == null)  continue;
                properties.Add(saleBatchDetail.Property);
            }
            return properties;
        }
    }
}
