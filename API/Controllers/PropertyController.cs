using AutoMapper;
using Core;
using Infrastructure.DTOs.Property;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ODataController
    {
        private readonly IGenericRepository<Property> _propertyRepository;
        private readonly IMapper _mapper;
        private readonly IPropertyService _propertyService;
        public PropertyController(IGenericRepository<Property> propertyRepository, IMapper mapper, IPropertyService propertyService)
        {
            _propertyRepository = propertyRepository;        
            _mapper = mapper;
            _propertyService = propertyService;
        }
        [HttpGet("findBySaleBatch")]
        public async Task<IActionResult> GetBySaleBatch([FromQuery] int saleBatchId) {
            return Ok(_propertyService.findPropertiesOfASaleBatch(saleBatchId));
        }
        [HttpGet("findByDivision")]
        public async Task<IActionResult> GetByDivision([FromQuery] int divisionId)
        {
            return Ok(_propertyService.findByDivisionId(divisionId));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PropertyCreationModel model)
        {
            try
            {
                var property = _mapper.Map<Property>(model);
                _propertyRepository.Insert(property);
                _propertyRepository.Save();
                return Ok(property);
            }catch(Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message,
                });
            }
            
        }
    }
}
