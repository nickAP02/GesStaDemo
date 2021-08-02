using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    class SectionConfigurations : EntityTypeConfiguration<Section>
    {
        public SectionConfigurations()
        {
            ToTable("Section");
            Property(s => s.CodSec)
                .HasColumnName("Code_Section")
                .HasColumnType("varchar")
                .HasMaxLength(5)
                .IsRequired();
            Property(s => s.LibSec)
                .HasColumnName("Libelle_Section")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
            Property(s => s.ActSec)
                .HasColumnName("Action_Section")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
            HasMany(s => s.Divisions);
            HasMany(s => s.Formations);
            HasMany(s => s.MaitreDeStages);
        }
    }
}