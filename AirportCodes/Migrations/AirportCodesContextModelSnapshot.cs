// <auto-generated />
using System;
using AirportCodes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirportCodes.Migrations
{
    [DbContext(typeof(AirportCodesContext))]
    partial class AirportCodesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AirportCodes.Models.Airport", b =>
                {
                    b.Property<int>("AirportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BiggestAirline")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Code")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("AirportId");

                    b.ToTable("Airports");

                    b.HasData(
                        new
                        {
                            AirportId = 1,
                            BiggestAirline = "Alaska Airlines",
                            City = "SeaTac, WA",
                            Code = "SEA",
                            Name = "Seattle-Tacoma International Airport"
                        },
                        new
                        {
                            AirportId = 2,
                            BiggestAirline = "Southwest Airlines",
                            City = "Portland, OR",
                            Code = "PDX",
                            Name = "Portland International Airport"
                        },
                        new
                        {
                            AirportId = 3,
                            BiggestAirline = "American Airlines",
                            City = "Los Angeles",
                            Code = "LAX",
                            Name = "Los Angeles International Airport"
                        },
                        new
                        {
                            AirportId = 4,
                            BiggestAirline = "American Airlines",
                            City = "Dallas, TX",
                            Code = "DFW",
                            Name = "Dallas/Fort Worth International Airport"
                        },
                        new
                        {
                            AirportId = 5,
                            BiggestAirline = "Delta",
                            City = " New York City, NY",
                            Code = "JFK",
                            Name = "John F. Kennedy International Airport"
                        });
                });

            modelBuilder.Entity("AirportCodes.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordString")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PostedRating")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
