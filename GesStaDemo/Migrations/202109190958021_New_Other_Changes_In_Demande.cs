namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_Other_Changes_In_Demande : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Demande", "Offre_OffreId", "dbo.Offre");
            DropIndex("dbo.Demande", new[] { "Offre_OffreId" });
            DropColumn("dbo.Demande", "TypeDeStage");
            RenameColumn(table: "dbo.Demande", name: "Offre_OffreId", newName: "TypeDeStage");
            AlterColumn("dbo.Demande", "TypeDeStage", c => c.Int(nullable: false));
            AlterColumn("dbo.Demande", "TypeDeStage", c => c.Int(nullable: false));
            CreateIndex("dbo.Demande", "TypeDeStage");
            AddForeignKey("dbo.Demande", "TypeDeStage", "dbo.Offre", "OffreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Demande", "TypeDeStage", "dbo.Offre");
            DropIndex("dbo.Demande", new[] { "TypeDeStage" });
            AlterColumn("dbo.Demande", "TypeDeStage", c => c.Int());
            AlterColumn("dbo.Demande", "TypeDeStage", c => c.String());
            RenameColumn(table: "dbo.Demande", name: "TypeDeStage", newName: "Offre_OffreId");
            AddColumn("dbo.Demande", "TypeDeStage", c => c.String());
            CreateIndex("dbo.Demande", "Offre_OffreId");
            AddForeignKey("dbo.Demande", "Offre_OffreId", "dbo.Offre", "OffreId");
        }
    }
}
