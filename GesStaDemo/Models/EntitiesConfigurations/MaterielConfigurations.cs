using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    class MaterielConfigurations : EntityTypeConfiguration<Materiel>
    {
        public MaterielConfigurations()
        {
            ToTable("Materiel");
            HasKey(m => m.CodMat);
            Property(m => m.CodMat)
               .HasColumnName("CodMat")
               .HasColumnType("varchar")
               .HasMaxLength(10)
               .IsRequired();
            Property(m => m.LibMat)
               .HasColumnName("LibMat")
               .HasColumnType("varchar")
               .HasMaxLength(25)
               .IsRequired();
            Property(m => m.QuantMat)
               .HasColumnName("QuantMat")
               .IsRequired();
            Property(m => m.Caracteristik)
               .HasColumnName("Caracteristik")
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired();
            
        }
    }
}