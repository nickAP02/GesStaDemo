namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_OffreId_In_Demande : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Demande", "Offre_OffreId", "dbo.Offre");
            DropIndex("dbo.Demande", new[] { "Offre_OffreId" });
            RenameColumn(table: "dbo.Demande", name: "Offre_OffreId", newName: "OffreId");
            AlterColumn("dbo.Demande", "OffreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Demande", "OffreId");
            AddForeignKey("dbo.Demande", "OffreId", "dbo.Offre", "OffreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Demande", "OffreId", "dbo.Offre");
            DropIndex("dbo.Demande", new[] { "OffreId" });
            AlterColumn("dbo.Demande", "OffreId", c => c.Int());
            RenameColumn(table: "dbo.Demande", name: "OffreId", newName: "Offre_OffreId");
            CreateIndex("dbo.Demande", "Offre_OffreId");
            AddForeignKey("dbo.Demande", "Offre_OffreId", "dbo.Offre", "OffreId");
        }
    }
}
