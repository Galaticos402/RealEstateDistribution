using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IPropertyService
    {
        List<Property> findPropertiesOfASaleBatch(int saleBatchId);
        void updatePropertySoldStatus(int propertyId, bool soldStatus);
        bool isPropertySold(int propertyId);
        List<Property> findByDivisionId(int divisionId);
    }
}
