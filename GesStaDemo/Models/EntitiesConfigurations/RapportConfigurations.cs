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
            HasKey(r => r.CodRapp);
         Property(r => r.CodRapp)
             .HasColumnName("CodRapp")
             .HasColumnType("varchar")
             .HasMaxLength(18)
             .IsRequired();
            Property(r => r.NomRapp)
                .HasColumnName("NomRapp")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
            Property(r => r.Taches)
                .HasColumnName("Taches")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
            Property(r => r.DatePresentat)
                .HasColumnName("DatePresentat")
                .HasColumnType("dateTime")
                .IsRequired();
            //HasMany(r => r.Notations);
        }
   }
}