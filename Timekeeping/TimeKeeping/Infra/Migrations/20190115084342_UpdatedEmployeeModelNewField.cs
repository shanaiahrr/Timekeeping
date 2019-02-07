using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class UpdatedEmployeeModelNewField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Employee");
        }
    }
}
