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
            Property(p => p.IdProv)
                .HasColumnName("Id_Prov")
                .IsRequired();
            Property(p => p.LibProv)
                .HasColumnName("Libelle_Prov")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();
            Property(p => p.AdrProv)
                .HasColumnName("Adresse_Prov")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            Property(p => p.VilleProv)
                .HasColumnName("Ville_Prov")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            HasMany(p => p.Stagiaires);
        }
   }
}