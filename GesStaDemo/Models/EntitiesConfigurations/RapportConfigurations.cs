using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
   class RapportConfigurations : EntityTypeConfiguration<Rapport>
   {
     public RapportConfigurations()
     {
         ToTable("Rapport");
         Property(r => r.CodRapp)
             .HasColumnName("Code_Rapp")
             .HasColumnType("varchar")
             .HasMaxLength(18)
             .IsRequired();
            Property(r => r.NomRapp)
                .HasColumnName("Nom_Rapp")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
            Property(r => r.Taches)
                .HasColumnName("Taches")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
            Property(r => r.DatePresentat)
                .HasColumnName("Date_presentat")
                .HasColumnType("dateTime")
                .IsRequired();
            HasMany(r => r.Notations);
        }
   }
}