using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    public class UtilisateurConfigurations : EntityTypeConfiguration<Utilisateur>
    {
        public UtilisateurConfigurations()
        {
            ToTable("Utilisateur");
            HasKey(u => u.UtilId);
            Property(u => u.Login)
                .HasColumnName("Login")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();
            Property(u => u.Passwd)
                .HasColumnName("Passwd")
                    .HasColumnType("varchar")
                    .HasMaxLength(20)
                    .IsRequired();
            Property(u => u.Photo)
                .HasColumnName("Photo")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();
        }

    }
}