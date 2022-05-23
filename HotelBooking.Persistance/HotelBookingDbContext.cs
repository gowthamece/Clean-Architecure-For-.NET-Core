
using Alachisoft.NCache.Client;
using Alachisoft.NCache.EntityFrameworkCore;
using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Persistance
{
    public class HotelBookingDbContext : DbContext
    {
        public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options) : base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Parameters specified in App.config
        //    string cacheId = ConfigurationManager.AppSettings["CacheId"];
        //    string connString = ConfigurationManager.AppSettings["ConnectionStrings"];

        //    // configure cache with SQLServer DependencyType and CacheInitParams
        //    var cacheConnectionOptions = new CacheConnectionOptions();
        //    cacheConnectionOptions.LoadBalance = true;
        //    cacheConnectionOptions.ConnectionRetries = 5;
        //    cacheConnectionOptions.Mode = IsolationLevel.OutProc;
        //    cacheConnectionOptions.ClientRequestTimeOut = TimeSpan.FromSeconds(30);
        //    cacheConnectionOptions.RetryInterval = TimeSpan.FromSeconds(5);
        //    cacheConnectionOptions.ServerList = new List<ServerInfo>();
        //    {
        //        new ServerInfo("remoteServer", 9800);
        //    };

        //    Alachisoft.NCache.EntityFrameworkCore.NCacheConfiguration.Configure(cacheId, DependencyType.SqlServer, cacheConnectionOptions);

        //    optionsBuilder.UseSqlServer(connString);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelBookingDbContext).Assembly);

            modelBuilder.Entity<Hotel>().HasData(new Hotel { HotelId = Guid.NewGuid(), Name = "Shaaniya" });
        }
    }
}
