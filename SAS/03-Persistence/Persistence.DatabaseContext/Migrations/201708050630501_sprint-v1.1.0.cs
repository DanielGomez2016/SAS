namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sprintv110 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Record");
            DropPrimaryKey("dbo.Requirements");
            DropPrimaryKey("dbo.Validation");
            AddColumn("dbo.Beneficiary", "LocalityId", c => c.Int(nullable: false));
            AddColumn("dbo.College", "LocalityId", c => c.Int(nullable: false));
            AddColumn("dbo.College", "LevelId", c => c.Int(nullable: false));
            AddColumn("dbo.College", "EducationLevel_Id", c => c.Int());
            AddColumn("dbo.Contact", "BeneficiaryId", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "CollegeId", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "ProvenanceId", c => c.Int(nullable: false));
            AddColumn("dbo.Department", "InstitutionId", c => c.Int(nullable: false));
            AddColumn("dbo.DetailRecord", "RecordId", c => c.Int(nullable: false));
            AddColumn("dbo.DetailRecord", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.DetailRecord", "UserAssignsId", c => c.String(maxLength: 128));
            AddColumn("dbo.DetailRecord", "UserAttendsId", c => c.String(maxLength: 128));
            AddColumn("dbo.Document", "DetailRecordId", c => c.Int(nullable: false));
            AddColumn("dbo.Locality", "TownshipId", c => c.Int(nullable: false));
            AddColumn("dbo.Provenance", "TypeOriginId", c => c.Int(nullable: false));
            AddColumn("dbo.Record", "InstitutionId", c => c.Int(nullable: false));
            AddColumn("dbo.Solicitude", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Solicitude", "TypeSubjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Solicitude", "ProvenanceId", c => c.Int(nullable: false));
            AddColumn("dbo.Solicitude", "CollegeId", c => c.Int(nullable: false));
            AddColumn("dbo.Solicitude", "BeneficiaryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Record", "RecordId", c => c.Int(nullable: false));
            AlterColumn("dbo.Requirements", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Validation", "ValidationId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Record", "RecordId");
            AddPrimaryKey("dbo.Requirements", "Id");
            AddPrimaryKey("dbo.Validation", "ValidationId");
            CreateIndex("dbo.Beneficiary", "LocalityId");
            CreateIndex("dbo.Contact", "BeneficiaryId");
            CreateIndex("dbo.Contact", "CollegeId");
            CreateIndex("dbo.Contact", "ProvenanceId");
            CreateIndex("dbo.College", "LocalityId");
            CreateIndex("dbo.College", "EducationLevel_Id");
            CreateIndex("dbo.Locality", "TownshipId");
            CreateIndex("dbo.Requirements", "Id");
            CreateIndex("dbo.Solicitude", "TypeSubjectId");
            CreateIndex("dbo.Solicitude", "ProvenanceId");
            CreateIndex("dbo.Solicitude", "CollegeId");
            CreateIndex("dbo.Solicitude", "BeneficiaryId");
            CreateIndex("dbo.Provenance", "TypeOriginId");
            CreateIndex("dbo.Record", "RecordId");
            CreateIndex("dbo.Record", "InstitutionId");
            CreateIndex("dbo.DetailRecord", "RecordId");
            CreateIndex("dbo.DetailRecord", "DepartmentId");
            CreateIndex("dbo.DetailRecord", "UserAssignsId");
            CreateIndex("dbo.DetailRecord", "UserAttendsId");
            CreateIndex("dbo.Department", "InstitutionId");
            CreateIndex("dbo.Document", "DetailRecordId");
            CreateIndex("dbo.Validation", "ValidationId");
            AddForeignKey("dbo.Contact", "BeneficiaryId", "dbo.Beneficiary", "BeneficiaryId", cascadeDelete: true);
            AddForeignKey("dbo.Contact", "CollegeId", "dbo.College", "CollegeId", cascadeDelete: true);
            AddForeignKey("dbo.College", "EducationLevel_Id", "dbo.EducationLevel", "Id");
            AddForeignKey("dbo.Beneficiary", "LocalityId", "dbo.Locality", "LocalityId", cascadeDelete: true);
            AddForeignKey("dbo.College", "LocalityId", "dbo.Locality", "LocalityId", cascadeDelete: false);
            AddForeignKey("dbo.Locality", "TownshipId", "dbo.Township", "TownshipId", cascadeDelete: false);
            AddForeignKey("dbo.Requirements", "Id", "dbo.College", "CollegeId");
            AddForeignKey("dbo.Solicitude", "BeneficiaryId", "dbo.Beneficiary", "BeneficiaryId", cascadeDelete: true);
            AddForeignKey("dbo.Solicitude", "CollegeId", "dbo.College", "CollegeId", cascadeDelete: true);
            AddForeignKey("dbo.Contact", "ProvenanceId", "dbo.Provenance", "ProvenanceId", cascadeDelete: true);
            AddForeignKey("dbo.Solicitude", "ProvenanceId", "dbo.Provenance", "ProvenanceId", cascadeDelete: true);
            AddForeignKey("dbo.Provenance", "TypeOriginId", "dbo.TypeOrigin", "TypeOriginId", cascadeDelete: true);
            AddForeignKey("dbo.DetailRecord", "DepartmentId", "dbo.Department", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Department", "InstitutionId", "dbo.Institution", "InstitutionId", cascadeDelete: true);
            AddForeignKey("dbo.Record", "InstitutionId", "dbo.Institution", "InstitutionId", cascadeDelete: true);
            AddForeignKey("dbo.Document", "DetailRecordId", "dbo.DetailRecord", "DetailRecordId", cascadeDelete: true);
            AddForeignKey("dbo.DetailRecord", "RecordId", "dbo.Record", "RecordId", cascadeDelete: false);
            AddForeignKey("dbo.DetailRecord", "UserAssignsId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.DetailRecord", "UserAttendsId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Record", "RecordId", "dbo.Solicitude", "SolicitudeId");
            AddForeignKey("dbo.Solicitude", "TypeSubjectId", "dbo.TypeSubject", "TypeSubjectId", cascadeDelete: true);
            AddForeignKey("dbo.Validation", "ValidationId", "dbo.College", "CollegeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Validation", "ValidationId", "dbo.College");
            DropForeignKey("dbo.Solicitude", "TypeSubjectId", "dbo.TypeSubject");
            DropForeignKey("dbo.Record", "RecordId", "dbo.Solicitude");
            DropForeignKey("dbo.DetailRecord", "UserAttendsId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetailRecord", "UserAssignsId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetailRecord", "RecordId", "dbo.Record");
            DropForeignKey("dbo.Document", "DetailRecordId", "dbo.DetailRecord");
            DropForeignKey("dbo.Record", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.Department", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.DetailRecord", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Provenance", "TypeOriginId", "dbo.TypeOrigin");
            DropForeignKey("dbo.Solicitude", "ProvenanceId", "dbo.Provenance");
            DropForeignKey("dbo.Contact", "ProvenanceId", "dbo.Provenance");
            DropForeignKey("dbo.Solicitude", "CollegeId", "dbo.College");
            DropForeignKey("dbo.Solicitude", "BeneficiaryId", "dbo.Beneficiary");
            DropForeignKey("dbo.Requirements", "Id", "dbo.College");
            DropForeignKey("dbo.Locality", "TownshipId", "dbo.Township");
            DropForeignKey("dbo.College", "LocalityId", "dbo.Locality");
            DropForeignKey("dbo.Beneficiary", "LocalityId", "dbo.Locality");
            DropForeignKey("dbo.College", "EducationLevel_Id", "dbo.EducationLevel");
            DropForeignKey("dbo.Contact", "CollegeId", "dbo.College");
            DropForeignKey("dbo.Contact", "BeneficiaryId", "dbo.Beneficiary");
            DropIndex("dbo.Validation", new[] { "ValidationId" });
            DropIndex("dbo.Document", new[] { "DetailRecordId" });
            DropIndex("dbo.Department", new[] { "InstitutionId" });
            DropIndex("dbo.DetailRecord", new[] { "UserAttendsId" });
            DropIndex("dbo.DetailRecord", new[] { "UserAssignsId" });
            DropIndex("dbo.DetailRecord", new[] { "DepartmentId" });
            DropIndex("dbo.DetailRecord", new[] { "RecordId" });
            DropIndex("dbo.Record", new[] { "InstitutionId" });
            DropIndex("dbo.Record", new[] { "RecordId" });
            DropIndex("dbo.Provenance", new[] { "TypeOriginId" });
            DropIndex("dbo.Solicitude", new[] { "BeneficiaryId" });
            DropIndex("dbo.Solicitude", new[] { "CollegeId" });
            DropIndex("dbo.Solicitude", new[] { "ProvenanceId" });
            DropIndex("dbo.Solicitude", new[] { "TypeSubjectId" });
            DropIndex("dbo.Requirements", new[] { "Id" });
            DropIndex("dbo.Locality", new[] { "TownshipId" });
            DropIndex("dbo.College", new[] { "EducationLevel_Id" });
            DropIndex("dbo.College", new[] { "LocalityId" });
            DropIndex("dbo.Contact", new[] { "ProvenanceId" });
            DropIndex("dbo.Contact", new[] { "CollegeId" });
            DropIndex("dbo.Contact", new[] { "BeneficiaryId" });
            DropIndex("dbo.Beneficiary", new[] { "LocalityId" });
            DropPrimaryKey("dbo.Validation");
            DropPrimaryKey("dbo.Requirements");
            DropPrimaryKey("dbo.Record");
            AlterColumn("dbo.Validation", "ValidationId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Requirements", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Record", "RecordId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Solicitude", "BeneficiaryId");
            DropColumn("dbo.Solicitude", "CollegeId");
            DropColumn("dbo.Solicitude", "ProvenanceId");
            DropColumn("dbo.Solicitude", "TypeSubjectId");
            DropColumn("dbo.Solicitude", "Status");
            DropColumn("dbo.Record", "InstitutionId");
            DropColumn("dbo.Provenance", "TypeOriginId");
            DropColumn("dbo.Locality", "TownshipId");
            DropColumn("dbo.Document", "DetailRecordId");
            DropColumn("dbo.DetailRecord", "UserAttendsId");
            DropColumn("dbo.DetailRecord", "UserAssignsId");
            DropColumn("dbo.DetailRecord", "DepartmentId");
            DropColumn("dbo.DetailRecord", "RecordId");
            DropColumn("dbo.Department", "InstitutionId");
            DropColumn("dbo.Contact", "ProvenanceId");
            DropColumn("dbo.Contact", "CollegeId");
            DropColumn("dbo.Contact", "BeneficiaryId");
            DropColumn("dbo.College", "EducationLevel_Id");
            DropColumn("dbo.College", "LevelId");
            DropColumn("dbo.College", "LocalityId");
            DropColumn("dbo.Beneficiary", "LocalityId");
            AddPrimaryKey("dbo.Validation", "ValidationId");
            AddPrimaryKey("dbo.Requirements", "Id");
            AddPrimaryKey("dbo.Record", "RecordId");
        }
    }
}
