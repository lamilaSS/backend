using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace mcq_backend.Migrations
{
    public partial class removeBitArray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    gameID = table.Column<Guid>(type: "uuid", nullable: false),
                    gameDescription = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    time = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.gameID);
                });

            migrationBuilder.CreateTable(
                name: "idoru",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    age = table.Column<short>(type: "smallint", nullable: false),
                    addr = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    gender = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idoru", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IdoruKeylesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<short>(type: "smallint", nullable: false),
                    Addr = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    questionID = table.Column<Guid>(type: "uuid", nullable: false),
                    questionContent = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    difficulty = table.Column<int>(type: "integer", nullable: true),
                    creator = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.questionID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    password = table.Column<string>(type: "character(60)", fixedLength: true, maxLength: 60, nullable: true),
                    feedback = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fullname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    image = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    userStatus = table.Column<int>(type: "integer", nullable: true),
                    createDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Lifeline",
                columns: table => new
                {
                    lifelineID = table.Column<Guid>(type: "uuid", nullable: false),
                    gameID = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lifeline", x => x.lifelineID);
                    table.ForeignKey(
                        name: "Lifeline_gameID_fkey",
                        column: x => x.gameID,
                        principalTable: "Game",
                        principalColumn: "gameID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    answerID = table.Column<Guid>(type: "uuid", nullable: false),
                    questionID = table.Column<Guid>(type: "uuid", nullable: true),
                    answerContent = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    isCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.answerID);
                    table.ForeignKey(
                        name: "Answer_questionID_fkey",
                        column: x => x.questionID,
                        principalTable: "Question",
                        principalColumn: "questionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameQuestion",
                columns: table => new
                {
                    gameQuestionID = table.Column<Guid>(type: "uuid", nullable: false),
                    gameID = table.Column<Guid>(type: "uuid", nullable: true),
                    questionID = table.Column<Guid>(type: "uuid", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameQuestion", x => x.gameQuestionID);
                    table.ForeignKey(
                        name: "GameQuestion_gameID_fkey",
                        column: x => x.gameID,
                        principalTable: "Game",
                        principalColumn: "gameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "GameQuestion_questionID_fkey",
                        column: x => x.questionID,
                        principalTable: "Question",
                        principalColumn: "questionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScoreDetail",
                columns: table => new
                {
                    scoreDetailID = table.Column<Guid>(type: "uuid", nullable: false),
                    questionID = table.Column<Guid>(type: "uuid", nullable: true),
                    isCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreDetail", x => x.scoreDetailID);
                    table.ForeignKey(
                        name: "ScoreDetail_questionID_fkey",
                        column: x => x.questionID,
                        principalTable: "Question",
                        principalColumn: "questionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ScoreDetail_questionID_fkey1",
                        column: x => x.questionID,
                        principalTable: "Game",
                        principalColumn: "gameID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    historyID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    gameID = table.Column<Guid>(type: "uuid", nullable: true),
                    score = table.Column<int>(type: "integer", nullable: true),
                    session = table.Column<string>(type: "character(100)", fixedLength: true, maxLength: 100, nullable: true),
                    timeFinished = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    totalQuestion = table.Column<int>(type: "integer", nullable: true),
                    numOfCorrect = table.Column<int>(type: "integer", nullable: true),
                    scoreDetailID = table.Column<Guid>(type: "uuid", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.historyID);
                    table.ForeignKey(
                        name: "History_gameID_fkey",
                        column: x => x.gameID,
                        principalTable: "Game",
                        principalColumn: "gameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "History_scoreDetailID_fkey",
                        column: x => x.scoreDetailID,
                        principalTable: "ScoreDetail",
                        principalColumn: "scoreDetailID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "History_userID_fkey",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_questionID",
                table: "Answer",
                column: "questionID");

            migrationBuilder.CreateIndex(
                name: "IX_GameQuestion_gameID",
                table: "GameQuestion",
                column: "gameID");

            migrationBuilder.CreateIndex(
                name: "IX_GameQuestion_questionID",
                table: "GameQuestion",
                column: "questionID");

            migrationBuilder.CreateIndex(
                name: "IX_History_gameID",
                table: "History",
                column: "gameID");

            migrationBuilder.CreateIndex(
                name: "IX_History_scoreDetailID",
                table: "History",
                column: "scoreDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_History_userID",
                table: "History",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Lifeline_gameID",
                table: "Lifeline",
                column: "gameID");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreDetail_questionID",
                table: "ScoreDetail",
                column: "questionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "GameQuestion");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "idoru");

            migrationBuilder.DropTable(
                name: "IdoruKeylesses");

            migrationBuilder.DropTable(
                name: "Lifeline");

            migrationBuilder.DropTable(
                name: "ScoreDetail");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
