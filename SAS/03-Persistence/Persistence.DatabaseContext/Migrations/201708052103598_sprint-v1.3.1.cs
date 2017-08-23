namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class sprintv131 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Department");
            DropIndex("dbo.AspNetUsers", new[] { "InstitutionId" });
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        BigFile = c.Binary(),
                        SmallFile = c.Binary(),
                        InstitutionId = c.Int(),
                        DepartmentId = c.Int(),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Member_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Institution", t => t.InstitutionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.InstitutionId)
                .Index(t => t.DepartmentId)
                .Index(t => t.UserId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "BigFile");
            DropColumn("dbo.AspNetUsers", "SmallFile");
            DropColumn("dbo.AspNetUsers", "InstitutionId");
            DropColumn("dbo.AspNetUsers", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Institution_InstitutionId1", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Department_DepartmentId1", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Department_DepartmentId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Institution_InstitutionId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "InstitutionId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "SmallFile", c => c.Binary());
            AddColumn("dbo.AspNetUsers", "BigFile", c => c.Binary());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropForeignKey("dbo.Member", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Member", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Member", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.Member", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Member", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Member", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Member", new[] { "DeletedBy" });
            DropIndex("dbo.Member", new[] { "UpdatedBy" });
            DropIndex("dbo.Member", new[] { "CreatedBy" });
            DropIndex("dbo.Member", new[] { "UserId" });
            DropIndex("dbo.Member", new[] { "DepartmentId" });
            DropIndex("dbo.Member", new[] { "InstitutionId" });
            DropTable("dbo.Member",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Member_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            CreateIndex("dbo.AspNetUsers", "Institution_InstitutionId1");
            CreateIndex("dbo.AspNetUsers", "Department_DepartmentId1");
            CreateIndex("dbo.AspNetUsers", "Department_DepartmentId");
            CreateIndex("dbo.AspNetUsers", "Institution_InstitutionId");
            AddForeignKey("dbo.AspNetUsers", "Institution_InstitutionId1", "dbo.Institution", "InstitutionId");
            AddForeignKey("dbo.AspNetUsers", "Department_DepartmentId1", "dbo.Department", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "Department_DepartmentId", "dbo.Department", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "Institution_InstitutionId", "dbo.Institution", "InstitutionId");
        }
    }
}
