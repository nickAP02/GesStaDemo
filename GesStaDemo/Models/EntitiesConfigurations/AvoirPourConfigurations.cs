using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    public class AvoirPourConfigurations : EntityTypeConfiguration<AvoirPour>
    {
        public AvoirPourConfigurations()
        {
            
            ToTable("AvoirPour");
            HasKey(a => a.Id);
            Property(a => a.DateSup)
                .HasColumnName("DateSup")
                .HasColumnType("date")
                .IsRequired();
            HasRequired(s => s.Stagiaire)
                .WithMany(a => a.AvoirPours)
                .HasForeignKey(s => s.AvoirPourSup)
                .WillCascadeOnDelete(false);
            HasRequired(s => s.Superviseur)
                .WithMany(a => a.AvoirPours)
                .HasForeignKey(s => s.AvoirPourSta)
                .WillCascadeOnDelete(false);


        }
    }
}