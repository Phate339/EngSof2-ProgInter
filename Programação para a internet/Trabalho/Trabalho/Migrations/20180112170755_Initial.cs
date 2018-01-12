using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trabalho.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulty",
                columns: table => new
                {
                    DifficultyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DifficultyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty", x => x.DifficultyID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionsState = table.Column<bool>(nullable: false),
                    QuestionsToClient = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionsID);
                });

            migrationBuilder.CreateTable(
                name: "Turist",
                columns: table => new
                {
                    TuristID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmergencyContact = table.Column<int>(nullable: false),
                    Genre = table.Column<bool>(nullable: true),
                    NIF = table.Column<int>(nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    TuristName = table.Column<string>(nullable: true),
                    TuristState = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turist", x => x.TuristID);
                });

            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    DifficultyID = table.Column<int>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    FinalDate = table.Column<DateTime>(nullable: false),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    TrailsName = table.Column<string>(nullable: true),
                    TrailsState = table.Column<bool>(nullable: false),
                    TrailsStateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailsID);
                    table.ForeignKey(
                        name: "FK_Trails_Difficulty_DifficultyID",
                        column: x => x.DifficultyID,
                        principalTable: "Difficulty",
                        principalColumn: "DifficultyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PossibleAnswer = table.Column<string>(nullable: true),
                    QuestionsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_Answer_Questions_QuestionsID",
                        column: x => x.QuestionsID,
                        principalTable: "Questions",
                        principalColumn: "QuestionsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    ParametersID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerID = table.Column<int>(nullable: false),
                    DifficultyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.ParametersID);
                    table.ForeignKey(
                        name: "FK_Parameters_Answer_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "Answer",
                        principalColumn: "AnswerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parameters_Difficulty_DifficultyID",
                        column: x => x.DifficultyID,
                        principalTable: "Difficulty",
                        principalColumn: "DifficultyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TuristAnswer",
                columns: table => new
                {
                    TuristAnswerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerDate = table.Column<DateTime>(nullable: false),
                    AnswerID = table.Column<int>(nullable: false),
                    SurveyNumber = table.Column<int>(nullable: false),
                    TuristID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuristAnswer", x => x.TuristAnswerID);
                    table.ForeignKey(
                        name: "FK_TuristAnswer_Answer_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "Answer",
                        principalColumn: "AnswerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TuristAnswer_Turist_TuristID",
                        column: x => x.TuristID,
                        principalTable: "Turist",
                        principalColumn: "TuristID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionsID",
                table: "Answer",
                column: "QuestionsID");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_AnswerID",
                table: "Parameters",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_DifficultyID",
                table: "Parameters",
                column: "DifficultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_DifficultyID",
                table: "Trails",
                column: "DifficultyID");

            migrationBuilder.CreateIndex(
                name: "IX_TuristAnswer_AnswerID",
                table: "TuristAnswer",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_TuristAnswer_TuristID",
                table: "TuristAnswer",
                column: "TuristID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "Trails");

            migrationBuilder.DropTable(
                name: "TuristAnswer");

            migrationBuilder.DropTable(
                name: "Difficulty");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Turist");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
