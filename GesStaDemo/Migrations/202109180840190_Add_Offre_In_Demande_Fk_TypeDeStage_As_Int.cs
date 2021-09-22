namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Offre_In_Demande_Fk_TypeDeStage_As_Int : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Demande", "TypeDeStage", c => c.Int(nullable: false));
            CreateIndex("dbo.Demande", "TypeDeStage");
            AddForeignKey("dbo.Demande", "TypeDeStage", "dbo.Offre", "OffreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Demande", "TypeDeStage", "dbo.Offre");
            DropIndex("dbo.Demande", new[] { "TypeDeStage" });
            AlterColumn("dbo.Demande", "TypeDeStage", c => c.String());
        }
    }
}
