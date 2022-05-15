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

namespace HotelBooking.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelBookingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("HotelConnectionString")));
            services.AddScoped(typeof(IAsyncRespository<>), typeof(BaseRepository<>));
            services.AddScoped<IHotelRepository, HotelRepository>();
            return services;
        }
    }
}
