using AutoMapper;
using Core;
using Infrastructure.DTOs.Project;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ODataController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Project> _projectRepository;
        private readonly IAuthService _authService;
        public ProjectController(IMapper mapper, IGenericRepository<Project> projectRepository, IAuthService authService)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _authService = authService;
        }
        [Authorize(Roles = "Investor")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectCreationModel model)
        {
            var header = this.Request.Headers;
            var token = header["Authorization"];
            var userId = _authService.GetCurrentUserId(token);
            if (userId == null)
            {
                return BadRequest(new
                {
                    Message = "Cannot find requesting user"
                });
            }
            var project = _mapper.Map<Project>(model);
            project.CreatedDate = DateTime.Now;
            project.InvestorId = (int)userId;
            _projectRepository.Insert(project);
            _projectRepository.Save();
            return Ok(project);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_projectRepository.Filter(null, 0,int.MaxValue, null, x => x.Include(p => p.Investor)));
        }
        [HttpGet("({id})")]
        public async Task<IActionResult> GetOne(int id)
        {
            var project = _projectRepository.Filter(x => x.ProjectId == id, 0, int.MaxValue, null, x => x.Include(p => p.Investor).Include(p => p.Divisions)).FirstOrDefault();
            if(project == null)
            {
                return BadRequest(new
                {
                    Message = "Project does not exist"
                });
            }
            return Ok(project);
        }
        [Authorize(Roles = "Investor")]
        [HttpGet("findByInvestorId")]
        public async Task<IActionResult> GetProjectOfAnInvestor()
        {
            var header = this.Request.Headers;
            var token = header["Authorization"];
            var userId = _authService.GetCurrentUserId(token);
            if (userId == null)
            {
                return BadRequest(new
                {
                    Message = "Cannot find requesting user"
                });
            }
            var projects = _projectRepository.Filter(x => x.InvestorId == userId).ToList();
            return Ok(projects);
        }
    }
}
