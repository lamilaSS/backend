using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mcq_backend.Migrations
{
    public partial class questionKeyless2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionKeylesses",
                columns: table => new
                {
                    questionID = table.Column<Guid>(type: "uuid", nullable: false),
                    questionContent = table.Column<string>(type: "text", nullable: true),
                    difficulty = table.Column<int>(type: "integer", nullable: true),
                    creator = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionKeylesses");
        }
    }
}
