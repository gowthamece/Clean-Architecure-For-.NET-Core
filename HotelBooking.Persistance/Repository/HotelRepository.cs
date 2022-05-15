using Alachisoft.NCache.EntityFrameworkCore;
using HotelBooking.Application.Contract.Persistance;
using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Persistance.Repository
{
    public class HotelRepository: BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(HotelBookingDbContext dbContext) : base(dbContext)
        {
           
        }
        public List<Hotel> ListAllHotels()
        {
            var options = new CachingOptions
            {
                // To store as collection in cache
                StoreAs = StoreAs.Collection
            };
            return  _dbContext.Hotels.FromCache(options).ToList();
        }
    }
}
