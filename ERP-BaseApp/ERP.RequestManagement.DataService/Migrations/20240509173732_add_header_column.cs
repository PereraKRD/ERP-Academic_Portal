using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.RequestManagement.DataService.Migrations
{
    /// <inheritdoc />
    public partial class add_header_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "TeacherRequests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "StudentRequests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Header",
                table: "TeacherRequests");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "StudentRequests");
        }
    }
}
