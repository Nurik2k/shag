using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DZ3.Migrations
{
    /// <inheritdoc />
    public partial class Car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Information", "Mark", "Model", "PublishYear" },
                values: new object[] { 1, "general information\r\nBrand countryGermanyVehicle classENumber of doors4Number of seats5\r\nDimensions, mm\r\nLength4965Width1903Height1473Wheelbase2982Clearance128Front track width1626Rear track width1595Wheel size275/35/R20, 275/35/R20\r\nVolume and mass\r\nTrunk volume min / max, l530Volume of fuel tank, l68Curb weight, kg1940Gross weight, kg2440\r\nTransmission\r\nGearboxAutomaticNumber of gears8Drive typeall wheel drive\r\nSuspension and brakes\r\nFront suspension typeindependent, spring typeRear suspension typeindependent, spring typeFront brakesventilated discRear brakesventilated disc\r\nPerformance indicators\r\nMaximum speed, km/h250Acceleration to 100 km/h, s3.3Fuel consumption city/highway/combined, l15.2/8.7/10.8Fuel brand AI-95Emission classEuro 6CO2 emissions, g/km246\r\nEngine\r\nEngine typepetrolEngine locationfront, longitudinalEngine displacement, cm³4395Type of superchargingturbochargingMaximum power, hp/kW at rpm625/460 at 6000Maximum torque, N*m at rpm750 at 5800Cylinder arrangementV-shapedNumber of cylinders8Number of valves per cylinder4Engine power systemdirect injection (direct injection) Compression ratio10Cylinder diameter and piston stroke, mm88.3x89.0", "Bmw", "M5 (F90)", 2018 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
