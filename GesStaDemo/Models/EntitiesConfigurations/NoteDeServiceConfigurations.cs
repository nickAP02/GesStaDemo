using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
  class NoteDeServiceConfigurations : EntityTypeConfiguration<NoteDeService>
  {
    public NoteDeServiceConfigurations()
    {
            ToTable("NoteDeService");
            Property(m => m.CodNotSer)
              .HasColumnName("Code_NotSer")
              .HasColumnType("varchar")
              .HasMaxLength(48)
              .IsRequired();
            Property(m => m.Objet)
               .HasColumnName("Objet")
               .HasColumnType("varchar")
               .HasMaxLength(40)
               .IsRequired();
            Property(m => m.DateSignat)
               .HasColumnName("Date_Signat")
               .HasColumnType("datetime")
               .IsRequired();
            Property(m => m.Duree)
               .HasColumnName("Duree")
               .IsRequired();
            Property(m => m.DateDebut)
               .HasColumnName("Date_Debut")
               .HasColumnType("datetime")
               .IsRequired();
            Property(m => m.Remunerer)
               .HasColumnName("Remunerer")
               .HasColumnType("boolean")
               .IsRequired();
    }
  }
}