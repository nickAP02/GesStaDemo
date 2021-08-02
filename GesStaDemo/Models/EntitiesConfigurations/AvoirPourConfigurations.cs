using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    public class AvoirPourConfigurations : EntityTypeConfiguration<AvoirPour>
    {
        public AvoirPourConfigurations()
        {
            ToTable("AvoirPour");
            Property(a => a.DateSup)
                .HasColumnName("Date_Sup")
                .HasColumnType("datetime")
                .IsRequired();
            HasMany(a => a.Stagiaires);
            HasMany(a => a.Superviseurs);
        }
    }
}