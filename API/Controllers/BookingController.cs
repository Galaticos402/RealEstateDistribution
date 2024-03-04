using AutoMapper;
using Core;
using Infrastructure.DTOs.Booking;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IBookingService _bookingService;
        private readonly IGenericRepository<Booking> _bookingRepository;
        public BookingController(IMapper mapper, IAuthService authService, IBookingService bookingService, IGenericRepository<Booking> bookingRepository)
        {
            _mapper = mapper;
            _authService = authService;
            _bookingService = bookingService;
            _bookingRepository = bookingRepository;
        }
        [HttpGet("getBookingOfACustomer")]
        public async Task<IActionResult> GetPaidBookingOfACustomer(bool isPaid)
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
            var bookings = _bookingRepository.Filter(x => x.CustomerId == userId && x.IsPaid == isPaid, 0, int.MaxValue, null, x => x.Include(k => k.SaleBatch)).ToList();
            return Ok(bookings);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookingCreationModel model)
        {
            var header = this.Request.Headers;
            var token = header["Authorization"];
            var userId = _authService.GetCurrentUserId(token);
            if(userId == null)
            {
                return BadRequest(new
                {
                    Message = "Cannot find requesting user"
                });
            }
            var booking = _mapper.Map<Booking>(model);
            

            if(booking == null)
            {
                return BadRequest(new
                {
                    Message = "Booking failed"
                });
            }
            booking.CustomerId = (int)userId;
            booking.BookingDate = DateTime.Now;

            try
            {
                _bookingService.Create(booking);
            }catch(Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }

            return Ok(booking);
        }
    }
}
