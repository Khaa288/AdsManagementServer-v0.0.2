using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuthModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Officer_Ward_WardId",
                table: "Officer");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_OfficerId",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_Officer_WardId",
                table: "Officer");

            migrationBuilder.DropColumn(
                name: "WardId",
                table: "Officer");

            migrationBuilder.CreateTable(
                name: "DeptOfficer",
                columns: table => new
                {
                    OfficerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeptOfficer", x => x.OfficerId);
                    table.ForeignKey(
                        name: "FK_DeptOfficer_Officer_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "Officer",
                        principalColumn: "OfficerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistrictOfficer",
                columns: table => new
                {
                    OfficerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictOfficer", x => x.OfficerId);
                    table.ForeignKey(
                        name: "FK_DistrictOfficer_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistrictOfficer_Officer_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "Officer",
                        principalColumn: "OfficerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WardOfficer",
                columns: table => new
                {
                    OfficerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WardOfficer", x => x.OfficerId);
                    table.ForeignKey(
                        name: "FK_WardOfficer_Officer_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "Officer",
                        principalColumn: "OfficerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WardOfficer_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "WardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_OfficerId",
                table: "RefreshToken",
                column: "OfficerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DistrictOfficer_DistrictId",
                table: "DistrictOfficer",
                column: "DistrictId",
                unique: true,
                filter: "[DistrictId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WardOfficer_WardId",
                table: "WardOfficer",
                column: "WardId",
                unique: true,
                filter: "[WardId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeptOfficer");

            migrationBuilder.DropTable(
                name: "DistrictOfficer");

            migrationBuilder.DropTable(
                name: "WardOfficer");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_OfficerId",
                table: "RefreshToken");

            migrationBuilder.AddColumn<int>(
                name: "WardId",
                table: "Officer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_OfficerId",
                table: "RefreshToken",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_Officer_WardId",
                table: "Officer",
                column: "WardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Officer_Ward_WardId",
                table: "Officer",
                column: "WardId",
                principalTable: "Ward",
                principalColumn: "WardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
