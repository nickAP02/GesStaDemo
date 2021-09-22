using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    class DivisionConfigurations : EntityTypeConfiguration<Division>
    {
        public DivisionConfigurations()
        {
            ToTable("Division");
            HasKey(d => d.CodDiv);
            Property(d => d.CodDiv)
               .HasColumnName("CodDiv")
               .HasColumnType("varchar")
               .HasMaxLength(5)
               .IsRequired();
            Property(d => d.LibDiv)
               .HasColumnName("LibDiv")
               .HasColumnType("varchar")
               .HasMaxLength(150)
               .IsRequired();
            Property(d => d.ActDiv)
               .HasColumnName("Action")
               .HasColumnType("varchar")
               .HasMaxLength(150)
               .IsRequired();
            HasRequired(d => d.Direction)
                .WithMany(d => d.Divisions)
                .HasForeignKey(d => d.CodDir);
        }
    }
}