using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.RequestManagement.DataService.Migrations
{
    /// <inheritdoc />
    public partial class add_batch_request_Fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TeacherRequests_RecieverId",
                table: "TeacherRequests",
                column: "RecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherRequests_SenderId",
                table: "TeacherRequests",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRequests_RecieverId",
                table: "StudentRequests",
                column: "RecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRequests_SenderId",
                table: "StudentRequests",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRequests_Students_SenderId",
                table: "StudentRequests",
                column: "SenderId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRequests_Teachers_RecieverId",
                table: "StudentRequests",
                column: "RecieverId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherRequests_Students_RecieverId",
                table: "TeacherRequests",
                column: "RecieverId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherRequests_Teachers_SenderId",
                table: "TeacherRequests",
                column: "SenderId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRequests_Students_SenderId",
                table: "StudentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRequests_Teachers_RecieverId",
                table: "StudentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherRequests_Students_RecieverId",
                table: "TeacherRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherRequests_Teachers_SenderId",
                table: "TeacherRequests");

            migrationBuilder.DropIndex(
                name: "IX_TeacherRequests_RecieverId",
                table: "TeacherRequests");

            migrationBuilder.DropIndex(
                name: "IX_TeacherRequests_SenderId",
                table: "TeacherRequests");

            migrationBuilder.DropIndex(
                name: "IX_StudentRequests_RecieverId",
                table: "StudentRequests");

            migrationBuilder.DropIndex(
                name: "IX_StudentRequests_SenderId",
                table: "StudentRequests");
        }
    }
}
