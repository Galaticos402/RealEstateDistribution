using Core;
using Infrastructure.DTOs.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IBookingService
    {
        void Create(Booking model);
    }
}
