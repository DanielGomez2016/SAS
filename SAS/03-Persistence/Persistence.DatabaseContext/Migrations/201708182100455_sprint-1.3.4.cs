namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sprint134 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SystemAccessRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.SystemAccessRoles", new[] { "RoleId" });
            DropPrimaryKey("dbo.SystemAccessRoles");
            AlterColumn("dbo.SystemAccessRoles", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.SystemAccessRoles", new[] { "Id", "InstitutionId", "RoleId" });
            CreateIndex("dbo.SystemAccessRoles", "RoleId");
            AddForeignKey("dbo.SystemAccessRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemAccessRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.SystemAccessRoles", new[] { "RoleId" });
            DropPrimaryKey("dbo.SystemAccessRoles");
            AlterColumn("dbo.SystemAccessRoles", "RoleId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.SystemAccessRoles", new[] { "Id", "InstitutionId" });
            CreateIndex("dbo.SystemAccessRoles", "RoleId");
            AddForeignKey("dbo.SystemAccessRoles", "RoleId", "dbo.AspNetRoles", "Id");
        }
    }
}
