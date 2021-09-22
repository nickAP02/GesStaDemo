using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
   class ThemeConfigurations : EntityTypeConfiguration<Theme>
   {
        public ThemeConfigurations()
        {
            ToTable("Theme");
            HasKey(t => t.IdThe);
              Property(t => t.DateTheme)
                  .HasColumnName("DateTheme")
                  .HasColumnType("date")
                  .IsRequired();
              Property(t => t.LibTheme)
                  .HasColumnName("LibTheme")
                  .HasColumnType("varchar")
                  .HasMaxLength(50)
                  .IsRequired();
              Property(t => t.Objectifs)
                  .HasColumnName("Objectifs")
                  .HasColumnType("varchar")
                  .HasMaxLength(150)
                  .IsRequired();
            HasRequired(t => t.MaitreDeStage)
                .WithMany(m => m.Themes)
                .HasForeignKey(t => t.CodMS)
                .WillCascadeOnDelete(true);
            HasRequired(t => t.Stagiaire)
                .WithMany(s => s.Themes)
                .HasForeignKey(t => t.IdSta)
                .WillCascadeOnDelete(true);

        }
   }
}