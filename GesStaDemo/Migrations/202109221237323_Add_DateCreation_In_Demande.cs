namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_DateCreation_In_Demande : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demande", "DateCreation", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Demande", "DateCreation");
        }
    }
}
