using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Feature.Hotels.Queries.GetHotelsList
{
    public class GetHotelsListQuery : IRequest<List<HotelsListVM>>
    {
    }
}
