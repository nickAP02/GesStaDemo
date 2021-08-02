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
            Property(f => f.DateAffectation)
               .HasColumnName("Date_affectation")
               .HasColumnType("datetime")
               .IsRequired();
            HasMany(f => f.Sections);
            HasMany(f => f.Stagiaires);
        }
    }
}