namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class strpintv132 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SystemAccess", "ActionController", c => c.String(nullable: false, maxLength: 75));
            AddColumn("dbo.SystemAccess", "DescriptionAccess", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.SystemAccess", "Action");
            DropColumn("dbo.SystemAccess", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SystemAccess", "Description", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.SystemAccess", "Action", c => c.String(nullable: false, maxLength: 75));
            DropColumn("dbo.SystemAccess", "DescriptionAccess");
            DropColumn("dbo.SystemAccess", "ActionController");
        }
    }
}
