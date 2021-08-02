using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    class UtiliserConfigurations : EntityTypeConfiguration<Utiliser>
    {
        public UtiliserConfigurations()
        {
            ToTable("Utiliser");
            Property(u => u.DateEmp)
                .HasColumnName("Date_Emprunt")
                .IsRequired();
            Property(u => u.DateRet)
                .HasColumnName("Date_Retrait")
                .IsRequired();
            HasMany(u => u.Materiels);
            HasMany(u => u.Stagiaires);

        }   
    }
}