using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
     class DemandeConfigurations : EntityTypeConfiguration<Demande>
     {
         public DemandeConfigurations()
         {
            Property(p => p.Nom)
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            Property(p => p.Prenom)
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            Property(p => p.Email)
                .HasMaxLength(50)
                .IsRequired();
            Property(p => p.Telephone)
                 .HasColumnType("varchar")
                  .HasMaxLength(8)
                  .IsRequired();
            Property(p => p.Nationalite)
                .HasMaxLength(15)
                .IsRequired();
            Property(p => p.DateNaissance)
                .HasColumnType("date");
            Property(p => p.Sexe)
                 .HasColumnType("varchar")
                 .HasMaxLength(1);
            Property(p => p.Accepter)
                .HasColumnType("int");
            Property(p => p.DateCreation)
                .HasColumnType("date");
            HasRequired(d => d.Offre)
                .WithMany(o => o.Demandes)
                .HasForeignKey(d => d.TypeDeStage);
        }
     }
}