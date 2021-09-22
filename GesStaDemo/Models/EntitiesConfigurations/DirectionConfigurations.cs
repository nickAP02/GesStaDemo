using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    class DirectionConfigurations : EntityTypeConfiguration<Direction>
    {
        public DirectionConfigurations()
        {
            ToTable("Direction");
            HasKey(d => d.CodDir);
            Property(d => d.CodDir)
                .HasColumnName("CodDir")
                .HasColumnType("varchar")
                .HasMaxLength(5)
                .IsRequired();
            Property(d => d.LibDir)
               .HasColumnName("LibDir")
               .HasColumnType("varchar")
               .HasMaxLength(40)
               .IsRequired();
            Property(d => d.ActDir)
                .HasColumnName("Action")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
            /*HasMany(d => d.Divisions);*/
             
        }
    }
    
}