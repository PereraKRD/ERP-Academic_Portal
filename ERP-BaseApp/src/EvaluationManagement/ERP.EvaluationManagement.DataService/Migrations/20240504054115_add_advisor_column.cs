using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.EvaluationManagement.DataService.Migrations
{
    /// <inheritdoc />
    public partial class add_advisor_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BatchId",
                table: "Students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AcademicAdvisorId",
                table: "Students",
                column: "AcademicAdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BatchId",
                table: "Students",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Batches_BatchId",
                table: "Students",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Teachers_AcademicAdvisorId",
                table: "Students",
                column: "AcademicAdvisorId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Batches_BatchId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Teachers_AcademicAdvisorId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AcademicAdvisorId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_BatchId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Students");
        }
    }
}
