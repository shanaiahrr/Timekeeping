using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class UpdatedDataTypeRoleEmployeeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Employee");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleID",
                table: "Employee",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleID",
                table: "Employee",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Role_RoleID",
                table: "Employee",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Role_RoleID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_RoleID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Employee",
                nullable: true);
        }
    }
}
