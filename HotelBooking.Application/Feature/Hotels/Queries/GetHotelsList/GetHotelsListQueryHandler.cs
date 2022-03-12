﻿using AutoMapper;
using HotelBooking.Application.Contract.Persistance;
using HotelBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBooking.Application.Feature.Hotels.Queries.GetHotelsList
{
    public class GetHotelsListQueryHandler : IRequestHandler<GetHotelsListQuery, List<HotelsListVM>>
    {
        private readonly IAsyncRespository<Hotel> _hotelRepository;
        private readonly IMapper _mapper;
        public GetHotelsListQueryHandler(IMapper mapper, IAsyncRespository<Hotel> hotelRespository)
        {
            _mapper = mapper;
            _hotelRepository = hotelRespository;
        }
        public async Task<List<HotelsListVM>> Handle(GetHotelsListQuery request, CancellationToken cancellationToken)
        {
            var allHotels = (await _hotelRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<HotelsListVM>>(allHotels);
        }
    }
}
