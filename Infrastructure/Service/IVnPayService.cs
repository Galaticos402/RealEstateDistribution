using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IVnPayService
    {
        public string GetPaymentUrl(int saleBatchId, int customerId, int amount);
    }
}
