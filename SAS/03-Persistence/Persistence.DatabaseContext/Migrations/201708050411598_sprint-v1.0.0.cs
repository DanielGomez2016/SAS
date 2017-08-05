namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sprintv100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beneficiary",
                c => new
                    {
                        BeneficiaryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        address = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.BeneficiaryId);
            
            CreateTable(
                "dbo.College",
                c => new
                    {
                        CollegeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Code = c.String(nullable: false, maxLength: 25),
                        Address = c.String(nullable: false, maxLength: 100),
                        Turn = c.Int(nullable: false),
                        Geox = c.String(),
                        Geoy = c.String(),
                        Status = c.Int(nullable: false),
                        Postcode = c.Int(),
                        Colony = c.String(maxLength: 100),
                        Marginalization = c.String(maxLength: 100),
                        Population = c.String(maxLength: 100),
                        Zone = c.Int(),
                    })
                .PrimaryKey(t => t.CollegeId);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        CelPhone = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Manager = c.String(nullable: false, maxLength: 75),
                        Description = c.String(unicode: false, storeType: "text"),
                        Extension = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.DetailRecord",
                c => new
                    {
                        DetailRecordId = c.Int(nullable: false, identity: true),
                        RecordDate = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false, unicode: false, storeType: "text"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetailRecordId);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 50),
                        File = c.Binary(nullable: false, maxLength: 8000),
                    })
                .PrimaryKey(t => t.DocumentId);
            
            CreateTable(
                "dbo.EducationLevel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Institution",
                c => new
                    {
                        InstitutionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Acronym = c.String(nullable: false, maxLength: 15),
                        Manager = c.String(nullable: false, maxLength: 150),
                        Description = c.String(unicode: false, storeType: "text"),
                        Phone = c.String(nullable: false, maxLength: 15),
                        extension = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.InstitutionId);
            
            CreateTable(
                "dbo.Locality",
                c => new
                    {
                        LocalityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.LocalityId);
            
            CreateTable(
                "dbo.Provenance",
                c => new
                    {
                        ProvenanceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.ProvenanceId);
            
            CreateTable(
                "dbo.Record",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        Validation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId);
            
            CreateTable(
                "dbo.Requirements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Solicitude",
                c => new
                    {
                        SolicitudeId = c.Int(nullable: false, identity: true),
                        Folio = c.String(nullable: false, maxLength: 50),
                        DeliverDate = c.DateTime(nullable: false),
                        Affair = c.String(nullable: false, unicode: false, storeType: "text"),
                        GeneralGoal = c.String(unicode: false, storeType: "text"),
                        ValidationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SolicitudeId);
            
            CreateTable(
                "dbo.SystemAccess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Controller = c.String(nullable: false, maxLength: 75),
                        Action = c.String(nullable: false, maxLength: 75),
                        Description = c.String(nullable: false, maxLength: 250),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemAccessRoles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        InstitutionId = c.Int(nullable: false),
                        RoleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Id, t.InstitutionId, t.RoleId })
                .ForeignKey("dbo.Institution", t => t.InstitutionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.SystemAccess", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.InstitutionId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Township",
                c => new
                    {
                        TownshipId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.TownshipId);
            
            CreateTable(
                "dbo.TypeOrigin",
                c => new
                    {
                        TypeOriginId = c.Int(nullable: false, identity: true),
                        TOrigin = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.TypeOriginId);
            
            CreateTable(
                "dbo.TypeSubject",
                c => new
                    {
                        TypeSubjectId = c.Int(nullable: false, identity: true),
                        TSubject = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.TypeSubjectId);
            
            CreateTable(
                "dbo.Validation",
                c => new
                    {
                        ValidationId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ValidationId);
            
            AddColumn("dbo.AspNetRoles", "Description", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemAccessRoles", "Id", "dbo.SystemAccess");
            DropForeignKey("dbo.SystemAccessRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SystemAccessRoles", "InstitutionId", "dbo.Institution");
            DropIndex("dbo.SystemAccessRoles", new[] { "RoleId" });
            DropIndex("dbo.SystemAccessRoles", new[] { "InstitutionId" });
            DropIndex("dbo.SystemAccessRoles", new[] { "Id" });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetRoles", "Description");
            DropTable("dbo.Validation");
            DropTable("dbo.TypeSubject");
            DropTable("dbo.TypeOrigin");
            DropTable("dbo.Township");
            DropTable("dbo.SystemAccessRoles");
            DropTable("dbo.SystemAccess");
            DropTable("dbo.Solicitude");
            DropTable("dbo.Requirements");
            DropTable("dbo.Record");
            DropTable("dbo.Provenance");
            DropTable("dbo.Locality");
            DropTable("dbo.Institution");
            DropTable("dbo.EducationLevel");
            DropTable("dbo.Document");
            DropTable("dbo.DetailRecord");
            DropTable("dbo.Department");
            DropTable("dbo.Contact");
            DropTable("dbo.College");
            DropTable("dbo.Beneficiary");
        }
    }
}
