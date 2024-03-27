using Core;
using IronXL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ODataController
    {
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            WorkBook workBook = WorkBook.Load(file.OpenReadStream());
            WorkSheet workSheet = workBook.WorkSheets.First();

            int numberOfDataRows = workSheet.RowCount;
            
            List<Property> properties = new List<Property>();

            for(int i = 1; i<numberOfDataRows; i++)
            {
                Property property = new Property
                {
                    PropertyName = workSheet.GetCellAt(i, 0).StringValue,
                    Brief = workSheet.GetCellAt(i, 1).StringValue,
                    Area = workSheet.GetCellAt(i, 2).StringValue,
                    Description = workSheet.GetCellAt(i, 3).StringValue,
                };
                properties.Add(property);
                
            }
            return Ok(properties);
        }
    }
}
