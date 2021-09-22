namespace GesStaDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Somm_Type_Decimal_To_Double : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stagiaire", "Somme", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stagiaire", "Somme", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
