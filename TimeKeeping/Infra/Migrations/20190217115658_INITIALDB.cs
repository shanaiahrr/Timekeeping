using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class INITIALDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    Activity_TypeID = table.Column<Guid>(nullable: false),
                    Activity_Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.Activity_TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayID = table.Column<Guid>(nullable: false),
                    Day = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<Guid>(nullable: false),
                    Department_Code = table.Column<string>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "TypeofRight",
                columns: table => new
                {
                    Role_TypeID = table.Column<Guid>(nullable: false),
                    Role_Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeofRight", x => x.Role_TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftID = table.Column<Guid>(nullable: false),
                    Shift_Type = table.Column<string>(nullable: false),
                    Start_Time = table.Column<DateTime>(nullable: false),
                    End_Time = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    DayID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftID);
                    table.ForeignKey(
                        name: "FK_Shift_Days_DayID",
                        column: x => x.DayID,
                        principalTable: "Days",
                        principalColumn: "DayID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    CostCenter = table.Column<string>(nullable: true),
                    SeparatedDate = table.Column<DateTime>(nullable: false),
                    Shift = table.Column<string>(nullable: true),
                    SSSno = table.Column<string>(nullable: false),
                    PHICno = table.Column<string>(nullable: false),
                    TINno = table.Column<string>(nullable: false),
                    HDMFno = table.Column<string>(nullable: false),
                    RoleID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Right",
                columns: table => new
                {
                    RightID = table.Column<Guid>(nullable: false),
                    NameofRight = table.Column<string>(nullable: false),
                    TypeID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Right", x => x.RightID);
                    table.ForeignKey(
                        name: "FK_Right_TypeofRight_TypeID",
                        column: x => x.TypeID,
                        principalTable: "TypeofRight",
                        principalColumn: "Role_TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleRight",
                columns: table => new
                {
                    Role_RightID = table.Column<Guid>(nullable: false),
                    RightID = table.Column<Guid>(nullable: false),
                    RoleID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRight", x => x.Role_RightID);
                    table.ForeignKey(
                        name: "FK_RoleRight_Right_RightID",
                        column: x => x.RightID,
                        principalTable: "Right",
                        principalColumn: "RightID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleRight_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleID",
                table: "Employee",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Right_TypeID",
                table: "Right",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRight_RightID",
                table: "RoleRight",
                column: "RightID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRight_RoleID",
                table: "RoleRight",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_DayID",
                table: "Shift",
                column: "DayID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "RoleRight");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Right");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "TypeofRight");
        }
    }
}
