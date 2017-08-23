namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sprint133 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SystemAccessRoles", "Access", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SystemAccessRoles", "Access");
        }
    }
}
