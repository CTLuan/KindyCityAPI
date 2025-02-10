using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindyCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Del = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                { 
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
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
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Del = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuCode = table.Column<int>(type: "int", nullable: false),
                    MenuName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Del = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
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

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionCode = table.Column<int>(type: "int", nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Del = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.FeatureId);
                    table.ForeignKey(
                        name: "FK_Features_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkHistories",
                columns: table => new
                {
                    WorkHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Del = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistories", x => x.WorkHistoryId);
                    table.ForeignKey(
                        name: "FK_WorkHistories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkHistories_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    OperationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Operations_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "FeatureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefautlPermissions",
                columns: table => new
                {
                    DefautlPermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefautlPermissions", x => x.DefautlPermissionId);
                    table.ForeignKey(
                        name: "FK_DefautlPermissions_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefautlPermissions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Operation",
                columns: table => new
                {
                    EmployeeAction = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Operation", x => x.EmployeeAction);
                    table.ForeignKey(
                        name: "FK_Employee_Operation_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Operation_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefautlPermissions_OperationId",
                table: "DefautlPermissions",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_DefautlPermissions_PositionId",
                table: "DefautlPermissions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LocationId",
                table: "Departments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictCategories_EmployeeId",
                table: "DistrictCategories",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Operation_EmployeeId",
                table: "Employee_Operation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Operation_OperationId",
                table: "Employee_Operation",
                column: "OperationId");

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
                name: "IX_Features_MenuId",
                table: "Features",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ServiceId",
                table: "Menus",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_FeatureId",
                table: "Operations",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                column: "DepartmentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistories_EmployeeId",
                table: "WorkHistories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistories_PositionId",
                table: "WorkHistories",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefautlPermissions");

            migrationBuilder.DropTable(
                name: "DistrictCategories");

            migrationBuilder.DropTable(
                name: "Employee_Operation");

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
                name: "WorkHistories");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "EmployeeInfos");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}

