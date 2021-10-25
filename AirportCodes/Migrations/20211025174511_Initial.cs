using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportCodes.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Code = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    City = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    BiggestAirline = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportId);
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "AirportId", "BiggestAirline", "City", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "Alaska Airlines", "SeaTac, WA", "SEA", "Seattle-Tacoma International Airport" },
                    { 2, "Southwest Airlines", "Portland, OR", "PDX", "Portland International Airport" },
                    { 3, "American Airlines", "Los Angeles", "LAX", "Los Angeles International Airport" },
                    { 4, "American Airlines", "Dallas, TX", "DFW", "Dallas/Fort Worth International Airport" },
                    { 5, "Delta", " New York City, NY", "JFK", "John F. Kennedy International Airport" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
