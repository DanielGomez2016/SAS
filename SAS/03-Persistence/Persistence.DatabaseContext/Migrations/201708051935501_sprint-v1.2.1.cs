namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sprintv121 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requirements", "Id", "dbo.College");
            DropForeignKey("dbo.Validation", "ValidationId", "dbo.College");
            DropIndex("dbo.Requirements", new[] { "Id" });
            DropIndex("dbo.Validation", new[] { "ValidationId" });
            DropPrimaryKey("dbo.Requirements");
            DropPrimaryKey("dbo.Validation");
            AddColumn("dbo.AspNetUsers", "BigFile", c => c.Binary());
            AddColumn("dbo.AspNetUsers", "SmallFile", c => c.Binary());
            AddColumn("dbo.AspNetUsers", "InstitutionId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int());
            AddColumn("dbo.Requirements", "CollegeId", c => c.Int(nullable: false));
            AddColumn("dbo.Validation", "CollegeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Requirements", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Validation", "ValidationId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Requirements", "Id");
            AddPrimaryKey("dbo.Validation", "ValidationId");
            CreateIndex("dbo.AspNetUsers", "InstitutionId");
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            CreateIndex("dbo.Requirements", "CollegeId");
            CreateIndex("dbo.Validation", "CollegeId");
            AddForeignKey("dbo.AspNetUsers", "InstitutionId", "dbo.Institution", "InstitutionId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Department", "DepartmentId");
            AddForeignKey("dbo.Requirements", "CollegeId", "dbo.College", "CollegeId", cascadeDelete: true);
            AddForeignKey("dbo.Validation", "CollegeId", "dbo.College", "CollegeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Validation", "CollegeId", "dbo.College");
            DropForeignKey("dbo.Requirements", "CollegeId", "dbo.College");
            DropForeignKey("dbo.AspNetUsers", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Validation", new[] { "CollegeId" });
            DropIndex("dbo.Requirements", new[] { "CollegeId" });
            DropIndex("dbo.AspNetUsers", new[] { "InstitutionId1" });
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId1" });
            DropPrimaryKey("dbo.Validation");
            DropPrimaryKey("dbo.Requirements");
            AlterColumn("dbo.Validation", "ValidationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Requirements", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Validation", "CollegeId");
            DropColumn("dbo.Requirements", "CollegeId");
            DropColumn("dbo.AspNetUsers", "DepartmentId");
            DropColumn("dbo.AspNetUsers", "InstitutionId");
            DropColumn("dbo.AspNetUsers", "SmallFile");
            DropColumn("dbo.AspNetUsers", "BigFile");
            AddPrimaryKey("dbo.Validation", "ValidationId");
            AddPrimaryKey("dbo.Requirements", "Id");
            CreateIndex("dbo.Validation", "ValidationId");
            CreateIndex("dbo.Requirements", "Id");
            AddForeignKey("dbo.Validation", "ValidationId", "dbo.College", "CollegeId");
            AddForeignKey("dbo.Requirements", "Id", "dbo.College", "CollegeId");
        }
    }
}
