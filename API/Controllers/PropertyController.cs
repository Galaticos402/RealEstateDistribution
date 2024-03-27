using AutoMapper;
using Core;
using Infrastructure.DTOs.Property;
using Infrastructure.Repository;
using Infrastructure.Service;
using IronXL;
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
        [HttpPost("bulkCreate/{divisionId}")]
        public async Task<IActionResult> BulkCreate(int divisionId,IFormFile file)
        {
            WorkBook workBook = WorkBook.Load(file.OpenReadStream());
            WorkSheet workSheet = workBook.WorkSheets.First();

            int numberOfDataRows = workSheet.RowCount;

            List<Property> properties = new List<Property>();

            for (int i = 1; i < numberOfDataRows; i++)
            {
                PropertyCreationModel propertyCreationModel = new PropertyCreationModel
                {
                    PropertyName = workSheet.GetCellAt(i, 0).StringValue,
                    Brief = workSheet.GetCellAt(i, 1).StringValue,
                    Area = workSheet.GetCellAt(i, 2).StringValue,
                    Description = workSheet.GetCellAt(i, 3).StringValue,
                    DivisionId = divisionId,
                };
                var property = _mapper.Map<Property>(propertyCreationModel);
                property.IsSold = false;
                properties.Add(property);

            }
            _propertyRepository.InsertMulti(properties);
            _propertyRepository.Save();
            return Ok(properties);
        }
    }
}
