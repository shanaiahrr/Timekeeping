using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class UpdatedDataTypeEmployeeModelver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TINno",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "SSSno",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "PHICno",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "HDMFno",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TINno",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "SSSno",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "PHICno",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "HDMFno",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
