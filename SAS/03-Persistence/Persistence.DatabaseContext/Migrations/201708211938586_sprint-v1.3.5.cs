namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sprintv135 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locality", "code", c => c.String());
            AddColumn("dbo.Locality", "latitude", c => c.String());
            AddColumn("dbo.Locality", "Length", c => c.String());
            AddColumn("dbo.Locality", "Altitude", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locality", "Altitude");
            DropColumn("dbo.Locality", "Length");
            DropColumn("dbo.Locality", "latitude");
            DropColumn("dbo.Locality", "code");
        }
    }
}
