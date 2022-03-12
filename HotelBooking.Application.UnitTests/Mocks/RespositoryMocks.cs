using HotelBooking.Application.Contract.Persistance;
using HotelBooking.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.UnitTests.Mocks
{
    public class RespositoryMocks
    {
        public static Mock<IAsyncRespository<Hotel>> GetHotelRepository()
        {
            var concertGuid = Guid.Parse("{12345678-ABCD-12AB-98AD-ABCDF1234512}");
            var hotels = new List<Hotel>{
                new Hotel{HotelId = concertGuid, Name="Gowtham"}
            };
            var mockHotelRepository = new Mock<IAsyncRespository<Hotel>>();
            mockHotelRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(hotels);            
            return mockHotelRepository;
        }
    }
}
