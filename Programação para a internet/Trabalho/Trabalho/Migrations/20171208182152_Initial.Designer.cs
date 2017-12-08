using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trabalho.Models;

namespace Trabalho.Migrations
{
    [DbContext(typeof(TrabalhoDbContext))]
    [Migration("20171208182152_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trabalho.Models.Ans_Que", b =>
                {
                    b.Property<int>("Ans_QueID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionID");

                    b.Property<string>("ResPer");

                    b.HasKey("Ans_QueID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Ans_Que");
                });

            modelBuilder.Entity("Trabalho.Models.Answer", b =>
                {
                    b.Property<int>("AnswerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerToClient")
                        .IsRequired();

                    b.Property<int>("ClientID");

                    b.Property<int>("SurveyID");

                    b.HasKey("AnswerID");

                    b.HasIndex("ClientID");

                    b.HasIndex("SurveyID");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Trabalho.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("ClientName");

                    b.Property<bool?>("ClientState");

                    b.Property<string>("Email");

                    b.Property<int>("Emergency_Contact");

                    b.Property<bool?>("Genre");

                    b.Property<int>("NIF");

                    b.Property<int>("PhoneNumber");

                    b.Property<int>("Type_ClientID");

                    b.HasKey("ClientID");

                    b.HasIndex("Type_ClientID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Trabalho.Models.Difficulty", b =>
                {
                    b.Property<int>("DifficultyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DifficultyName");

                    b.Property<string>("Observation");

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

            modelBuilder.Entity("Trabalho.Models.Sur_Que", b =>
                {
                    b.Property<int>("Sur_QueID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionID");

                    b.Property<int>("SurveyID");

                    b.HasKey("Sur_QueID");

                    b.HasIndex("QuestionID");

                    b.HasIndex("SurveyID");

                    b.ToTable("Sur_Que");
                });

            modelBuilder.Entity("Trabalho.Models.Survey", b =>
                {
                    b.Property<int>("SurveyID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("SurveyState");

                    b.HasKey("SurveyID");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("Trabalho.Models.Tra_An", b =>
                {
                    b.Property<int>("Tra_AnID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnswerID");

                    b.Property<string>("Recomendation");

                    b.Property<int>("TrailsID");

                    b.HasKey("Tra_AnID");

                    b.HasIndex("AnswerID");

                    b.HasIndex("TrailsID");

                    b.ToTable("Tra_An");
                });

            modelBuilder.Entity("Trabalho.Models.Trails", b =>
                {
                    b.Property<int>("TrailsID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DifficultyID");

                    b.Property<int>("Distance");

                    b.Property<string>("TrailsName");

                    b.HasKey("TrailsID");

                    b.HasIndex("DifficultyID");

                    b.ToTable("Trails");
                });

            modelBuilder.Entity("Trabalho.Models.Type_Client", b =>
                {
                    b.Property<int>("Type_ClientID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TypeClient");

                    b.HasKey("Type_ClientID");

                    b.ToTable("Type_Client");
                });

            modelBuilder.Entity("Trabalho.Models.Ans_Que", b =>
                {
                    b.HasOne("Trabalho.Models.Question", "Question")
                        .WithMany("Ans_Que")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trabalho.Models.Answer", b =>
                {
                    b.HasOne("Trabalho.Models.Client", "Client")
                        .WithMany("Answer")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trabalho.Models.Survey", "Survey")
                        .WithMany("Answer")
                        .HasForeignKey("SurveyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trabalho.Models.Client", b =>
                {
                    b.HasOne("Trabalho.Models.Type_Client", "Type_Client")
                        .WithMany("Client")
                        .HasForeignKey("Type_ClientID")
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

            modelBuilder.Entity("Trabalho.Models.Sur_Que", b =>
                {
                    b.HasOne("Trabalho.Models.Question", "Question")
                        .WithMany("Sur_Que")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trabalho.Models.Survey", "Survey")
                        .WithMany("Sur_Que")
                        .HasForeignKey("SurveyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trabalho.Models.Tra_An", b =>
                {
                    b.HasOne("Trabalho.Models.Answer", "Answer")
                        .WithMany("Tra_An")
                        .HasForeignKey("AnswerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trabalho.Models.Trails", "Trails")
                        .WithMany("Tra_An")
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
