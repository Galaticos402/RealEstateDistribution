using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IPaymentRecordService
    {
        void GeneratePaymentRecordForContract(Contract contract);
        List<PaymentRecord> GetPaymentRecordsOfAContract(int contractId);
    }
}
