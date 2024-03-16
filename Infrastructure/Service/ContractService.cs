using Core;
using Infrastructure.DTOs.Contract;
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
    public class ContractService : IContractService
    {
        private readonly IGenericRepository<Contract> _contractRepository;
        private readonly IPropertyService _propertyService;
        private readonly IPaymentRecordService _paymentRecordService;
        public ContractService(IPropertyService propertyService, IGenericRepository<Contract> contractRepository, IPaymentRecordService paymentRecordService)
        {

            _propertyService = propertyService;
            _contractRepository = contractRepository;
            _paymentRecordService = paymentRecordService;

        }
        public void BuildContract(Contract contract)
        {
            if (_propertyService.isPropertySold(contract.PropertyId))
            {
                throw new DBTransactionException("Property is already sold");
            }
            _contractRepository.Insert(contract);
            _contractRepository.Save();
            _paymentRecordService.GeneratePaymentRecordForContract(contract);
            _propertyService.updatePropertySoldStatus(contract.PropertyId, true);
        }

        public List<Contract> GetContractsOfACustomer(int customerId)
        {
            return _contractRepository.Filter(x => x.CustomerId == customerId, 0, int.MaxValue, null, k => k.Include(c => c.Property)).ToList();
        }
    }
}
