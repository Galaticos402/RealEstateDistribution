using AutoMapper;
using Core;
using Infrastructure.DTOs.Project;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Project> _projectRepository;
        public ProjectController(IMapper mapper, IGenericRepository<Project> projectRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectCreationModel model)
        {
            var project = _mapper.Map<Project>(model);
            _projectRepository.Insert(project);
            _projectRepository.Save();
            return Ok(project);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_projectRepository.Filter(null, 0,int.MaxValue, null, x => x.Include(p => p.Investor)));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var project = _projectRepository.Filter(x => x.ProjectId == id, 0, int.MaxValue, null, x => x.Include(p => p.Investor)).FirstOrDefault();
            if(project == null)
            {
                return BadRequest(new
                {
                    Message = "Project does not exist"
                });
            }
            return Ok(project);
        }
    }
}
