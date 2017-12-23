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
                name: "Diseases",
                columns: table => new
                {
                    DiseasesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Care = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DiseasesName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.DiseasesID);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionState = table.Column<bool>(nullable: true),
                    QuestionToClient = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionID);
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
                name: "Type_Answer",
                columns: table => new
                {
                    Type_AnswerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PossibleAnswer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Answer", x => x.Type_AnswerID);
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
                    Final_Date = table.Column<DateTime>(nullable: false),
                    Initial_Date = table.Column<DateTime>(nullable: false),
                    TrailsName = table.Column<string>(nullable: true),
                    TrailsState = table.Column<bool>(nullable: false)
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
                name: "Que_Dis",
                columns: table => new
                {
                    Que_DisID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiseasesID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    YES_NO = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Que_Dis", x => x.Que_DisID);
                    table.ForeignKey(
                        name: "FK_Que_Dis_Diseases_DiseasesID",
                        column: x => x.DiseasesID,
                        principalTable: "Diseases",
                        principalColumn: "DiseasesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Que_Dis_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    SurveyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAnswer = table.Column<DateTime>(nullable: false),
                    DiseasesID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    TuristID = table.Column<int>(nullable: false),
                    Type_AnswerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.SurveyID);
                    table.ForeignKey(
                        name: "FK_Survey_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Survey_Turist_TuristID",
                        column: x => x.TuristID,
                        principalTable: "Turist",
                        principalColumn: "TuristID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ans_For_Que",
                columns: table => new
                {
                    Ans_For_QueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionID = table.Column<int>(nullable: false),
                    Type_AnswerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ans_For_Que", x => x.Ans_For_QueID);
                    table.ForeignKey(
                        name: "FK_Ans_For_Que_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ans_For_Que_Type_Answer_Type_AnswerID",
                        column: x => x.Type_AnswerID,
                        principalTable: "Type_Answer",
                        principalColumn: "Type_AnswerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tra_Sur",
                columns: table => new
                {
                    Tra_SurID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Recommended = table.Column<bool>(nullable: true),
                    SurveyID = table.Column<int>(nullable: false),
                    TrailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tra_Sur", x => x.Tra_SurID);
                    table.ForeignKey(
                        name: "FK_Tra_Sur_Survey_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Survey",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tra_Sur_Trails_TrailsID",
                        column: x => x.TrailsID,
                        principalTable: "Trails",
                        principalColumn: "TrailsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ans_For_Que_QuestionID",
                table: "Ans_For_Que",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Ans_For_Que_Type_AnswerID",
                table: "Ans_For_Que",
                column: "Type_AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_Que_Dis_DiseasesID",
                table: "Que_Dis",
                column: "DiseasesID");

            migrationBuilder.CreateIndex(
                name: "IX_Que_Dis_QuestionID",
                table: "Que_Dis",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_QuestionID",
                table: "Survey",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_TuristID",
                table: "Survey",
                column: "TuristID");

            migrationBuilder.CreateIndex(
                name: "IX_Tra_Sur_SurveyID",
                table: "Tra_Sur",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_Tra_Sur_TrailsID",
                table: "Tra_Sur",
                column: "TrailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_DifficultyID",
                table: "Trails",
                column: "DifficultyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ans_For_Que");

            migrationBuilder.DropTable(
                name: "Que_Dis");

            migrationBuilder.DropTable(
                name: "Tra_Sur");

            migrationBuilder.DropTable(
                name: "Type_Answer");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Trails");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Turist");

            migrationBuilder.DropTable(
                name: "Difficulty");
        }
    }
}
