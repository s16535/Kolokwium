using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Configurations
{
    public class PlayerTeamConfiguration : IEntityTypeConfiguration<PlayerTeam>
    {
        public void Configure(EntityTypeBuilder<PlayerTeam> builder)
        {
            builder.HasKey(e => new { e.IdPlayer, e.IdTeam });

            builder.HasOne(e => e.Player)
                .WithMany(e => e.PlayerTeams)
                .HasForeignKey(e => e.IdPlayer);

            builder.HasOne(e => e.Team)
                .WithMany(e => e.PlayerTeams)
                .HasForeignKey(e => e.IdTeam);

            builder.Property(e => e.NumOnShirt)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Comment)
                .HasMaxLength(300);
        }
    }
}
