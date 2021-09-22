using GesStaDemo.Models;
using GesStaDemo.Models.Entities;
using GesStaDemo.Models.EntitiesConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GesStaDemo
{
    public class GesStaDbContext : DbContext
    {
        public GesStaDbContext() : base("name=GesStaDbContext")
        {

        }
        public virtual DbSet<AvoirPour> AvoirPours { get; set; }
        public virtual DbSet<Droit> Droits { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<Formation> Formations { get; set; }
        public virtual DbSet<MaitreDeStage> MaitreDeStages { get; set; }
        public virtual DbSet<Materiel> Materiels { get; set; }
        public virtual DbSet<Notation> Notations { get; set; }
        public virtual DbSet<Provenance> Provenances { get; set; }
        public virtual DbSet<Rapport> Rapports { get; set; }
        public virtual DbSet<Remuneration> Remunerations { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Stagiaire> Stagiaires { get; set; }
        public virtual DbSet<Superviseur> Superviseurs { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Profil> Profils { get; set; }
        public virtual DbSet<Demande> Demandes { get; set; }
        public virtual DbSet<Offre> Offres { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AvoirPourConfigurations());
            modelBuilder.Configurations.Add(new DirectionConfigurations());
            modelBuilder.Configurations.Add(new DivisionConfigurations());
            modelBuilder.Configurations.Add(new DroitConfigurations());
            modelBuilder.Configurations.Add(new FormationConfigurations());
            modelBuilder.Configurations.Add(new MaitreDeStageConfigurations());
            modelBuilder.Configurations.Add(new MaterielConfigurations());
            modelBuilder.Configurations.Add(new NotationConfigurations());
            modelBuilder.Configurations.Add(new DemandeConfigurations());
            modelBuilder.Configurations.Add(new OffreConfigurations());
            modelBuilder.Configurations.Add(new ProvenanceConfigurations());
            modelBuilder.Configurations.Add(new RapportConfigurations());
            modelBuilder.Configurations.Add(new RemunerationConfigurations());
            modelBuilder.Configurations.Add(new SectionConfigurations());
            modelBuilder.Configurations.Add(new SortirDeConfigurations());
            modelBuilder.Configurations.Add(new StagiaireConfigurations());
            modelBuilder.Configurations.Add(new SuperviseurConfigurations());
            modelBuilder.Configurations.Add(new UtiliserConfigurations());
            modelBuilder.Configurations.Add(new UtilisateurConfigurations());
            modelBuilder.Configurations.Add(new ThemeConfigurations());
        }

        public System.Data.Entity.DbSet<GesStaDemo.Models.Entities.SortirDe> SortirDes { get; set; }

        public System.Data.Entity.DbSet<GesStaDemo.Models.Entities.Utiliser> Utilisers { get; set; }
    }
}