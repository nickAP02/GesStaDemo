using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
     class SortirDeConfigurations : EntityTypeConfiguration<SortirDe>
    {
        public SortirDeConfigurations()
        {
            ToTable("SortirDe");
            Property(s => s.DatePro)
                .HasColumnName("Date_Prov")
                .IsRequired();
            Property(s => s.NivoEtude)
                .HasColumnName("Niveau")
                .HasMaxLength(15)
                .IsRequired();
            HasMany(s => s.Provenances);
            HasMany(s => s.Stagiaires);
        }
    }
}