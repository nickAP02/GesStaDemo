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
            Property(m => m.CodMat)
               .HasColumnName("Code_Mat")
               .HasColumnType("varchar")
               .HasMaxLength(10)
               .IsRequired();
            Property(m => m.LibMat)
               .HasColumnName("Libelle_Mat")
               .HasColumnType("varchar")
               .HasMaxLength(25)
               .IsRequired();
            Property(m => m.QuantMat)
               .HasColumnName("Quantite_Mat")
               .IsRequired();
            Property(m => m.Caracteristik)
               .HasColumnName("Caracteristik_Mat")
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired();
            
        }
    }
}