using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindyCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialversion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    LastSignInTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEducations",
                columns: table => new
                {
                    EmployeeEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Major = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Del = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEducations", x => x.EmployeeEducationId);
                    table.ForeignKey(
                        name: "FK_EmployeeEducations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInfos",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Sex = table.Column<byte>(type: "tinyint", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Skype = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CitizenId = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CitizenIDIssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CitizenIDIssuedPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PassportIssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportIssuedEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportIssuedPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Nationlity = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsVietnamese = table.Column<byte>(type: "tinyint", nullable: false),
                    EthnicityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaritalStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    PlaceOfOrigin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ResidenceProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResidenceDistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResidenceWardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResidenceStreetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    District = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    WorkingStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    EmergencyContactPersonName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EmergencyContactPersonPhone = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EmergencyContactRelationship = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInfos", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_EmployeeInfos_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistrictCategories",
                columns: table => new
                {
                    DistrictCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictCategories", x => x.DistrictCategoryId);
                    table.ForeignKey(
                        name: "FK_DistrictCategories_EmployeeInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeInfos",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EthnicityCategories",
                columns: table => new
                {
                    EthnicityCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EthnicityName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthnicityCategories", x => x.EthnicityCategoryId);
                    table.ForeignKey(
                        name: "FK_EthnicityCategories_EmployeeInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeInfos",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvinceCategories",
                columns: table => new
                {
                    ProvinceCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceCategories", x => x.ProvinceCategoryId);
                    table.ForeignKey(
                        name: "FK_ProvinceCategories_EmployeeInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeInfos",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StressCategories",
                columns: table => new
                {
                    StreetCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreetCategoryName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StressCategories", x => x.StreetCategoryId);
                    table.ForeignKey(
                        name: "FK_StressCategories_EmployeeInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeInfos",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WardCategories",
                columns: table => new
                {
                    WardCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WardName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WardCategories", x => x.WardCategoryId);
                    table.ForeignKey(
                        name: "FK_WardCategories_EmployeeInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeInfos",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistrictCategories_EmployeeId",
                table: "DistrictCategories",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducations_EmployeeId",
                table: "EmployeeEducations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EthnicityCategories_EmployeeId",
                table: "EthnicityCategories",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProvinceCategories_EmployeeId",
                table: "ProvinceCategories",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StressCategories_EmployeeId",
                table: "StressCategories",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WardCategories_EmployeeId",
                table: "WardCategories",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistrictCategories");

            migrationBuilder.DropTable(
                name: "EmployeeEducations");

            migrationBuilder.DropTable(
                name: "EthnicityCategories");

            migrationBuilder.DropTable(
                name: "ProvinceCategories");

            migrationBuilder.DropTable(
                name: "StressCategories");

            migrationBuilder.DropTable(
                name: "WardCategories");

            migrationBuilder.DropTable(
                name: "EmployeeInfos");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
