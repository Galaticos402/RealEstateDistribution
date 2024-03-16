using Core;
using Infrastructure.Exceptions;
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

        public List<Property> findByDivisionId(int divisionId)
        {
            return _propertyRepository.Filter(x => x.DivisionId == divisionId).ToList();
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

        public bool isPropertySold(int propertyId)
        {
            var property = _propertyRepository.GetById(propertyId);
            return property.IsSold;
        }

        public void updatePropertySoldStatus(int propertyId, bool soldStatus)
        {
            var property = _propertyRepository.GetById(propertyId);
            if (property == null)
            {
                throw new DBTransactionException("Cannot find property");
            }
            else
            {
                property.IsSold = soldStatus;
                _propertyRepository.Update(propertyId, property);
                _propertyRepository.Save();
            }
        }
    }
}
