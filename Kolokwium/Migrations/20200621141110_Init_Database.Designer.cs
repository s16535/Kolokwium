﻿// <auto-generated />
using System;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kolokwium.Migrations
{
    [DbContext(typeof(LeagueDbContext))]
    [Migration("20200621141110_Init_Database")]
    partial class Init_Database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.5.20278.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kolokwium.Models.Championship", b =>
                {
                    b.Property<int>("IdChampionship")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OfficialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("IdChampionship");

                    b.ToTable("Championships");

                    b.HasData(
                        new
                        {
                            IdChampionship = 1,
                            OfficialName = "Mistrzostwa Świata i Okolic",
                            Year = 2020
                        });
                });

            modelBuilder.Entity("Kolokwium.Models.ChampionshipTeam", b =>
                {
                    b.Property<int>("IdChampionship")
                        .HasColumnType("int");

                    b.Property<int>("IdTeam")
                        .HasColumnType("int");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.HasKey("IdChampionship", "IdTeam");

                    b.HasIndex("IdTeam");

                    b.ToTable("ChampionshipTeams");

                    b.HasData(
                        new
                        {
                            IdChampionship = 1,
                            IdTeam = 1,
                            Score = 180.5f
                        });
                });

            modelBuilder.Entity("Kolokwium.Models.Player", b =>
                {
                    b.Property<int>("IdPlayer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdPlayer");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            IdPlayer = 1,
                            DateOfBirth = new DateTime(1980, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Janusz",
                            LastName = "Bąbalski"
                        });
                });

            modelBuilder.Entity("Kolokwium.Models.PlayerTeam", b =>
                {
                    b.Property<int>("IdPlayer")
                        .HasColumnType("int");

                    b.Property<int>("IdTeam")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("NumOnShirt")
                        .HasColumnType("int")
                        .HasMaxLength(100);

                    b.HasKey("IdPlayer", "IdTeam");

                    b.HasIndex("IdTeam");

                    b.ToTable("PlayerTeams");

                    b.HasData(
                        new
                        {
                            IdPlayer = 1,
                            IdTeam = 1,
                            Comment = "No comments",
                            NumOnShirt = 199
                        });
                });

            modelBuilder.Entity("Kolokwium.Models.Team", b =>
                {
                    b.Property<int>("IdTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("IdTeam");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            IdTeam = 1,
                            MaxAge = 108,
                            TeamName = "Bąbelki"
                        });
                });

            modelBuilder.Entity("Kolokwium.Models.ChampionshipTeam", b =>
                {
                    b.HasOne("Kolokwium.Models.Championship", "Championship")
                        .WithMany("ChampionshipTeams")
                        .HasForeignKey("IdChampionship")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium.Models.Team", "Team")
                        .WithMany("ChampionshipTeams")
                        .HasForeignKey("IdTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kolokwium.Models.PlayerTeam", b =>
                {
                    b.HasOne("Kolokwium.Models.Player", "Player")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("IdPlayer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium.Models.Team", "Team")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("IdTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
