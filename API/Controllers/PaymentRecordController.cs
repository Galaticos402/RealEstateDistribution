using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentRecordController : ODataController
    {
        private readonly IPaymentRecordService _paymentRecordService;
        public PaymentRecordController(IPaymentRecordService paymentRecordService)
        {
            _paymentRecordService = paymentRecordService;
        }
        [HttpGet]
        [EnableQuery]
        public IActionResult GetPaymentRecordByContractId([FromQuery]int contractId)
        {
            return Ok(_paymentRecordService.GetPaymentRecordsOfAContract(contractId));
        }
    }
}
