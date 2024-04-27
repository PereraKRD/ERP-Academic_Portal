using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.EvaluationManagement.DataService.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "ModuleSecondExaminers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ModuleSecondExaminers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ModuleSecondExaminers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ModuleSecondExaminers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "ModuleFirstExaminers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ModuleFirstExaminers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ModuleFirstExaminers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ModuleFirstExaminers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "ModuleSecondExaminers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ModuleSecondExaminers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ModuleSecondExaminers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ModuleSecondExaminers");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "ModuleFirstExaminers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ModuleFirstExaminers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ModuleFirstExaminers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ModuleFirstExaminers");
        }
    }
}
