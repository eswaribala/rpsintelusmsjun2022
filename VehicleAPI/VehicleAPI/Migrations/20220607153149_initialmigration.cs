using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleAPI.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Engine_No = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registration_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOR = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Chassis_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fuel_Type = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Engine_No);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
