using Alachisoft.NCache.EntityFrameworkCore;
using Alachisoft.NCache.Runtime.Caching;
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
                StoreAs = StoreAs.SeperateEntities
            };
          
            //FromCache

            //var resultSet = (from cust in _dbContext.Hotels

            //                 select cust).FromCache(options);

            //LoadIntoCache

            var result = (from cust in _dbContext.Hotels
                             select cust).LoadIntoCache(options);

            //FromCacheOnly

            var resultSet = (from cust in _dbContext.Hotels
                             where cust.Name == "jack68815" ||cust.Name== "jack23939"
                             select cust).FromCacheOnly();

            AddHotel();
            return resultSet.ToList();
            

        }

        public void AddHotel()
        {
            var options = new CachingOptions
            {
                QueryIdentifier="HotelEntity",
                Priority = Alachisoft.NCache.Runtime.CacheItemPriority.Default
            };
            var hotel = new Hotel { HotelId =new Guid(), Name="Gowtham"};
            
            _dbContext.Hotels.Add(hotel);
            _dbContext.SaveChanges();

            Cache cache = _dbContext.GetCache(); //get NCache instance
            cache.Insert(hotel, out string cacheKey, options);

        }
    }
}
