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
            HasKey(n => n.IdNot);
            ToTable("Notation");
            Property(m => m.NotRapp)
              .HasColumnName("Note")
              .HasColumnType("int")
              .IsRequired();
            Property(m => m.ObserEval)
               .HasColumnName("Observation")
               .HasColumnType("varchar")
               .HasMaxLength(40)
               .IsRequired();
            Property(m => m.DateNot)
              .HasColumnName("DateNotation")
              .HasColumnType("date")
              .IsRequired();
            HasRequired(m => m.MaitreDeStage)
                .WithMany(n => n.Notations)
                .HasForeignKey(n => n.CodMS)
                .WillCascadeOnDelete();
            HasRequired(s => s.Stagiaire)
               .WithMany(n => n.Notations)
               .HasForeignKey(s => s.IdSta);
            HasRequired(r => r.Rapport)
                .WithMany(n => n.Notations)
                .HasForeignKey(r => r.CodRapp);
        }
    }
}