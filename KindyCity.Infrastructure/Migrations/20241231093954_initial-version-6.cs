using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindyCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialversion6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_DefautlPermissions_DefautlPermissionId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Employee_Action_Employee_OperationEmployeeAction",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Features_FeatureId",
                table: "Actions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actions",
                table: "Actions");

            migrationBuilder.RenameTable(
                name: "Actions",
                newName: "Operations");

            migrationBuilder.RenameIndex(
                name: "IX_Actions_FeatureId",
                table: "Operations",
                newName: "IX_Operations_FeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_Actions_Employee_OperationEmployeeAction",
                table: "Operations",
                newName: "IX_Operations_Employee_OperationEmployeeAction");

            migrationBuilder.RenameIndex(
                name: "IX_Actions_DefautlPermissionId",
                table: "Operations",
                newName: "IX_Operations_DefautlPermissionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operations",
                table: "Operations",
                column: "OperationId");

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
                name: "FK_Operations_Features_FeatureId",
                table: "Operations",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "FeatureId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_DefautlPermissions_DefautlPermissionId",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Employee_Action_Employee_OperationEmployeeAction",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Features_FeatureId",
                table: "Operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operations",
                table: "Operations");

            migrationBuilder.RenameTable(
                name: "Operations",
                newName: "Actions");

            migrationBuilder.RenameIndex(
                name: "IX_Operations_FeatureId",
                table: "Actions",
                newName: "IX_Actions_FeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_Operations_Employee_OperationEmployeeAction",
                table: "Actions",
                newName: "IX_Actions_Employee_OperationEmployeeAction");

            migrationBuilder.RenameIndex(
                name: "IX_Operations_DefautlPermissionId",
                table: "Actions",
                newName: "IX_Actions_DefautlPermissionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actions",
                table: "Actions",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_DefautlPermissions_DefautlPermissionId",
                table: "Actions",
                column: "DefautlPermissionId",
                principalTable: "DefautlPermissions",
                principalColumn: "DefautlPermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Employee_Action_Employee_OperationEmployeeAction",
                table: "Actions",
                column: "Employee_OperationEmployeeAction",
                principalTable: "Employee_Action",
                principalColumn: "EmployeeAction");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Features_FeatureId",
                table: "Actions",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "FeatureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
