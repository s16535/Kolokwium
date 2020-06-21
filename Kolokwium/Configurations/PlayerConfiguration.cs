using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(e => e.IdPlayer);
            builder.Property(e => e.IdPlayer).ValueGeneratedOnAdd();
            builder.Property(e => e.IdPlayer).IsRequired();

            builder.Property(e => e.FirstName)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(e => e.LastName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.DateOfBirth)
                   .IsRequired();

            builder.HasMany(e => e.PlayerTeams)
                   .WithOne(e => e.Player)
                   .HasForeignKey(e => e.IdPlayer)
                   .IsRequired();
        }
    }
}
