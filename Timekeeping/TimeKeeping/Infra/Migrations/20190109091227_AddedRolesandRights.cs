using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class AddedRolesandRights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleRight");

            migrationBuilder.DropTable(
                name: "Right");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "TypeofRight");
        }
    }
}
