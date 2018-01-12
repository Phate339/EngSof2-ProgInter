using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trabalho.Models;

namespace Trabalho.Migrations
{
    [DbContext(typeof(TrabalhoDbContext))]
    partial class TrabalhoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trabalho.Models.Answer", b =>
                {
                    b.Property<int>("AnswerID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DifficultyID");

                    b.Property<string>("PossibleAnswer");

                    b.Property<int>("QuestionsID");

                    b.HasKey("AnswerID");

                    b.HasIndex("DifficultyID");

                    b.HasIndex("QuestionsID");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Trabalho.Models.Difficulty", b =>
                {
                    b.Property<int>("DifficultyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DifficultyName");

                    b.HasKey("DifficultyID");

                    b.ToTable("Difficulty");
                });

            modelBuilder.Entity("Trabalho.Models.Questions", b =>
                {
                    b.Property<int>("QuestionsID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("QuestionsState");

                    b.Property<string>("QuestionsToClient");

                    b.HasKey("QuestionsID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Trabalho.Models.Trails", b =>
                {
                    b.Property<int>("TrailsID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("DifficultyID");

                    b.Property<int>("Distance");

                    b.Property<DateTime>("FinalDate");

                    b.Property<DateTime>("InitialDate");

                    b.Property<string>("TrailsName");

                    b.Property<bool>("TrailsState");

                    b.Property<DateTime>("TrailsStateDate");

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

            modelBuilder.Entity("Trabalho.Models.TuristAnswer", b =>
                {
                    b.Property<int>("TuristAnswerID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AnswerDate");

                    b.Property<int>("AnswerID");

                    b.Property<int>("SurveyNumber");

                    b.Property<int>("TuristID");

                    b.HasKey("TuristAnswerID");

                    b.HasIndex("AnswerID");

                    b.HasIndex("TuristID");

                    b.ToTable("TuristAnswer");
                });

            modelBuilder.Entity("Trabalho.Models.Answer", b =>
                {
                    b.HasOne("Trabalho.Models.Difficulty", "Difficulty")
                        .WithMany("Answer")
                        .HasForeignKey("DifficultyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trabalho.Models.Questions", "Questions")
                        .WithMany("Answer")
                        .HasForeignKey("QuestionsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trabalho.Models.Trails", b =>
                {
                    b.HasOne("Trabalho.Models.Difficulty", "Difficulty")
                        .WithMany("Trails")
                        .HasForeignKey("DifficultyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trabalho.Models.TuristAnswer", b =>
                {
                    b.HasOne("Trabalho.Models.Answer", "Answer")
                        .WithMany("TuristAnswer")
                        .HasForeignKey("AnswerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trabalho.Models.Turist", "Turist")
                        .WithMany("TuristAnswer")
                        .HasForeignKey("TuristID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
