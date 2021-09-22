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
                .HasColumnName("DatePro")
                .IsRequired();
            Property(s => s.NivoEtude)
                .HasColumnName("NivoEtude")
                .HasMaxLength(15)
                .IsRequired();
            HasRequired(s => s.Provenance)
                .WithMany(p => p.SortirDes)
                .HasForeignKey(s => s.IdProv)
                .WillCascadeOnDelete(false);
            HasRequired(s => s.Stagiaire)
                .WithMany(s => s.SortirDes)
                .HasForeignKey(s => s.IdSta)
                .WillCascadeOnDelete(false);
        }
    }
}