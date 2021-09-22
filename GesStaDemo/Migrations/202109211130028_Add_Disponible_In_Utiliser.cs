namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Disponible_In_Utiliser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utiliser", "Disponible", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utiliser", "Disponible");
        }
    }
}
