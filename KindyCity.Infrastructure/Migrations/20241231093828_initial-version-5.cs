using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindyCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialversion5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DefautlPermissionId",
                table: "Positions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Employee_OperationEmployeeAction",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

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
                });

            migrationBuilder.CreateTable(
                name: "Employee_Action",
                columns: table => new
                {
                    EmployeeAction = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Action", x => x.EmployeeAction);
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
                name: "Actions",
                columns: table => new
                {
                    OperationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefautlPermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Employee_OperationEmployeeAction = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Actions_DefautlPermissions_DefautlPermissionId",
                        column: x => x.DefautlPermissionId,
                        principalTable: "DefautlPermissions",
                        principalColumn: "DefautlPermissionId");
                    table.ForeignKey(
                        name: "FK_Actions_Employee_Action_Employee_OperationEmployeeAction",
                        column: x => x.Employee_OperationEmployeeAction,
                        principalTable: "Employee_Action",
                        principalColumn: "EmployeeAction");
                    table.ForeignKey(
                        name: "FK_Actions_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "FeatureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DefautlPermissionId",
                table: "Positions",
                column: "DefautlPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Employee_OperationEmployeeAction",
                table: "Employees",
                column: "Employee_OperationEmployeeAction");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_DefautlPermissionId",
                table: "Actions",
                column: "DefautlPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_Employee_OperationEmployeeAction",
                table: "Actions",
                column: "Employee_OperationEmployeeAction");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_FeatureId",
                table: "Actions",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_MenuId",
                table: "Features",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ServiceId",
                table: "Menus",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employee_Action_Employee_OperationEmployeeAction",
                table: "Employees",
                column: "Employee_OperationEmployeeAction",
                principalTable: "Employee_Action",
                principalColumn: "EmployeeAction");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_DefautlPermissions_DefautlPermissionId",
                table: "Positions",
                column: "DefautlPermissionId",
                principalTable: "DefautlPermissions",
                principalColumn: "DefautlPermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employee_Action_Employee_OperationEmployeeAction",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_DefautlPermissions_DefautlPermissionId",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "DefautlPermissions");

            migrationBuilder.DropTable(
                name: "Employee_Action");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Positions_DefautlPermissionId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Employee_OperationEmployeeAction",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DefautlPermissionId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Employee_OperationEmployeeAction",
                table: "Employees");
        }
    }
}
