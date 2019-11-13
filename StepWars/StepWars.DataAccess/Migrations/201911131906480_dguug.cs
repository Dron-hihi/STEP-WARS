namespace StepWars.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dguug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StarShips", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StarShips", "Image");
        }
    }
}
