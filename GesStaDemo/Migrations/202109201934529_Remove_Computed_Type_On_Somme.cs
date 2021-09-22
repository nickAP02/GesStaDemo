namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Computed_Type_On_Somme : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stagiaire", "Somme", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stagiaire", "Somme", c => c.Double(nullable: false));
        }
    }
}
