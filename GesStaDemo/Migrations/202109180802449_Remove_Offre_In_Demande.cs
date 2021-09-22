namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Offre_In_Demande : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Demande", "OffreId", "dbo.Offre");
            DropIndex("dbo.Demande", new[] { "OffreId" });
            DropColumn("dbo.Demande", "OffreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Demande", "OffreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Demande", "OffreId");
            AddForeignKey("dbo.Demande", "OffreId", "dbo.Offre", "OffreId", cascadeDelete: true);
        }
    }
}
