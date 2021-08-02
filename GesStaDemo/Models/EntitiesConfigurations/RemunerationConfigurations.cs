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
            Property(r => r.CodRem)
                .HasColumnName("Code_Remiz")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();
            Property(r => r.RegleMens)
                .HasColumnName("Reglement")
                .HasColumnType("varchar")
                .HasMaxLength(6)
                .IsRequired();
            Property(r => r.DateRemiz)
                .HasColumnName("Date_Remiz")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}