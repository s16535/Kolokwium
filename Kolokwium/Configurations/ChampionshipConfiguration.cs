using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Configurations
{
    public class ChampionshipConfiguration : IEntityTypeConfiguration<Championship>
    {
        public void Configure(EntityTypeBuilder<Championship> builder)
        {
            builder.HasKey(e => e.IdChampionship);
            builder.Property(e => e.IdChampionship).ValueGeneratedOnAdd();
            builder.Property(e => e.IdChampionship).IsRequired();

            builder.Property(e => e.OfficialName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.Year)
                   .IsRequired();

            builder.HasMany(e => e.ChampionshipTeams)
                   .WithOne(e => e.Championship)
                   .HasForeignKey(e => e.IdChampionship)
                   .IsRequired();
        }
    }
}
