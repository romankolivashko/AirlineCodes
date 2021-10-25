using Microsoft.EntityFrameworkCore;

namespace Airport.Models
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Animal>()
              .HasData(
                  new Animal { AirportId = 1, Name = "Seattle-Tacoma International Airport", Code = "SEA", City = "SeaTac, WA", BiggestAirline = "Alaska Airlines" },
                  new Animal { AirportId = 2, Name = "Portland International Airport", Code = "PDX", City = "Portland, OR", BiggestAirline = "Southwest Airlines" },
                  new Animal { AirportId = 3, Name = "Los Angeles International Airport", Code = "LAX", City = "Los Angeles", BiggestAirline = "American Airlines" },
                  new Animal { AirportId = 4, Name = "Dallas/Fort Worth International Airport", Code = "DFW", City = "Dallas, TX", BiggestAirline = "American Airlines" },
                  new Animal { AirportId = 5, Name = "John F. Kennedy International Airport", Code = "JFK", City = " New York City, NY", Airline = "Delta" }
              );
        }


        public DbSet<Airport> Airports { get; set; }
    }
}