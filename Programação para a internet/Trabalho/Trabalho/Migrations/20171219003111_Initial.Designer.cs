using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trabalho.Models;

namespace Trabalho.Migrations
{
    [DbContext(typeof(TrabalhoDbContext))]
    [Migration("20171219003111_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trabalho.Models.Ans_For_Que", b =>
                {
                    b.Property<int>("Ans_For_QueID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionID");

                    b.Property<int>("Type_AnswerID");

                    b.HasKey("Ans_For_QueID");

                    b.HasIndex("QuestionID");

                    b.HasIndex("Type_AnswerID");

                    b.ToTable("Ans_For_Que");
                });

            modelBuilder.Entity("Trabalho.Models.Difficulty", b =>
                {
                    b.Property<int>("DifficultyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DifficultyName");

                    b.HasKey("DifficultyID");

                    b.ToTable("Difficulty");
                });

            modelBuilder.Entity("Trabalho.Models.Diseases", b =>
                {
                    b.Property<int>("DiseasesID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Care");

                    b.Property<string>("Description");

                    b.Property<string>("DiseasesName");

                    b.HasKey("DiseasesID");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("Trabalho.Models.Que_Dis", b =>
                {
                    b.Property<int>("Que_DisID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DiseasesID");

                    b.Property<int>("QuestionID");

                    b.Property<bool?>("YES_NO");

                    b.HasKey("Que_DisID");

                    b.HasIndex("DiseasesID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Que_Dis");
                });

            modelBuilder.Entity("Trabalho.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("QuestionState");

                    b.Property<string>("QuestionToClient");

                    b.HasKey("QuestionID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Trabalho.Models.Survey", b =>
                {
                    b.Property<int>("SurveyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerToTurist");

                    b.Property<DateTime>("DateAnswer");

                    b.Property<int>("DiseasesID");

                    b.Property<int>("QuestionID");

                    b.Property<int>("TuristID");

                    b.Property<int>("Type_AnswerID");

                    b.HasKey("SurveyID");

                    b.HasIndex("QuestionID");

                    b.HasIndex("TuristID");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("Trabalho.Models.Tra_Sur", b =>
                {
                    b.Property<int>("Tra_SurID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("QuestionID");

                    b.Property<bool?>("Recommended");

                    b.Property<int>("SurveyID");

                    b.Property<int>("TrailsID");

                    b.HasKey("Tra_SurID");

                    b.HasIndex("QuestionID");

                    b.HasIndex("SurveyID");

                    b.HasIndex("TrailsID");

                    b.ToTable("Tra_Sur");
                });

            modelBuilder.Entity("Trabalho.Models.Trails", b =>
                {
                    b.Property<int>("TrailsID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("DifficultyID");

                    b.Property<int>("Distance");

                    b.Property<string>("TrailsName");

                    b.HasKey("TrailsID");

                    b.HasIndex("DifficultyID");

                    b.ToTable("Trails");
                });

            modelBuilder.Entity("Trabalho.Models.Turist", b =>
                {
                    b.Property<int>("TuristID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Email");

                    b.Property<int>("EmergencyContact");

                    b.Property<bool?>("Genre");

                    b.Property<int>("NIF");

                    b.Property<int>("Phone");

                    b.Property<string>("TuristName");

                    b.Property<bool?>("TuristState");

                    b.HasKey("TuristID");

                    b.ToTable("Turist");
                });

            modelBuilder.Entity("Trabalho.Models.Type_Answer", b =>
                {
                    b.Property<int>("Type_AnswerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PossibleAnswer");

                    b.HasKey("Type_AnswerID");

                    b.ToTable("Type_Answer");
                });

            modelBuilder.Entity("Trabalho.Models.Ans_For_Que", b =>
                {
                    b.HasOne("Trabalho.Models.Question", "Question")
                        .WithMany("Ans_For_Que")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trabalho.Models.Type_Answer", "Type_Answer")
                        .WithMany("Ans_For_Que")
                        .HasForeignKey("Type_AnswerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trabalho.Models.Que_Dis", b =>
                {
                    b.HasOne("Trabalho.Models.Diseases", "Diseases")
                        .WithMany("Que_Dis")
                        .HasForeignKey("DiseasesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trabalho.Models.Question", "Question")
                        .WithMany("Que_Dis")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trabalho.Models.Survey", b =>
                {
                    b.HasOne("Trabalho.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trabalho.Models.Turist", "Turist")
                        .WithMany("Survey")
                        .HasForeignKey("TuristID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trabalho.Models.Tra_Sur", b =>
                {
                    b.HasOne("Trabalho.Models.Question")
                        .WithMany("Tra_Sur")
                        .HasForeignKey("QuestionID");

                    b.HasOne("Trabalho.Models.Survey", "Survey")
                        .WithMany()
                        .HasForeignKey("SurveyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trabalho.Models.Trails", "Trails")
                        .WithMany("Tra_Sur")
                        .HasForeignKey("TrailsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trabalho.Models.Trails", b =>
                {
                    b.HasOne("Trabalho.Models.Difficulty", "Difficulty")
                        .WithMany("Trails")
                        .HasForeignKey("DifficultyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
