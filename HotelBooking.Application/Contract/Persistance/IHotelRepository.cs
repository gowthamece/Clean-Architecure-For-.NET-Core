using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Contract.Persistance
{
    public interface IHotelRepository : IAsyncRespository<Hotel>
    {
        List<Hotel> ListAllHotels();

    }
}
