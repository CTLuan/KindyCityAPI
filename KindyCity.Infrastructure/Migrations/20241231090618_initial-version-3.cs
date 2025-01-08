using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindyCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialversion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Positions_PositionId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Departments_DepartmentId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_WorkHistories_WorkHistoryId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_WorkHistoryId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Locations_DepartmentId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Departments_PositionId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "WorkHistoryId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Departments");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistories_PositionId",
                table: "WorkHistories",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LocationId",
                table: "Departments",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Locations_LocationId",
                table: "Departments",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Departments_DepartmentId",
                table: "Positions",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistories_Positions_PositionId",
                table: "WorkHistories",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Locations_LocationId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Departments_DepartmentId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistories_Positions_PositionId",
                table: "WorkHistories");

            migrationBuilder.DropIndex(
                name: "IX_WorkHistories_PositionId",
                table: "WorkHistories");

            migrationBuilder.DropIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Departments_LocationId",
                table: "Departments");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkHistoryId",
                table: "Positions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_WorkHistoryId",
                table: "Positions",
                column: "WorkHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_DepartmentId",
                table: "Locations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_PositionId",
                table: "Departments",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Positions_PositionId",
                table: "Departments",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Departments_DepartmentId",
                table: "Locations",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_WorkHistories_WorkHistoryId",
                table: "Positions",
                column: "WorkHistoryId",
                principalTable: "WorkHistories",
                principalColumn: "WorkHistoryId");
        }
    }
}
