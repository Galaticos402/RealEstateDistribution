using AutoMapper;
using Core;
using Infrastructure.DTOs.Booking;
using Infrastructure.Repository;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IGenericRepository<Booking> _bookingRepository;
        private readonly IMapper _mapper;
        public BookingController(IGenericRepository<Booking> bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookingCreationModel model)
        {
            var booking = _mapper.Map<Booking>(model);
            if(booking == null)
            {
                return BadRequest(new
                {
                    Message = "Booking failed"
                });
            }
            return Ok(booking);
        }
    }
}
