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
                    DifficultyName = table.Column<string>(nullable: true),
                    Observation = table.Column<string>(nullable: true)
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
                name: "Survey",
                columns: table => new
                {
                    SurveyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurveyState = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.SurveyID);
                });

            migrationBuilder.CreateTable(
                name: "Type_Client",
                columns: table => new
                {
                    Type_ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeClient = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Client", x => x.Type_ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DifficultyID = table.Column<int>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    TrailsName = table.Column<string>(nullable: true)
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
                name: "Ans_Que",
                columns: table => new
                {
                    Ans_QueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionID = table.Column<int>(nullable: false),
                    ResPer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ans_Que", x => x.Ans_QueID);
                    table.ForeignKey(
                        name: "FK_Ans_Que_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "QuestionID",
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
                name: "Sur_Que",
                columns: table => new
                {
                    Sur_QueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionID = table.Column<int>(nullable: false),
                    SurveyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sur_Que", x => x.Sur_QueID);
                    table.ForeignKey(
                        name: "FK_Sur_Que_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sur_Que_Survey_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Survey",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthday = table.Column<DateTime>(nullable: false),
                    ClientName = table.Column<string>(nullable: true),
                    ClientState = table.Column<bool>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Emergency_Contact = table.Column<int>(nullable: false),
                    Genre = table.Column<bool>(nullable: true),
                    NIF = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Type_ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Client_Type_Client_Type_ClientID",
                        column: x => x.Type_ClientID,
                        principalTable: "Type_Client",
                        principalColumn: "Type_ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerToClient = table.Column<string>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    SurveyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_Answer_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_Survey_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Survey",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tra_An",
                columns: table => new
                {
                    Tra_AnID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerID = table.Column<int>(nullable: false),
                    Recomendation = table.Column<string>(nullable: true),
                    TrailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tra_An", x => x.Tra_AnID);
                    table.ForeignKey(
                        name: "FK_Tra_An_Answer_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "Answer",
                        principalColumn: "AnswerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tra_An_Trails_TrailsID",
                        column: x => x.TrailsID,
                        principalTable: "Trails",
                        principalColumn: "TrailsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ans_Que_QuestionID",
                table: "Ans_Que",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_ClientID",
                table: "Answer",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_SurveyID",
                table: "Answer",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Type_ClientID",
                table: "Client",
                column: "Type_ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Que_Dis_DiseasesID",
                table: "Que_Dis",
                column: "DiseasesID");

            migrationBuilder.CreateIndex(
                name: "IX_Que_Dis_QuestionID",
                table: "Que_Dis",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Sur_Que_QuestionID",
                table: "Sur_Que",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Sur_Que_SurveyID",
                table: "Sur_Que",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_Tra_An_AnswerID",
                table: "Tra_An",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tra_An_TrailsID",
                table: "Tra_An",
                column: "TrailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_DifficultyID",
                table: "Trails",
                column: "DifficultyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ans_Que");

            migrationBuilder.DropTable(
                name: "Que_Dis");

            migrationBuilder.DropTable(
                name: "Sur_Que");

            migrationBuilder.DropTable(
                name: "Tra_An");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Trails");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Difficulty");

            migrationBuilder.DropTable(
                name: "Type_Client");
        }
    }
}
