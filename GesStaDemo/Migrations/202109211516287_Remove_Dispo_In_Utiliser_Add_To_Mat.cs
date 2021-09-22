namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Dispo_In_Utiliser_Add_To_Mat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materiel", "Disponible", c => c.Int(nullable: false));
            DropColumn("dbo.Utiliser", "Disponible");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utiliser", "Disponible", c => c.Boolean(nullable: false));
            DropColumn("dbo.Materiel", "Disponible");
        }
    }
}
