namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes_In_Demande : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Demande", "TypeDeStage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Demande", "TypeDeStage", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
    }
}
