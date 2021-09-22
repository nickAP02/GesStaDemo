using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    class RemunerationConfigurations: EntityTypeConfiguration<Remuneration>
    {
        public RemunerationConfigurations()
        {
            ToTable("Remuneration");
            HasKey(r => r.CodRem);
            Property(r => r.CodRem)
                .HasColumnName("CodRem")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();
            Property(r => r.RegleMens)
                .HasColumnName("RegleMens")
                .HasColumnType("decimal")
                .IsRequired();
            Property(r => r.DateRemiz)
                .HasColumnName("DateRemiz")
                .HasColumnType("date")
                .IsRequired();
            HasRequired(r => r.Stagiaire)
                 .WithMany(s => s.Remunerations)
                 .HasForeignKey(r => r.IdSta);
        }
    }
}