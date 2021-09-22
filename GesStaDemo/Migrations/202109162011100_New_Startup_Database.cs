namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_Startup_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvoirPour",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateSup = c.DateTime(nullable: false, storeType: "date"),
                        AvoirPourSup = c.Int(nullable: false),
                        AvoirPourSta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stagiaire", t => t.AvoirPourSup)
                .ForeignKey("dbo.Superviseur", t => t.AvoirPourSta)
                .Index(t => t.AvoirPourSup)
                .Index(t => t.AvoirPourSta);
            
            CreateTable(
                "dbo.Stagiaire",
                c => new
                    {
                        IdSta = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 25, unicode: false),
                        Prénom = c.String(nullable: false, maxLength: 25, unicode: false),
                        Téléphone = c.String(nullable: false, maxLength: 8, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        DebutStage = c.DateTime(nullable: false, storeType: "date"),
                        FinStage = c.DateTime(nullable: false, storeType: "date"),
                        NbRenouvel = c.Int(nullable: false),
                        Somme = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Nationalite = c.String(nullable: false, maxLength: 25, unicode: false),
                        Sexe = c.String(nullable: false, maxLength: 1, unicode: false),
                        DateNaisSta = c.DateTime(nullable: false, storeType: "date"),
                        CodRem = c.String(),
                        IdProv = c.Int(nullable: false),
                        UtilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSta)
                .ForeignKey("dbo.Provenance", t => t.IdProv, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateur", t => t.UtilId)
                .Index(t => t.IdProv)
                .Index(t => t.UtilId);
            
            CreateTable(
                "dbo.Formation",
                c => new
                    {
                        IdFor = c.Int(nullable: false, identity: true),
                        DateAffectation = c.DateTime(nullable: false, storeType: "date"),
                        IdSta = c.Int(nullable: false),
                        CodSec = c.String(nullable: false, maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.IdFor)
                .ForeignKey("dbo.Section", t => t.CodSec)
                .ForeignKey("dbo.Stagiaire", t => t.IdSta)
                .Index(t => t.IdSta)
                .Index(t => t.CodSec);
            
            CreateTable(
                "dbo.Section",
                c => new
                    {
                        CodSec = c.String(nullable: false, maxLength: 5, unicode: false),
                        Libelledesection = c.String(name: "Libelle de section", nullable: false, maxLength: 40, unicode: false),
                        Action = c.String(nullable: false, maxLength: 150, unicode: false),
                        CodDiv = c.String(nullable: false, maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.CodSec)
                .ForeignKey("dbo.Division", t => t.CodDiv, cascadeDelete: true)
                .Index(t => t.CodDiv);
            
            CreateTable(
                "dbo.Division",
                c => new
                    {
                        CodDiv = c.String(nullable: false, maxLength: 5, unicode: false),
                        LibDiv = c.String(nullable: false, maxLength: 150, unicode: false),
                        Action = c.String(nullable: false, maxLength: 150, unicode: false),
                        CodDir = c.String(nullable: false, maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.CodDiv)
                .ForeignKey("dbo.Direction", t => t.CodDir, cascadeDelete: true)
                .Index(t => t.CodDir);
            
            CreateTable(
                "dbo.Direction",
                c => new
                    {
                        CodDir = c.String(nullable: false, maxLength: 5, unicode: false),
                        LibDir = c.String(nullable: false, maxLength: 40, unicode: false),
                        Action = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.CodDir);
            
            CreateTable(
                "dbo.MaitreDeStage",
                c => new
                    {
                        CodMS = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 25, unicode: false),
                        Prenom = c.String(nullable: false, maxLength: 25, unicode: false),
                        Telephone = c.String(nullable: false, maxLength: 8, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Fonction = c.String(nullable: false, maxLength: 50, unicode: false),
                        CodSec = c.String(nullable: false, maxLength: 5, unicode: false),
                        UtilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodMS)
                .ForeignKey("dbo.Section", t => t.CodSec)
                .ForeignKey("dbo.Utilisateur", t => t.UtilId)
                .Index(t => t.CodSec)
                .Index(t => t.UtilId);
            
            CreateTable(
                "dbo.Notation",
                c => new
                    {
                        IdNot = c.Int(nullable: false, identity: true),
                        Note = c.Int(nullable: false),
                        Observation = c.String(nullable: false, maxLength: 40, unicode: false),
                        DateNotation = c.DateTime(nullable: false, storeType: "date"),
                        IdSta = c.Int(nullable: false),
                        CodMS = c.Int(nullable: false),
                        CodRapp = c.String(nullable: false, maxLength: 18, unicode: false),
                    })
                .PrimaryKey(t => t.IdNot)
                .ForeignKey("dbo.MaitreDeStage", t => t.CodMS, cascadeDelete: true)
                .ForeignKey("dbo.Rapport", t => t.CodRapp, cascadeDelete: true)
                .ForeignKey("dbo.Stagiaire", t => t.IdSta, cascadeDelete: true)
                .Index(t => t.IdSta)
                .Index(t => t.CodMS)
                .Index(t => t.CodRapp);
            
            CreateTable(
                "dbo.Rapport",
                c => new
                    {
                        CodRapp = c.String(nullable: false, maxLength: 18, unicode: false),
                        NomRapp = c.String(nullable: false, maxLength: 40, unicode: false),
                        Taches = c.String(nullable: false, maxLength: 150, unicode: false),
                        DatePresentat = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CodRapp);
            
            CreateTable(
                "dbo.Theme",
                c => new
                    {
                        IdThe = c.Int(nullable: false, identity: true),
                        DateTheme = c.DateTime(nullable: false, storeType: "date"),
                        LibTheme = c.String(nullable: false, maxLength: 50, unicode: false),
                        Objectifs = c.String(nullable: false, maxLength: 150, unicode: false),
                        CodMS = c.Int(nullable: false),
                        IdSta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdThe)
                .ForeignKey("dbo.MaitreDeStage", t => t.CodMS, cascadeDelete: true)
                .ForeignKey("dbo.Stagiaire", t => t.IdSta, cascadeDelete: true)
                .Index(t => t.CodMS)
                .Index(t => t.IdSta);
            
            CreateTable(
                "dbo.Utilisateur",
                c => new
                    {
                        UtilId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 20, unicode: false),
                        Passwd = c.String(nullable: false, maxLength: 20, unicode: false),
                        Photo = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.UtilId);
            
            CreateTable(
                "dbo.Droit",
                c => new
                    {
                        DroitId = c.Int(nullable: false, identity: true),
                        UtilId = c.Int(nullable: false),
                        ProfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DroitId)
                .ForeignKey("dbo.Profil", t => t.ProfilId, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateur", t => t.UtilId, cascadeDelete: true)
                .Index(t => t.UtilId)
                .Index(t => t.ProfilId);
            
            CreateTable(
                "dbo.Profil",
                c => new
                    {
                        ProfilId = c.Int(nullable: false, identity: true),
                        LibProfil = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ProfilId);
            
            CreateTable(
                "dbo.Superviseur",
                c => new
                    {
                        IdSup = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 25, unicode: false),
                        Prenom = c.String(nullable: false, maxLength: 25, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Telephone = c.String(nullable: false, maxLength: 8, unicode: false),
                        UtilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSup)
                .ForeignKey("dbo.Utilisateur", t => t.UtilId)
                .Index(t => t.UtilId);
            
            CreateTable(
                "dbo.Provenance",
                c => new
                    {
                        IdProv = c.Int(nullable: false, identity: true),
                        LibProv = c.String(nullable: false, maxLength: 30, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        VilleProv = c.String(nullable: false, maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => t.IdProv);
            
            CreateTable(
                "dbo.SortirDe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatePro = c.DateTime(nullable: false),
                        NivoEtude = c.String(nullable: false, maxLength: 15),
                        IdSta = c.Int(nullable: false),
                        IdProv = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provenance", t => t.IdProv)
                .ForeignKey("dbo.Stagiaire", t => t.IdSta)
                .Index(t => t.IdSta)
                .Index(t => t.IdProv);
            
            CreateTable(
                "dbo.Remuneration",
                c => new
                    {
                        CodRem = c.String(nullable: false, maxLength: 10, unicode: false),
                        RegleMens = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateRemiz = c.DateTime(nullable: false, storeType: "date"),
                        IdSta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodRem)
                .ForeignKey("dbo.Stagiaire", t => t.IdSta, cascadeDelete: true)
                .Index(t => t.IdSta);
            
            CreateTable(
                "dbo.Utiliser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateEmp = c.DateTime(nullable: false),
                        DateRet = c.DateTime(nullable: false),
                        IdSta = c.Int(nullable: false),
                        CodMat = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materiel", t => t.CodMat, cascadeDelete: true)
                .ForeignKey("dbo.Stagiaire", t => t.IdSta, cascadeDelete: true)
                .Index(t => t.IdSta)
                .Index(t => t.CodMat);
            
            CreateTable(
                "dbo.Materiel",
                c => new
                    {
                        CodMat = c.String(nullable: false, maxLength: 10, unicode: false),
                        LibMat = c.String(nullable: false, maxLength: 25, unicode: false),
                        QuantMat = c.Int(nullable: false),
                        Caracteristik = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CodMat);
            
            CreateTable(
                "dbo.Demande",
                c => new
                    {
                        IdDem = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 25, unicode: false),
                        Prenom = c.String(nullable: false, maxLength: 25, unicode: false),
                        Sexe = c.String(nullable: false, maxLength: 1, unicode: false),
                        DateNaissance = c.DateTime(nullable: false, storeType: "date"),
                        Nationalite = c.String(nullable: false, maxLength: 15),
                        Telephone = c.String(nullable: false, maxLength: 8, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        TypeDeStage = c.Int(nullable: false),
                        Curriculum = c.String(nullable: false),
                        Accepter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDem)
                .ForeignKey("dbo.Offre", t => t.TypeDeStage, cascadeDelete: true)
                .Index(t => t.TypeDeStage);
            
            CreateTable(
                "dbo.Offre",
                c => new
                    {
                        OffreId = c.Int(nullable: false, identity: true),
                        LibOffre = c.String(nullable: false, maxLength: 30, unicode: false),
                        DebutStage = c.DateTime(nullable: false, storeType: "date"),
                        FinStage = c.DateTime(nullable: false, storeType: "date"),
                        Remunerer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OffreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Demande", "TypeDeStage", "dbo.Offre");
            DropForeignKey("dbo.AvoirPour", "AvoirPourSta", "dbo.Superviseur");
            DropForeignKey("dbo.AvoirPour", "AvoirPourSup", "dbo.Stagiaire");
            DropForeignKey("dbo.Utiliser", "IdSta", "dbo.Stagiaire");
            DropForeignKey("dbo.Utiliser", "CodMat", "dbo.Materiel");
            DropForeignKey("dbo.Stagiaire", "UtilId", "dbo.Utilisateur");
            DropForeignKey("dbo.Remuneration", "IdSta", "dbo.Stagiaire");
            DropForeignKey("dbo.Stagiaire", "IdProv", "dbo.Provenance");
            DropForeignKey("dbo.SortirDe", "IdSta", "dbo.Stagiaire");
            DropForeignKey("dbo.SortirDe", "IdProv", "dbo.Provenance");
            DropForeignKey("dbo.Formation", "IdSta", "dbo.Stagiaire");
            DropForeignKey("dbo.Formation", "CodSec", "dbo.Section");
            DropForeignKey("dbo.MaitreDeStage", "UtilId", "dbo.Utilisateur");
            DropForeignKey("dbo.Superviseur", "UtilId", "dbo.Utilisateur");
            DropForeignKey("dbo.Droit", "UtilId", "dbo.Utilisateur");
            DropForeignKey("dbo.Droit", "ProfilId", "dbo.Profil");
            DropForeignKey("dbo.Theme", "IdSta", "dbo.Stagiaire");
            DropForeignKey("dbo.Theme", "CodMS", "dbo.MaitreDeStage");
            DropForeignKey("dbo.MaitreDeStage", "CodSec", "dbo.Section");
            DropForeignKey("dbo.Notation", "IdSta", "dbo.Stagiaire");
            DropForeignKey("dbo.Notation", "CodRapp", "dbo.Rapport");
            DropForeignKey("dbo.Notation", "CodMS", "dbo.MaitreDeStage");
            DropForeignKey("dbo.Section", "CodDiv", "dbo.Division");
            DropForeignKey("dbo.Division", "CodDir", "dbo.Direction");
            DropIndex("dbo.Demande", new[] { "TypeDeStage" });
            DropIndex("dbo.Utiliser", new[] { "CodMat" });
            DropIndex("dbo.Utiliser", new[] { "IdSta" });
            DropIndex("dbo.Remuneration", new[] { "IdSta" });
            DropIndex("dbo.SortirDe", new[] { "IdProv" });
            DropIndex("dbo.SortirDe", new[] { "IdSta" });
            DropIndex("dbo.Superviseur", new[] { "UtilId" });
            DropIndex("dbo.Droit", new[] { "ProfilId" });
            DropIndex("dbo.Droit", new[] { "UtilId" });
            DropIndex("dbo.Theme", new[] { "IdSta" });
            DropIndex("dbo.Theme", new[] { "CodMS" });
            DropIndex("dbo.Notation", new[] { "CodRapp" });
            DropIndex("dbo.Notation", new[] { "CodMS" });
            DropIndex("dbo.Notation", new[] { "IdSta" });
            DropIndex("dbo.MaitreDeStage", new[] { "UtilId" });
            DropIndex("dbo.MaitreDeStage", new[] { "CodSec" });
            DropIndex("dbo.Division", new[] { "CodDir" });
            DropIndex("dbo.Section", new[] { "CodDiv" });
            DropIndex("dbo.Formation", new[] { "CodSec" });
            DropIndex("dbo.Formation", new[] { "IdSta" });
            DropIndex("dbo.Stagiaire", new[] { "UtilId" });
            DropIndex("dbo.Stagiaire", new[] { "IdProv" });
            DropIndex("dbo.AvoirPour", new[] { "AvoirPourSta" });
            DropIndex("dbo.AvoirPour", new[] { "AvoirPourSup" });
            DropTable("dbo.Offre");
            DropTable("dbo.Demande");
            DropTable("dbo.Materiel");
            DropTable("dbo.Utiliser");
            DropTable("dbo.Remuneration");
            DropTable("dbo.SortirDe");
            DropTable("dbo.Provenance");
            DropTable("dbo.Superviseur");
            DropTable("dbo.Profil");
            DropTable("dbo.Droit");
            DropTable("dbo.Utilisateur");
            DropTable("dbo.Theme");
            DropTable("dbo.Rapport");
            DropTable("dbo.Notation");
            DropTable("dbo.MaitreDeStage");
            DropTable("dbo.Direction");
            DropTable("dbo.Division");
            DropTable("dbo.Section");
            DropTable("dbo.Formation");
            DropTable("dbo.Stagiaire");
            DropTable("dbo.AvoirPour");
        }
    }
}
