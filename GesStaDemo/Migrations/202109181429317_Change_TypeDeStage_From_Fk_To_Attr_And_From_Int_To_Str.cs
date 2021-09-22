namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_TypeDeStage_From_Fk_To_Attr_And_From_Int_To_Str : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Demande", "TypeDeStage", "dbo.Offre");
            DropIndex("dbo.Demande", new[] { "TypeDeStage" });
            AlterColumn("dbo.Demande", "TypeDeStage", c => c.String(maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Demande", "TypeDeStage", c => c.Int(nullable: false));
            CreateIndex("dbo.Demande", "TypeDeStage");
            AddForeignKey("dbo.Demande", "TypeDeStage", "dbo.Offre", "OffreId", cascadeDelete: true);
        }
    }
}
