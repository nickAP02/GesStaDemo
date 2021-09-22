namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_New_Attr_Stage_Varchar_To_Demande : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demande", "Stage", c => c.String(maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Demande", "Stage");
        }
    }
}
