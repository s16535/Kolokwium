using Kolokwium.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class LeagueDbContext : DbContext
    {
        public LeagueDbContext() { }

        public LeagueDbContext(DbContextOptions options)
        : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<ChampionshipTeam> ChampionshipTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerTeamConfiguration());
            modelBuilder.ApplyConfiguration(new ChampionshipConfiguration());
            modelBuilder.ApplyConfiguration(new ChampionshipTeamConfiguration());

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            var Players = new List<Player>();
            var Teams = new List<Team>();
            var PlayerTeams = new List<PlayerTeam>();
            var Championships = new List<Championship>();
            var ChampionshipTeams = new List<ChampionshipTeam>();

            Players.Add(new Player { IdPlayer = 1, FirstName = "Janusz", LastName = "Bąbalski", DateOfBirth = new DateTime(1980, 11, 2) });

            Teams.Add(new Team { IdTeam = 1, TeamName = "Bąbelki", MaxAge = 108 });

            PlayerTeams.Add(new PlayerTeam { IdPlayer = 1, IdTeam = 1, NumOnShirt = 199, Comment = "No comments" });

            Championships.Add(new Championship { IdChampionship = 1, OfficialName = "Mistrzostwa Świata i Okolic", Year = 2020 });

            ChampionshipTeams.Add(new ChampionshipTeam { IdChampionship = 1, IdTeam = 1, Score = 180.5F });

            modelBuilder.Entity<Player>().HasData(Players);
            modelBuilder.Entity<Team>().HasData(Teams);
            modelBuilder.Entity<PlayerTeam>().HasData(PlayerTeams);
            modelBuilder.Entity<Championship>().HasData(Championships);
            modelBuilder.Entity<ChampionshipTeam>().HasData(ChampionshipTeams);
        }

    }
}
