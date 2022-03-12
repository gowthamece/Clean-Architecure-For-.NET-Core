using AutoMapper;
using HotelBooking.Application.Feature.Hotels.Queries.GetHotelsList;
using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hotel, HotelsListVM>();
        }
    }

}
