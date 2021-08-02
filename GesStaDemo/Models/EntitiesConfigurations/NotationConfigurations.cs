using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    class NotationConfigurations : EntityTypeConfiguration<Notation>
    {
        public NotationConfigurations()
        {
            Property(m => m.NotRapp)
              .HasColumnName("Note")
              .IsRequired();
            Property(m => m.ObserEval)
               .HasColumnName("Observation")
               .HasColumnType("varchar")
               .HasMaxLength(40)
               .IsRequired();
            Property(m => m.DateNot)
              .HasColumnName("Date_Notation")
              .IsRequired();
            HasMany(m => m.MaitreDeStages);
            HasMany(m => m.Rapports);
            HasMany(m => m.Stagiaires);
        }
    }
}