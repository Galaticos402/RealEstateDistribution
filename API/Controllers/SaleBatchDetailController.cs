using Core;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleBatchDetailController : ODataController
    {
        private readonly ISaleBatchDetailService _saleBatchDetailService;
        public SaleBatchDetailController(ISaleBatchDetailService saleBatchDetailService)
        {
            _saleBatchDetailService = saleBatchDetailService;
        }

        [HttpGet("findBySaleBatchId")]
        public IActionResult Get([FromQuery] int saleBatchId)
        {
            return Ok(_saleBatchDetailService.findSaleBatchDetailsBySaleBatchId(saleBatchId));
        }
    }
}
