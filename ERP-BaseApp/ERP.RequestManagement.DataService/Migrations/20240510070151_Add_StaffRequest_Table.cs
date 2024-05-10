using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.RequestManagement.DataService.Migrations
{
    /// <inheritdoc />
    public partial class Add_StaffRequest_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    SenderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecieverId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsChecked = table.Column<bool>(type: "INTEGER", nullable: true),
                    Header = table.Column<int>(type: "INTEGER", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffRequests_Teachers_RecieverId",
                        column: x => x.RecieverId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffRequests_Teachers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffRequests_RecieverId",
                table: "StaffRequests",
                column: "RecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRequests_SenderId",
                table: "StaffRequests",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffRequests");
        }
    }
}
