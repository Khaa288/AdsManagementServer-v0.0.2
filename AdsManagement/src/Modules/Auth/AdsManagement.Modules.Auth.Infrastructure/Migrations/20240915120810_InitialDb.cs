using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Privilege",
                columns: table => new
                {
                    PrivilegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrivilegeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilege", x => x.PrivilegeId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Officer",
                columns: table => new
                {
                    OfficerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officer", x => x.OfficerId);
                    table.ForeignKey(
                        name: "FK_Officer_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivilegeRole",
                columns: table => new
                {
                    PrivilegesPrivilegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolesRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivilegeRole", x => new { x.PrivilegesPrivilegeId, x.RolesRoleId });
                    table.ForeignKey(
                        name: "FK_PrivilegeRole_Privilege_PrivilegesPrivilegeId",
                        column: x => x.PrivilegesPrivilegeId,
                        principalTable: "Privilege",
                        principalColumn: "PrivilegeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivilegeRole_Role_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficerPrivilege",
                columns: table => new
                {
                    OfficersOfficerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrivilegesPrivilegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficerPrivilege", x => new { x.OfficersOfficerId, x.PrivilegesPrivilegeId });
                    table.ForeignKey(
                        name: "FK_OfficerPrivilege_Officer_OfficersOfficerId",
                        column: x => x.OfficersOfficerId,
                        principalTable: "Officer",
                        principalColumn: "OfficerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficerPrivilege_Privilege_PrivilegesPrivilegeId",
                        column: x => x.PrivilegesPrivilegeId,
                        principalTable: "Privilege",
                        principalColumn: "PrivilegeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Officer_RoleId",
                table: "Officer",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfficerPrivilege_PrivilegesPrivilegeId",
                table: "OfficerPrivilege",
                column: "PrivilegesPrivilegeId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivilegeRole_RolesRoleId",
                table: "PrivilegeRole",
                column: "RolesRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficerPrivilege");

            migrationBuilder.DropTable(
                name: "PrivilegeRole");

            migrationBuilder.DropTable(
                name: "Officer");

            migrationBuilder.DropTable(
                name: "Privilege");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
