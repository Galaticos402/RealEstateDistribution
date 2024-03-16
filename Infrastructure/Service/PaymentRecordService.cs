using Core;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class PaymentRecordService : IPaymentRecordService
    {
        private readonly IGenericRepository<PaymentRecord> _paymentRecordRepository;
        public PaymentRecordService(IGenericRepository<PaymentRecord> paymentRecordRepository)
        {
            _paymentRecordRepository = paymentRecordRepository;
        }
        public void GeneratePaymentRecordForContract(Contract contract)
        {
            int contractId = contract.ContractId;
            decimal totalAmount = contract.ListedPrice;
            int duration = contract.Duration; // Calculate in month
            int remainingDuration = duration;
            int period = contract.Period;  // Calculate in month
            int numberOfPaymentRecord = duration/period;
            DateTime currentStartDate = DateTime.Now;

            List<PaymentRecord> records = new List<PaymentRecord>();

            for (int i = 0; i < numberOfPaymentRecord; i++)
            {
                if (i == numberOfPaymentRecord - 1)
                {
                    var lastRecord = new PaymentRecord {
                        ContractId = contractId,
                        Amount = totalAmount / numberOfPaymentRecord,
                        StartDate = currentStartDate,
                        DueDate = currentStartDate.AddMonths(remainingDuration),
                    };
                    records.Add(lastRecord);
                    _paymentRecordRepository.InsertMulti(records);
                    _paymentRecordRepository.Save();
                    break;
                }
                var paymentRecord = new PaymentRecord { 
                    ContractId = contractId,
                    Amount = totalAmount / numberOfPaymentRecord,
                    StartDate = currentStartDate,
                    DueDate = currentStartDate.AddMonths(period),
                };
                records.Add(paymentRecord);
                // Update startDate
                currentStartDate = currentStartDate.AddMonths(period);
                remainingDuration -= period;
                
            }

        }

        public List<PaymentRecord> GetPaymentRecordsOfAContract(int contractId)
        {
            return _paymentRecordRepository.Filter(x => x.ContractId == contractId).ToList();
        }
    }
}
