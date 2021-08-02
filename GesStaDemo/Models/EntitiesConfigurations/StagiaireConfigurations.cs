using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
   class StagiaireConfigurations : EntityTypeConfiguration<Stagiaire>
   {
        public StagiaireConfigurations()
        {
            Property(s => s.IdSta)
               .HasColumnName("Id_Sta")
               .IsRequired();
            Property(s => s.NomSta)
               .HasColumnName("Nom_Sta")
               .HasColumnType("varchar")
               .HasMaxLength(25)
               .IsRequired();
            Property(s => s.PrenSta)
               .HasColumnName("Prenom_Sta")
               .HasColumnType("varchar")
               .HasMaxLength(25)
               .IsRequired();
            Property(s => s.TelSta)
                .HasColumnName("Telephone_Sta")
                .HasColumnType("varchar")
                .HasMaxLength(7)
                .IsRequired();
            Property(s => s.AdrSta)
              .HasColumnName("Adresse_Sta")
              .HasColumnType("varchar")
              .HasMaxLength(100)
              .IsRequired();
            Property(s => s.FinStage)
              .HasColumnName("Prenom_Sta")
              .IsRequired();
            Property(s => s.NbRenouvel)
              .HasColumnName("Nb_Renouvel")
              .IsRequired();
            Property(s => s.Somm)
              .HasColumnName("Somme")
              .IsRequired();
            Property(s => s.NatSta)
               .HasColumnName("Nationalite_Sta")
               .HasColumnType("varchar")
               .HasMaxLength(25)
               .IsRequired();
            Property(s => s.SexSta)
               .HasColumnName("Sexe_Sta")
               .HasColumnType("char")
               .IsRequired();
            Property(s => s.DateNaisSta)
              .HasColumnName("DateNais_Sta")
              .IsRequired();
            HasMany(s => s.Notations);
            HasMany(s => s.Themes);
            HasMany(s => s.Formations);
            HasMany(s => s.NoteDeServices);
            HasMany(s => s.Remunerations);
        }
   }
}