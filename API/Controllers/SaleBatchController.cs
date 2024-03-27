using AutoMapper;
using Core;
using Infrastructure.DTOs.SaleBatch;
using Infrastructure.DTOs.SaleBatchDetail;
using Infrastructure.Enum;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleBatchController : ODataController
    {
        private readonly IGenericRepository<SaleBatch> _saleBatchRepository;
        private readonly IGenericRepository<SaleBatchDetail> _saleBatchDetailRepository;
        private readonly ISaleBatchService _saleBatchService;
        private readonly IMapper _mapper;
        public SaleBatchController(IGenericRepository<SaleBatch> saleBatchRepository, IMapper mapper, IGenericRepository<SaleBatchDetail> saleBatchDetailRepository, ISaleBatchService saleBatchService)
        {
            _saleBatchRepository = saleBatchRepository;
            _mapper = mapper;
            _saleBatchDetailRepository = saleBatchDetailRepository;
            _saleBatchService = saleBatchService;
        }
        [HttpGet("getAvailableSaleBatch")]
        public async Task<IActionResult> GetAvailableSaleBatch([FromQuery] int divisionId, string? status)
        {
            if(status == null)
            {
                return Ok(_saleBatchService.findAvailableSaleBatchOfADivision(divisionId));
            }
            if(status == SaleBatchStatus.OPENING)
            {
                return Ok(_saleBatchService.findOpeningSaleBatchOfADivision(divisionId));
            }
            if(status == SaleBatchStatus.UPCOMING)
            {
                return Ok(_saleBatchService.findUpcomingSaleBatchOfADivision(divisionId));
            }
            return Ok(_saleBatchService.findAvailableSaleBatchOfADivision(divisionId));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleBatchCreationModel model)
        {
            var saleBatch = _mapper.Map<SaleBatch>(model);
            try
            {
                _saleBatchRepository.Insert(saleBatch);
                _saleBatchRepository.Save();
                return Ok(saleBatch);
            }catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message,
                });
            }
        }
        [HttpPost("assignProperty")]
        public async Task<IActionResult> AssignPropertiesToSaleBatch([FromQuery] int saleBatchId, [FromBody] List<SaleBatchDetailCreationModel> models)
        {
            var saleBatch = _saleBatchRepository.GetById(saleBatchId);
            if (saleBatch == null) return BadRequest(new { Message = "Sale batch does not exist" });
            List<SaleBatchDetail> saleBatchDetails = new List<SaleBatchDetail>();
            foreach(var model in models)
            {
                saleBatchDetails.Add(new SaleBatchDetail { PropertyId = model.PropertyId, SaleBatchId = saleBatchId, Price = model.Price });
            }
            try
            {
                _saleBatchDetailRepository.InsertMulti(saleBatchDetails);
                _saleBatchDetailRepository.Save();
                return Ok(saleBatchDetails);
            }catch (Exception ex)
            {
                return BadRequest(new {Message =  ex.Message, });
            }
        }
    }
}
