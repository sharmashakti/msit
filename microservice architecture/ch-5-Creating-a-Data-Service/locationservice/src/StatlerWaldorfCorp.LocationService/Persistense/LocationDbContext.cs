using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StatlerWaldorfCorp.LocationService.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.Configuration;

namespace StatlerWaldorfCorp.LocationService.Persistence
{
    public class LocationDbContext : DbContext
    {

         protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(/*Connection Can be added here as well, but its better to read from appsettings.json and set it in startup.cs*/);           
        public DbSet<LocationRecord> LocationRecords { get; set; }

        public LocationDbContext(DbContextOptions<LocationDbContext> options) :base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // We can added SEED initial Location Record by uncomment below lines
            // LocationRecord locationRecord=new LocationRecord();
            // locationRecord.Altitude=1;
            // locationRecord.ID=new System.Guid("10000000-0000-0000-0000-000000000001");
            // locationRecord.MemberID=new System.Guid("10000000-0000-0000-0000-000000000001");
            // locationRecord.Timestamp = System.DateTime.Now.Second;
             
            //  var records=new LocationRecord[]{locationRecord};
            //  modelBuilder.Entity<LocationRecord>().HasData(locationRecord);
             
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("uuid-ossp");
        }

       
    }

    // It Appears to be Redundate Code, but not sure
    // // public class LocationDbContextFactory : IDbContextFactory<LocationDbContext>
    // // {
    // //     private readonly IConfiguration _configuration;
    // //     public LocationDbContextFactory(IConfiguration configuration)
    // //     {
    // //         this._configuration = configuration;
    // //     }
    // //     public LocationDbContext CreateDbContext()
    // //     {
    // //         var optionsBuilder = new DbContextOptionsBuilder<LocationDbContext>();
    // //         var connectionString = _configuration.GetValue<string>("postgres:cstr"); // GetSection("postgres:cstr").Value;
    // //         optionsBuilder.UseNpgsql(connectionString);
    // //         return new LocationDbContext(optionsBuilder.Options);
    // //     }
    // // }
}
