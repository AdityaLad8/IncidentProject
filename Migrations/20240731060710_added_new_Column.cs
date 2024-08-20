using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace incidentMgtSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class addednewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "tbl_StateMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddedBYId",
                table: "tbl_incidentComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdDate",
                table: "tbl_incidentComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_StateMaster_CountryId",
                table: "tbl_StateMaster",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_incidentComments_AddedBYId",
                table: "tbl_incidentComments",
                column: "AddedBYId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_incidentComments_tbl_User_AddedBYId",
                table: "tbl_incidentComments",
                column: "AddedBYId",
                principalTable: "tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_StateMaster_tbl_CountryMaster_CountryId",
                table: "tbl_StateMaster",
                column: "CountryId",
                principalTable: "tbl_CountryMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_incidentComments_tbl_User_AddedBYId",
                table: "tbl_incidentComments");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_StateMaster_tbl_CountryMaster_CountryId",
                table: "tbl_StateMaster");

            migrationBuilder.DropIndex(
                name: "IX_tbl_StateMaster_CountryId",
                table: "tbl_StateMaster");

            migrationBuilder.DropIndex(
                name: "IX_tbl_incidentComments_AddedBYId",
                table: "tbl_incidentComments");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "tbl_StateMaster");

            migrationBuilder.DropColumn(
                name: "AddedBYId",
                table: "tbl_incidentComments");

            migrationBuilder.DropColumn(
                name: "createdDate",
                table: "tbl_incidentComments");
        }
    }
}
