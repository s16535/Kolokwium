using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Configurations
{
    public class ChampionshipTeamConfiguration : IEntityTypeConfiguration<ChampionshipTeam>
    {
        public void Configure(EntityTypeBuilder<ChampionshipTeam> builder)
        {
            builder.HasKey(e => new { e.IdChampionship, e.IdTeam });

            builder.HasOne(e => e.Championship)
                .WithMany(e => e.ChampionshipTeams)
                .HasForeignKey(e => e.IdChampionship);

            builder.HasOne(e => e.Team)
                .WithMany(e => e.ChampionshipTeams)
                .HasForeignKey(e => e.IdTeam);

            builder.Property(e => e.Score)
                .IsRequired();
        }
    }
}
