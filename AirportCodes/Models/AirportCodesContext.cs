using Microsoft.EntityFrameworkCore;

namespace AirportCodes.Models
{
    public class AirportCodesContext : DbContext
    {
        public AirportCodesContext(DbContextOptions<AirportCodesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Airport>()
              .HasData(
                  new Airport { AirportId = 1, Name = "Seattle-Tacoma International Airport", Code = "SEA", City = "SeaTac, WA", BiggestAirline = "Alaska Airlines" },
                  new Airport { AirportId = 2, Name = "Portland International Airport", Code = "PDX", City = "Portland, OR", BiggestAirline = "Southwest Airlines" },
                  new Airport { AirportId = 3, Name = "Los Angeles International Airport", Code = "LAX", City = "Los Angeles", BiggestAirline = "American Airlines" },
                  new Airport { AirportId = 4, Name = "Dallas/Fort Worth International Airport", Code = "DFW", City = "Dallas, TX", BiggestAirline = "American Airlines" },
                  new Airport { AirportId = 5, Name = "John F. Kennedy International Airport", Code = "JFK", City = " New York City, NY", BiggestAirline = "Delta" }
              );
        }


        public DbSet<Airport> Airports { get; set; }
    }
}