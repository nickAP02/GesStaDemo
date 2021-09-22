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
            HasKey(s => s.CodSec);
            Property(s => s.CodSec)
                .HasColumnName("CodSec")
                .HasColumnType("varchar")
                .HasMaxLength(5)
                .IsRequired();
            Property(s => s.LibSec)
                .HasColumnName("Libelle")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
            Property(s => s.ActSec)
                .HasColumnName("Action")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
            HasRequired(s => s.Division)
                .WithMany(d => d.Sections)
                .HasForeignKey(s => s.CodDiv);
        }
    }
}