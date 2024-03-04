using Core;
using Infrastructure.DTOs.Booking;
using Infrastructure.Exceptions;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class BookingService : IBookingService
    {
        private readonly IGenericRepository<Booking> _bookingRepository;
        public BookingService(IGenericRepository<Booking> bookingRepository)
        {
            _bookingRepository = bookingRepository;    
        }
        public void Create(Booking model)
        {
            if(!isBookingExist(model))
            {
                _bookingRepository.Insert(model);
                _bookingRepository.Save();
            }
            else
            {
                throw new DBTransactionException("Booking has already existed");
            }
            
        }
        private bool isBookingExist(Booking model)
        {
            var existingBooking = _bookingRepository.Filter(bk => bk.SaleBatchId == model.SaleBatchId && bk.CustomerId == model.CustomerId).ToList();
            
            if(existingBooking == null || existingBooking.Count == 0 )
            {
                return false;
            }
            return true;
        }
    }
}
