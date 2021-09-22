using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    internal class OffreConfigurations : EntityTypeConfiguration<Offre>
    {
        public OffreConfigurations()
        {
            ToTable("Offre");
            HasKey(o => o.OffreId);
            Property(o => o.LibOffre)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(30);
            Property(o => o.DebutStage)
                .HasColumnType("date")
                .IsRequired();
            Property(o => o.FinStage)
                .HasColumnType("date")
                .IsRequired();
            Property(o => o.Remunerer)
                .HasColumnType("bit");
        }
    }
}