using AutoMapper;
using HotelBooking.Application.Contract.Persistance;
using HotelBooking.Application.Feature.Hotels.Queries.GetHotelsList;
using HotelBooking.Application.Profiles;
using HotelBooking.Application.UnitTests.Mocks;
using HotelBooking.Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HotelBooking.Application.UnitTests.Hotels.Queries
{
    public class GetHotelsListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRespository<Hotel>> _mockHotelRepository;

        public GetHotelsListQueryHandlerTests()
        {
            _mockHotelRepository = RespositoryMocks.GetHotelRepository();
            var configurationProvider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = configurationProvider.CreateMapper();

        }
        [Fact]
        public async Task GetHotelListTest()
        {
            var handler = new GetHotelsListQueryHandler(_mapper, _mockHotelRepository.Object);
            var result = await handler.Handle(new GetHotelsListQuery(), CancellationToken.None);
            result.Count.ShouldBe(1);
        }
    }
}
