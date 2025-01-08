using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindyCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialversion7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employee_Action_Employee_OperationEmployeeAction",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_DefautlPermissions_DefautlPermissionId",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Employee_Action_Employee_OperationEmployeeAction",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_DefautlPermissions_DefautlPermissionId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_DefautlPermissionId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Operations_DefautlPermissionId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_Employee_OperationEmployeeAction",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Employee_OperationEmployeeAction",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_Action",
                table: "Employee_Action");

            migrationBuilder.DropColumn(
                name: "DefautlPermissionId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "DefautlPermissionId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "Employee_OperationEmployeeAction",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "Employee_OperationEmployeeAction",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employee_Action",
                newName: "Employee_Operation");

            migrationBuilder.RenameColumn(
                name: "ActionName",
                table: "Operations",
                newName: "OperationName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_Operation",
                table: "Employee_Operation",
                column: "EmployeeAction");

            migrationBuilder.CreateIndex(
                name: "IX_DefautlPermissions_OperationId",
                table: "DefautlPermissions",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_DefautlPermissions_PositionId",
                table: "DefautlPermissions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Operation_EmployeeId",
                table: "Employee_Operation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Operation_OperationId",
                table: "Employee_Operation",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefautlPermissions_Operations_OperationId",
                table: "DefautlPermissions",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "OperationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DefautlPermissions_Positions_PositionId",
                table: "DefautlPermissions",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Operation_Employees_EmployeeId",
                table: "Employee_Operation",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Operation_Operations_OperationId",
                table: "Employee_Operation",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "OperationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefautlPermissions_Operations_OperationId",
                table: "DefautlPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_DefautlPermissions_Positions_PositionId",
                table: "DefautlPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Operation_Employees_EmployeeId",
                table: "Employee_Operation");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Operation_Operations_OperationId",
                table: "Employee_Operation");

            migrationBuilder.DropIndex(
                name: "IX_DefautlPermissions_OperationId",
                table: "DefautlPermissions");

            migrationBuilder.DropIndex(
                name: "IX_DefautlPermissions_PositionId",
                table: "DefautlPermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_Operation",
                table: "Employee_Operation");

            migrationBuilder.DropIndex(
                name: "IX_Employee_Operation_EmployeeId",
                table: "Employee_Operation");

            migrationBuilder.DropIndex(
                name: "IX_Employee_Operation_OperationId",
                table: "Employee_Operation");

            migrationBuilder.RenameTable(
                name: "Employee_Operation",
                newName: "Employee_Action");

            migrationBuilder.RenameColumn(
                name: "OperationName",
                table: "Operations",
                newName: "ActionName");

            migrationBuilder.AddColumn<Guid>(
                name: "DefautlPermissionId",
                table: "Positions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DefautlPermissionId",
                table: "Operations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Employee_OperationEmployeeAction",
                table: "Operations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Employee_OperationEmployeeAction",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_Action",
                table: "Employee_Action",
                column: "EmployeeAction");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DefautlPermissionId",
                table: "Positions",
                column: "DefautlPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_DefautlPermissionId",
                table: "Operations",
                column: "DefautlPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_Employee_OperationEmployeeAction",
                table: "Operations",
                column: "Employee_OperationEmployeeAction");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Employee_OperationEmployeeAction",
                table: "Employees",
                column: "Employee_OperationEmployeeAction");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employee_Action_Employee_OperationEmployeeAction",
                table: "Employees",
                column: "Employee_OperationEmployeeAction",
                principalTable: "Employee_Action",
                principalColumn: "EmployeeAction");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_DefautlPermissions_DefautlPermissionId",
                table: "Operations",
                column: "DefautlPermissionId",
                principalTable: "DefautlPermissions",
                principalColumn: "DefautlPermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Employee_Action_Employee_OperationEmployeeAction",
                table: "Operations",
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
    }
}
