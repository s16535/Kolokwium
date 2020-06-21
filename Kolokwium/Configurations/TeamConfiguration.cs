using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(e => e.IdTeam);
            builder.Property(e => e.IdTeam).ValueGeneratedOnAdd();
            builder.Property(e => e.IdTeam).IsRequired();

            builder.Property(e => e.TeamName)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(e => e.MaxAge)
                   .IsRequired();

            builder.HasMany(e => e.PlayerTeams)
                   .WithOne(e => e.Team)
                   .HasForeignKey(e => e.IdTeam)
                   .IsRequired();

            builder.HasMany(e => e.ChampionshipTeams)
                   .WithOne(e => e.Team)
                   .HasForeignKey(e => e.IdTeam)
                   .IsRequired();
        }
    }
}
