using AutoMapper;
using Core;
using Infrastructure.DTOs.Division;
using Infrastructure.DTOs.Project;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Division> _divisionRepository;
        public DivisionController(IMapper mapper, IGenericRepository<Division> divisionRepository)
        {
            _divisionRepository = divisionRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DivisionCreationModel model)
        {
            var division = _mapper.Map<Division>(model);
            _divisionRepository.Insert(division);
            _divisionRepository.Save();
            return Ok(division);
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int projectId)
        {
            return Ok(_divisionRepository.Filter(x => x.ProjectId == projectId));
        }
    }
}
