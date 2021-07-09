using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiNet.Migrations
{
    public partial class AppicationCreatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRol",
                columns: table => new
                {
                    RolId = table.Column<Guid>(nullable: false),
                    RolName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationModuleRol",
                columns: table => new
                {
                    ModuleId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PermissionName = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Route = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsParent = table.Column<bool>(nullable: false),
                    RolId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationModuleRol", x => x.ModuleId);
                    table.ForeignKey(
                        name: "FK_ApplicationModuleRol_ApplicationRol_RolId",
                        column: x => x.RolId,
                        principalTable: "ApplicationRol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    RolId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_ApplicationRol_RolId",
                        column: x => x.RolId,
                        principalTable: "ApplicationRol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationModuleRol_RolId",
                table: "ApplicationModuleRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_RolId",
                table: "ApplicationUser",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationModuleRol");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "ApplicationRol");
        }
    }
}
