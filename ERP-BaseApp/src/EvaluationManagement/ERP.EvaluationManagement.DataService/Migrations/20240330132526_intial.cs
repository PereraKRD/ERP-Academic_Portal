using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.EvaluationManagement.DataService.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Credits = table.Column<int>(type: "INTEGER", nullable: false),
                    Semester = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RegistrationNum = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleOfferings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModuleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CoordinatorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModeratorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExternalModeratorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleOfferings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleOfferings_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleOfferings_Teachers_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleOfferings_Teachers_ExternalModeratorId",
                        column: x => x.ExternalModeratorId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleOfferings_Teachers_ModeratorId",
                        column: x => x.ModeratorId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    FinalMarks = table.Column<double>(type: "REAL", nullable: false),
                    Marks = table.Column<double>(type: "REAL", nullable: false),
                    ModuleOfferingID = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_ModuleOfferings_ModuleOfferingID",
                        column: x => x.ModuleOfferingID,
                        principalTable: "ModuleOfferings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleFirstExaminers",
                columns: table => new
                {
                    ModuleOfferingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeacherId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleFirstExaminers", x => new { x.ModuleOfferingId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_ModuleFirstExaminers_ModuleOfferings_ModuleOfferingId",
                        column: x => x.ModuleOfferingId,
                        principalTable: "ModuleOfferings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleFirstExaminers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleRegistrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModuleOfferingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleRegistrations_ModuleOfferings_ModuleOfferingId",
                        column: x => x.ModuleOfferingId,
                        principalTable: "ModuleOfferings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleRegistrations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleSecondExaminers",
                columns: table => new
                {
                    ModuleOfferingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeacherId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleSecondExaminers", x => new { x.ModuleOfferingId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_ModuleSecondExaminers_ModuleOfferings_ModuleOfferingId",
                        column: x => x.ModuleOfferingId,
                        principalTable: "ModuleOfferings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleSecondExaminers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleTeachers",
                columns: table => new
                {
                    ModuleOfferingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeacherId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleTeachers", x => new { x.ModuleOfferingId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_ModuleTeachers_ModuleOfferings_ModuleOfferingId",
                        column: x => x.ModuleOfferingId,
                        principalTable: "ModuleOfferings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleTeachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentResults",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EvaluationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentScore = table.Column<double>(type: "REAL", nullable: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentResults", x => new { x.StudentId, x.EvaluationId });
                    table.ForeignKey(
                        name: "FK_StudentResults_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentResults_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ModuleOfferingID",
                table: "Evaluations",
                column: "ModuleOfferingID");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleFirstExaminers_TeacherId",
                table: "ModuleFirstExaminers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleOfferings_CoordinatorId",
                table: "ModuleOfferings",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleOfferings_ExternalModeratorId",
                table: "ModuleOfferings",
                column: "ExternalModeratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleOfferings_ModeratorId",
                table: "ModuleOfferings",
                column: "ModeratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleOfferings_ModuleId",
                table: "ModuleOfferings",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleRegistrations_ModuleOfferingId",
                table: "ModuleRegistrations",
                column: "ModuleOfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleRegistrations_StudentId",
                table: "ModuleRegistrations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleSecondExaminers_TeacherId",
                table: "ModuleSecondExaminers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleTeachers_TeacherId",
                table: "ModuleTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentResults_EvaluationId",
                table: "StudentResults",
                column: "EvaluationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleFirstExaminers");

            migrationBuilder.DropTable(
                name: "ModuleRegistrations");

            migrationBuilder.DropTable(
                name: "ModuleSecondExaminers");

            migrationBuilder.DropTable(
                name: "ModuleTeachers");

            migrationBuilder.DropTable(
                name: "StudentResults");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ModuleOfferings");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
