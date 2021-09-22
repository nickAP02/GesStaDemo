using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
   class MaitreDeStageConfigurations : EntityTypeConfiguration<MaitreDeStage>
    {
        public MaitreDeStageConfigurations()
        {
            ToTable("MaitreDeStage");
            HasKey(m => m.CodMS);
            Property(m => m.CodMS)
                .HasColumnName("CodMS")
                .IsRequired();
            Property(m => m.NomMS)
                .HasColumnName("Nom")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            Property(m => m.PrenMS)
                .HasColumnName("Prenom")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            Property(m => m.TelMS)
                .HasColumnName("Telephone")
                .HasColumnType("varchar")
                .HasMaxLength(8)
                .IsRequired();
            Property(m => m.AdrMS)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            Property(m => m.Fonction)
                .HasColumnName("Fonction")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            HasRequired(s => s.Section)
                .WithMany(m => m.MaitreDeStages)
                .HasForeignKey(s => s.CodSec)
                .WillCascadeOnDelete(false);
            /*HasRequired(n => n.Notation)
                .WithMany(m => m.MaitreDeStages)
                .HasForeignKey(n => n.IdNot)
                 .WillCascadeOnDelete(false);*/
            HasRequired(u => u.Utilisateur)
                .WithMany(m => m.MaitreDeStages)
                .HasForeignKey(u => u.UtilId)
                .WillCascadeOnDelete(false);
        }
    }
}