using AutoMapper;
using Core;
using Infrastructure.DTOs.Property;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IGenericRepository<Property> _propertyRepository;
        private readonly IMapper _mapper;
        public PropertyController(IGenericRepository<Property> propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;        
            _mapper = mapper;
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
