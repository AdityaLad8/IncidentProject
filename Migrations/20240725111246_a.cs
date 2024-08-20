using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace incidentMgtSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleMasters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMasters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CityMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CityMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CountryMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CountryMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_StateMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_StateMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TenantMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TenantMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobileno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_IncidentMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Urgency = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_IncidentMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_IncidentMaster_tbl_CityMaster_CityId",
                        column: x => x.CityId,
                        principalTable: "tbl_CityMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_IncidentMaster_tbl_TenantMaster_TenantId",
                        column: x => x.TenantId,
                        principalTable: "tbl_TenantMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_IncidentMaster_tbl_User_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_incidentMasterJsons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Json = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_incidentMasterJsons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_incidentMasterJsons_tbl_User_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserLogin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastlogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserLogin", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_UserLogin_tbl_User_Userid",
                        column: x => x.Userid,
                        principalTable: "tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_incidentComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_incidentComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_incidentComments_tbl_IncidentMaster_IncId",
                        column: x => x.IncId,
                        principalTable: "tbl_IncidentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_incidentComments_IncId",
                table: "tbl_incidentComments",
                column: "IncId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_IncidentMaster_CityId",
                table: "tbl_IncidentMaster",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_IncidentMaster_RequesterId",
                table: "tbl_IncidentMaster",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_IncidentMaster_TenantId",
                table: "tbl_IncidentMaster",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_incidentMasterJsons_RequesterId",
                table: "tbl_incidentMasterJsons",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserLogin_Userid",
                table: "tbl_UserLogin",
                column: "Userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleMasters");

            migrationBuilder.DropTable(
                name: "tbl_CountryMaster");

            migrationBuilder.DropTable(
                name: "tbl_incidentComments");

            migrationBuilder.DropTable(
                name: "tbl_incidentMasterJsons");

            migrationBuilder.DropTable(
                name: "tbl_StateMaster");

            migrationBuilder.DropTable(
                name: "tbl_UserLogin");

            migrationBuilder.DropTable(
                name: "tbl_UserRoles");

            migrationBuilder.DropTable(
                name: "tbl_IncidentMaster");

            migrationBuilder.DropTable(
                name: "tbl_CityMaster");

            migrationBuilder.DropTable(
                name: "tbl_TenantMaster");

            migrationBuilder.DropTable(
                name: "tbl_User");
        }
    }
}
