namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Type_int_TypeDeStage_to_string : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Demande", "TypeDeStage", "dbo.Offre");
            DropIndex("dbo.Demande", new[] { "TypeDeStage" });
            AddColumn("dbo.Demande", "Offre_OffreId", c => c.Int());
            AlterColumn("dbo.Demande", "TypeDeStage", c => c.String());
            CreateIndex("dbo.Demande", "Offre_OffreId");
            AddForeignKey("dbo.Demande", "Offre_OffreId", "dbo.Offre", "OffreId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Demande", "Offre_OffreId", "dbo.Offre");
            DropIndex("dbo.Demande", new[] { "Offre_OffreId" });
            AlterColumn("dbo.Demande", "TypeDeStage", c => c.Int(nullable: false));
            DropColumn("dbo.Demande", "Offre_OffreId");
            CreateIndex("dbo.Demande", "TypeDeStage");
            AddForeignKey("dbo.Demande", "TypeDeStage", "dbo.Offre", "OffreId", cascadeDelete: true);
        }
    }
}
