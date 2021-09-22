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
            HasKey(u => u.Id);
            Property(u => u.DateEmp)
                .HasColumnName("DateEmp")
                .IsRequired();
            Property(u => u.DateRet)
                .HasColumnName("DateRet")
                .IsRequired();
            HasRequired(u => u.Materiel)
                 .WithMany(m => m.Utilisers)
                 .HasForeignKey(u => u.CodMat)
                 .WillCascadeOnDelete(true);
            HasRequired(u => u.Stagiaire)
                .WithMany(s => s.Utilisers)
                .HasForeignKey(u => u.IdSta)
                .WillCascadeOnDelete(true);
        }   
    }
}