using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ubicomp_lab.Migrations
{
    public partial class sensordata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sensorData",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    time = table.Column<DateTime>(nullable: false),
                    acceX = table.Column<double>(nullable: false),
                    acceY = table.Column<double>(nullable: false),
                    acceZ = table.Column<double>(nullable: false),
                    gyroX = table.Column<double>(nullable: false),
                    gyroY = table.Column<double>(nullable: false),
                    gyroZ = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensorData", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sensorData");
        }
    }
}
