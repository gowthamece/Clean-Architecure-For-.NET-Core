using Microsoft.EntityFrameworkCore;
using HotelBooking.Application.Contract.Persistance;
using HotelBooking.Persistance.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alachisoft.NCache.Client;
using Alachisoft.NCache.EntityFrameworkCore;

namespace HotelBooking.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelBookingDbContext>(options =>
            
                options.UseSqlServer(configuration.GetConnectionString("HotelConnectionString")));

            
            string cacheId = configuration.GetSection("NCacheConfig").GetSection("CacheId").Value.ToString();
            

            NCacheConfiguration.Configure(cacheId, DependencyType.SqlServer);
            services.AddScoped(typeof(IAsyncRespository<>), typeof(BaseRepository<>));
            services.AddScoped<IHotelRepository, HotelRepository>();

            return services;

        }
    }
}
