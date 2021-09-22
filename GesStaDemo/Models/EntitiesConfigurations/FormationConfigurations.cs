using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    class FormationConfigurations : EntityTypeConfiguration<Formation>
    {
        public FormationConfigurations()
        {
            ToTable("Formation");
            HasKey(f => f.IdFor);
            Property(f => f.DateAffectation)
               .HasColumnName("DateAffectation")
               .HasColumnType("date")
               .IsRequired();
            HasRequired(s => s.Section)
                .WithMany(f => f.Formations)
                .HasForeignKey(s => s.CodSec)
                .WillCascadeOnDelete(false);
            HasRequired(s => s.Stagiaire)
                .WithMany(f => f.Formations)
                .HasForeignKey(s => s.IdSta)
                .WillCascadeOnDelete(false);
        }
    }
}