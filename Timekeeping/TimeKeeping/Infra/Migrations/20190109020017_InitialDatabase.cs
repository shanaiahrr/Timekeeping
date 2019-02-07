using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    HiredDate = table.Column<DateTime>(nullable: false),
                    EmployeeStatus = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    ActivityType = table.Column<string>(nullable: true),
                    SeparatedDate = table.Column<DateTime>(nullable: false),
                    Shift = table.Column<string>(nullable: true),
                    SSSno = table.Column<int>(nullable: false),
                    PHICno = table.Column<int>(nullable: false),
                    TINno = table.Column<int>(nullable: false),
                    HDMFno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
