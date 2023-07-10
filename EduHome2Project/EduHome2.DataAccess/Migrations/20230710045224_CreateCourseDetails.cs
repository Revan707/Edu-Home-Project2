using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome2.DataAccess.Migrations
{
    public partial class CreateCourseDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseDetailId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Assesments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssesmentType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assesments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HowToApply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutCourse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LanguageOptionId = table.Column<int>(type: "int", nullable: false),
                    AssesmentId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    StudentCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDetails_Assesments_AssesmentId",
                        column: x => x.AssesmentId,
                        principalTable: "Assesments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDetails_Languages_LanguageOptionId",
                        column: x => x.LanguageOptionId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDetails_SkillLevels_SkillId",
                        column: x => x.SkillId,
                        principalTable: "SkillLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseDetailId",
                table: "Courses",
                column: "CourseDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_AssesmentId",
                table: "CourseDetails",
                column: "AssesmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_LanguageOptionId",
                table: "CourseDetails",
                column: "LanguageOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_SkillId",
                table: "CourseDetails",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseDetails_CourseDetailId",
                table: "Courses",
                column: "CourseDetailId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseDetails_CourseDetailId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseDetails");

            migrationBuilder.DropTable(
                name: "Assesments");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "SkillLevels");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseDetailId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseDetailId",
                table: "Courses");
        }
    }
}
