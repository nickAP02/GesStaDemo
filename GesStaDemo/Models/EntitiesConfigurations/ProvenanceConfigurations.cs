using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
   class ProvenanceConfigurations : EntityTypeConfiguration<Provenance>
   {
       public ProvenanceConfigurations()
       {
            ToTable("Provenance");
            HasKey(p => p.IdProv);
            Property(p => p.LibProv)
                .HasColumnName("LibProv")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();
            Property(p => p.AdrProv)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            Property(p => p.VilleProv)
                .HasColumnName("VilleProv")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            /*HasRequired(p => p.SortirDe)
                .WithMany(s => s.Provenances)
                .HasForeignKey(s => s.IdSta);*/
        }
   }
}