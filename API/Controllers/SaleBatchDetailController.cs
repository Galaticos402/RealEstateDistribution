using Core;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleBatchDetailController : ControllerBase
    {
        private readonly IGenericRepository<SaleBatchDetail> _saleBatchDetailRepository;
        public SaleBatchDetailController(IGenericRepository<SaleBatchDetail> saleBatchDetailRepository)
        {
            _saleBatchDetailRepository = saleBatchDetailRepository;
        }
        
    }
}
