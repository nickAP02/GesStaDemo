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
            Property(d => d.CodDiv)
               .HasColumnName("Code_division")
               .HasColumnType("varchar")
               .HasMaxLength(5)
               .IsRequired();
            Property(d => d.LibDiv)
               .HasColumnName("Libelle_division")
               .HasColumnType("varchar")
               .HasMaxLength(150)
               .IsRequired();
            Property(d => d.ActDiv)
               .HasColumnName("Action_division")
               .HasColumnType("varchar")
               .HasMaxLength(150)
               .IsRequired();
             
        }
    }
}