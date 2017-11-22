using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trabalho.Models;

namespace Trabalho.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171122140854_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trabalho.Models.Answer", b =>
                {
                    b.Property<int>("AnswerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerToClient");

                    b.Property<int>("ClientID");

                    b.HasKey("AnswerID");

                    b.HasIndex("ClientID");

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

                    b.ToTable("Client");
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

            modelBuilder.Entity("Trabalho.Models.Sur_Dis", b =>
                {
                    b.Property<int>("Sur_DisID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnswerID");

                    b.Property<int>("DiseasesID");

                    b.Property<int>("QuestionID");

                    b.Property<bool?>("YES_NO");

                    b.HasKey("Sur_DisID");

                    b.ToTable("Sur_Dis");
                });

            modelBuilder.Entity("Trabalho.Models.Survey", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Question");

                    b.Property<bool?>("QuestionState");

                    b.HasKey("ID");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("Trabalho.Models.Type_Client", b =>
                {
                    b.Property<int>("Type_ClientID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TypeClient");

                    b.HasKey("Type_ClientID");

                    b.ToTable("Type_Client");
                });

            modelBuilder.Entity("Trabalho.Models.Answer", b =>
                {
                    b.HasOne("Trabalho.Models.Client")
                        .WithMany("Answer")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
