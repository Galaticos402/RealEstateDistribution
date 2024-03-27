using AutoMapper;
using Core;
using Infrastructure.DTOs.Division;
using Infrastructure.DTOs.Project;
using Infrastructure.Repository;
using Infrastructure.Service;
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
        private readonly IAuthService _authService;
        public DivisionController(IMapper mapper, IGenericRepository<Division> divisionRepository, IAuthService authService)
        {
            _divisionRepository = divisionRepository;
            _mapper = mapper;
            _authService = authService;
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
        [HttpGet("role")]
        public async Task<IActionResult> GetByRole()
        {
            var header = this.Request.Headers;
            var token = header["Authorization"];
            var role = _authService.GetCurrentUserRole(token);
            var userId = _authService.GetCurrentUserId(token);
            if (role != null && userId != null) { 
                switch(role)
                {
                    case "Agency":
                        return Ok(_divisionRepository.Filter(x => x.AgencyId == userId));
                }
            }
            return Ok(_divisionRepository.GetAll());
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
