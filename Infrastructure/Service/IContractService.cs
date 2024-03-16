using Core;
using Infrastructure.DTOs.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IContractService
    {
        void BuildContract(Contract contract);
        List<Contract> GetContractsOfACustomer(int customerId);
    }
}
