using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trabalho.Models;

namespace Trabalho.Migrations
{
    [DbContext(typeof(TrabalhoDbContext))]
    [Migration("20180111143051_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trabalho.Models.Difficulty", b =>
                {
                    b.Property<int>("DifficultyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DifficultyName");

                    b.HasKey("DifficultyID");

                    b.ToTable("Difficulty");
                });

            modelBuilder.Entity("Trabalho.Models.Parameters", b =>
                {
                    b.Property<int>("ParametersID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AllowedAnswer");

                    b.Property<int>("DifficultyID");

                    b.Property<int>("QuestionsID");

                    b.HasKey("ParametersID");

                    b.HasIndex("DifficultyID");

                    b.HasIndex("QuestionsID");

                    b.ToTable("Parameters");
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

                    b.Property<int>("QuestionsID");

                    b.Property<int>("SurveyNumber");

                    b.Property<int>("TuristAnswerName");

                    b.Property<int>("TuristID");

                    b.HasKey("TuristAnswerID");

                    b.HasIndex("QuestionsID");

                    b.HasIndex("TuristID");

                    b.ToTable("TuristAnswer");
                });

            modelBuilder.Entity("Trabalho.Models.TypeAnswer", b =>
                {
                    b.Property<int>("TypeAnswerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PossibleAnswer");

                    b.Property<int>("QuestionsID");

                    b.HasKey("TypeAnswerID");

                    b.HasIndex("QuestionsID");

                    b.ToTable("TypeAnswer");
                });

            modelBuilder.Entity("Trabalho.Models.Parameters", b =>
                {
                    b.HasOne("Trabalho.Models.Difficulty", "Difficulty")
                        .WithMany("Parameters")
                        .HasForeignKey("DifficultyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trabalho.Models.Questions", "Questions")
                        .WithMany("Parameters")
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
                    b.HasOne("Trabalho.Models.Questions", "Questions")
                        .WithMany("TuristAnswer")
                        .HasForeignKey("QuestionsID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trabalho.Models.Turist", "Turist")
                        .WithMany("TuristAnswer")
                        .HasForeignKey("TuristID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trabalho.Models.TypeAnswer", b =>
                {
                    b.HasOne("Trabalho.Models.Questions", "Questions")
                        .WithMany("TypeAnswer")
                        .HasForeignKey("QuestionsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
