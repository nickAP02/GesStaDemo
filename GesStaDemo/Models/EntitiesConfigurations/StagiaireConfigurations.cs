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
            ToTable("Stagiaire");
            HasKey(k => k.IdSta);
            Property(s=>s.IdSta)
               .HasColumnName("IdSta")
               .IsRequired();
            Property(s => s.NomSta)
               .HasColumnName("Nom")
               .HasColumnType("varchar")
               .HasMaxLength(25)
               .IsRequired();
            Property(s => s.PrenSta)
               .HasColumnName("Prénom")
               .HasColumnType("varchar")
               .HasMaxLength(25)
               .IsRequired();
            Property(s => s.TelSta)
                .HasColumnName("Téléphone")
                .HasColumnType("varchar")
                .HasMaxLength(8)
                .IsRequired();
            Property(s => s.AdrSta)
              .HasColumnName("Email")
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .IsRequired();
            Property(s => s.DebutStage)
                .HasColumnName("DebutStage")
                .HasColumnType("date")
                .IsRequired();
            Property(s => s.FinStage)
              .HasColumnName("FinStage")
               .HasColumnType("date")
              .IsRequired();
            Property(s => s.NbRenouvel)
              .HasColumnName("NbRenouvel")
              .IsRequired();
            Property(s => s.Somm)
              .HasColumnName("Somme")
              .HasColumnType("float")
              .IsRequired();
            Property(s => s.NatSta)
               .HasColumnName("Nationalite")
               .HasColumnType("varchar")
               .HasMaxLength(25)
               .IsRequired();
            Property(s => s.SexSta)
               .HasColumnName("Sexe")
               .HasColumnType("varchar")
               .HasMaxLength(1)
               .IsRequired();
            Property(s => s.DateNaisSta)
              .HasColumnName("DateNaisSta")
              .HasColumnType("date")
              .IsRequired();
            HasRequired(s => s.Provenance)
                .WithMany(s => s.Stagiaires)
                .HasForeignKey(s => s.IdProv);
            //HasMany(s => s.Utilisers);
            HasRequired(u => u.Utilisateur)
                .WithMany(s => s.Stagiaires)
                .HasForeignKey(u => u.UtilId)
                .WillCascadeOnDelete(false);


          
        }
   }
}