namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Offre_In_Demande_Fk_TypeDeStage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Demande", "Stage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Demande", "Stage", c => c.String(maxLength: 30, unicode: false));
        }
    }
}
