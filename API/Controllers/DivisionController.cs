using AutoMapper;
using Core;
using Infrastructure.DTOs.Division;
using Infrastructure.DTOs.Project;
using Infrastructure.Repository;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Web.Http.OData.Routing;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ODataController
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
        public async Task<IActionResult> GetByProjectId([FromQuery] int projectId)
        {
            return Ok(_divisionRepository.Filter(x => x.ProjectId == projectId));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var division = _divisionRepository.GetById(id);
            if(division == null) return BadRequest(new
            {
                Message = "Unable to find the division with that Id"
            });
            return Ok(division);
        }
    }
}
