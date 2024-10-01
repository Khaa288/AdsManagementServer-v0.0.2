using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitAuthModuleDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.DistrictId);
                });

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
                name: "Ward",
                columns: table => new
                {
                    WardId = table.Column<int>(type: "int", nullable: false),
                    WardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.WardId);
                    table.ForeignKey(
                        name: "FK_Ward_District_WardId",
                        column: x => x.WardId,
                        principalTable: "District",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePrivilege",
                columns: table => new
                {
                    PrivilegesPrivilegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolesRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePrivilege", x => new { x.PrivilegesPrivilegeId, x.RolesRoleId });
                    table.ForeignKey(
                        name: "FK_RolePrivilege_Privilege_PrivilegesPrivilegeId",
                        column: x => x.PrivilegesPrivilegeId,
                        principalTable: "Privilege",
                        principalColumn: "PrivilegeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePrivilege_Role_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
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
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Officer_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "WardId",
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

            migrationBuilder.CreateTable(
                name: "Otp",
                columns: table => new
                {
                    OtpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OtpType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfficerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otp", x => x.OtpId);
                    table.ForeignKey(
                        name: "FK_Otp_Officer_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "Officer",
                        principalColumn: "OfficerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    TokenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfficerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.TokenId);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Officer_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "Officer",
                        principalColumn: "OfficerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Officer_RoleId",
                table: "Officer",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Officer_WardId",
                table: "Officer",
                column: "WardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfficerPrivilege_PrivilegesPrivilegeId",
                table: "OfficerPrivilege",
                column: "PrivilegesPrivilegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Otp_OfficerId",
                table: "Otp",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_OfficerId",
                table: "RefreshToken",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivilege_RolesRoleId",
                table: "RolePrivilege",
                column: "RolesRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficerPrivilege");

            migrationBuilder.DropTable(
                name: "Otp");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "RolePrivilege");

            migrationBuilder.DropTable(
                name: "Officer");

            migrationBuilder.DropTable(
                name: "Privilege");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "District");
        }
    }
}
