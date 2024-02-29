using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IVnPayService _vnPayService;
        public PaymentController(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }
        [HttpGet]
        public async Task<IActionResult> GetVNPayUrl()
        {
            return Ok(_vnPayService.GetPaymentUrl(1, 1, 50000000));
        }
    }
}
