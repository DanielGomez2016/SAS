namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class sprintv120 : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Beneficiary",
                c => new
                    {
                        BeneficiaryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        address = c.String(nullable: false, maxLength: 100),
                        LocalityId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Beneficiary_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Contact",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        CelPhone = c.String(maxLength: 20),
                        BeneficiaryId = c.Int(nullable: false),
                        CollegeId = c.Int(nullable: false),
                        ProvenanceId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Contact_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                        LocalityId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        EducationLevel_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_College_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.EducationLevel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, unicode: false, storeType: "text"),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_EducationLevel_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Locality",
                c => new
                    {
                        LocalityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        TownshipId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Locality_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Township",
                c => new
                    {
                        TownshipId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Township_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Requirements",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Requirements_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Solicitude",
                c => new
                    {
                        SolicitudeId = c.Int(nullable: false, identity: true),
                        Folio = c.String(nullable: false, maxLength: 50),
                        DeliverDate = c.DateTime(nullable: false),
                        Affair = c.String(nullable: false, unicode: false, storeType: "text"),
                        GeneralGoal = c.String(unicode: false, storeType: "text"),
                        ValidationDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        TypeSubjectId = c.Int(nullable: false),
                        ProvenanceId = c.Int(nullable: false),
                        CollegeId = c.Int(nullable: false),
                        BeneficiaryId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Solicitude_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Provenance",
                c => new
                    {
                        ProvenanceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 75),
                        TypeOriginId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Provenance_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.TypeOrigin",
                c => new
                    {
                        TypeOriginId = c.Int(nullable: false, identity: true),
                        TOrigin = c.String(nullable: false, maxLength: 100),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TypeOrigin_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Record",
                c => new
                    {
                        RecordId = c.Int(nullable: false),
                        Validation = c.Int(nullable: false),
                        InstitutionId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Record_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.DetailRecord",
                c => new
                    {
                        DetailRecordId = c.Int(nullable: false, identity: true),
                        RecordDate = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false, unicode: false, storeType: "text"),
                        Status = c.Int(nullable: false),
                        RecordId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        UserAssignsId = c.String(maxLength: 128),
                        UserAttendsId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_DetailRecord_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Manager = c.String(nullable: false, maxLength: 75),
                        Description = c.String(unicode: false, storeType: "text"),
                        Extension = c.String(nullable: false, maxLength: 10),
                        InstitutionId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Department_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Institution_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Document",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 50),
                        File = c.Binary(nullable: false, maxLength: 8000),
                        DetailRecordId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Document_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.TypeSubject",
                c => new
                    {
                        TypeSubjectId = c.Int(nullable: false, identity: true),
                        TSubject = c.String(nullable: false, maxLength: 100),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TypeSubject_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Validation",
                c => new
                    {
                        ValidationId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Validation_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.SystemAccess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Controller = c.String(nullable: false, maxLength: 75),
                        Action = c.String(nullable: false, maxLength: 75),
                        Description = c.String(nullable: false, maxLength: 250),
                        Status = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_SystemAccess_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.SystemAccessRoles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        InstitutionId = c.Int(nullable: false),
                        RoleId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_SystemAccessRoles_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.Beneficiary", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Beneficiary", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Beneficiary", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Beneficiary", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Beneficiary", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Beneficiary", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Beneficiary", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Contact", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contact", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Contact", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Contact", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Contact", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Contact", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Contact", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.College", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.College", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.College", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.College", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.College", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.College", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.College", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.EducationLevel", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.EducationLevel", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.EducationLevel", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.EducationLevel", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.EducationLevel", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.EducationLevel", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.EducationLevel", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Locality", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Locality", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Locality", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Locality", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Locality", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Locality", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Locality", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Township", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Township", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Township", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Township", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Township", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Township", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Township", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Requirements", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Requirements", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Requirements", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Requirements", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Requirements", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Requirements", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Requirements", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Solicitude", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Solicitude", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Solicitude", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Solicitude", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Solicitude", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Solicitude", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Solicitude", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Provenance", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Provenance", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Provenance", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Provenance", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Provenance", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Provenance", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Provenance", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.TypeOrigin", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.TypeOrigin", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.TypeOrigin", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.TypeOrigin", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.TypeOrigin", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.TypeOrigin", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.TypeOrigin", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Record", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Record", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Record", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Record", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Record", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Record", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Record", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.DetailRecord", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.DetailRecord", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.DetailRecord", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.DetailRecord", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.DetailRecord", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.DetailRecord", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.DetailRecord", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Department", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Department", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Department", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Department", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Department", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Department", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Department", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Institution", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Institution", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Institution", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Institution", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Institution", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Institution", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Institution", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Document", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Document", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Document", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Document", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Document", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Document", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Document", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.TypeSubject", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.TypeSubject", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.TypeSubject", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.TypeSubject", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.TypeSubject", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.TypeSubject", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.TypeSubject", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Validation", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Validation", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Validation", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Validation", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Validation", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Validation", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Validation", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.SystemAccess", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.SystemAccess", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.SystemAccess", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.SystemAccess", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.SystemAccess", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.SystemAccess", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.SystemAccess", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.SystemAccessRoles", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.SystemAccessRoles", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.SystemAccessRoles", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.SystemAccessRoles", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.SystemAccessRoles", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.SystemAccessRoles", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.SystemAccessRoles", "DeletedBy", c => c.String(maxLength: 128));
            CreateIndex("dbo.Beneficiary", "CreatedBy");
            CreateIndex("dbo.Beneficiary", "UpdatedBy");
            CreateIndex("dbo.Beneficiary", "DeletedBy");
            CreateIndex("dbo.Contact", "CreatedBy");
            CreateIndex("dbo.Contact", "UpdatedBy");
            CreateIndex("dbo.Contact", "DeletedBy");
            CreateIndex("dbo.College", "CreatedBy");
            CreateIndex("dbo.College", "UpdatedBy");
            CreateIndex("dbo.College", "DeletedBy");
            CreateIndex("dbo.EducationLevel", "CreatedBy");
            CreateIndex("dbo.EducationLevel", "UpdatedBy");
            CreateIndex("dbo.EducationLevel", "DeletedBy");
            CreateIndex("dbo.Locality", "CreatedBy");
            CreateIndex("dbo.Locality", "UpdatedBy");
            CreateIndex("dbo.Locality", "DeletedBy");
            CreateIndex("dbo.Township", "CreatedBy");
            CreateIndex("dbo.Township", "UpdatedBy");
            CreateIndex("dbo.Township", "DeletedBy");
            CreateIndex("dbo.Requirements", "CreatedBy");
            CreateIndex("dbo.Requirements", "UpdatedBy");
            CreateIndex("dbo.Requirements", "DeletedBy");
            CreateIndex("dbo.Solicitude", "CreatedBy");
            CreateIndex("dbo.Solicitude", "UpdatedBy");
            CreateIndex("dbo.Solicitude", "DeletedBy");
            CreateIndex("dbo.Provenance", "CreatedBy");
            CreateIndex("dbo.Provenance", "UpdatedBy");
            CreateIndex("dbo.Provenance", "DeletedBy");
            CreateIndex("dbo.TypeOrigin", "CreatedBy");
            CreateIndex("dbo.TypeOrigin", "UpdatedBy");
            CreateIndex("dbo.TypeOrigin", "DeletedBy");
            CreateIndex("dbo.Record", "CreatedBy");
            CreateIndex("dbo.Record", "UpdatedBy");
            CreateIndex("dbo.Record", "DeletedBy");
            CreateIndex("dbo.DetailRecord", "CreatedBy");
            CreateIndex("dbo.DetailRecord", "UpdatedBy");
            CreateIndex("dbo.DetailRecord", "DeletedBy");
            CreateIndex("dbo.Department", "CreatedBy");
            CreateIndex("dbo.Department", "UpdatedBy");
            CreateIndex("dbo.Department", "DeletedBy");
            CreateIndex("dbo.Institution", "CreatedBy");
            CreateIndex("dbo.Institution", "UpdatedBy");
            CreateIndex("dbo.Institution", "DeletedBy");
            CreateIndex("dbo.Document", "CreatedBy");
            CreateIndex("dbo.Document", "UpdatedBy");
            CreateIndex("dbo.Document", "DeletedBy");
            CreateIndex("dbo.TypeSubject", "CreatedBy");
            CreateIndex("dbo.TypeSubject", "UpdatedBy");
            CreateIndex("dbo.TypeSubject", "DeletedBy");
            CreateIndex("dbo.Validation", "CreatedBy");
            CreateIndex("dbo.Validation", "UpdatedBy");
            CreateIndex("dbo.Validation", "DeletedBy");
            CreateIndex("dbo.SystemAccess", "CreatedBy");
            CreateIndex("dbo.SystemAccess", "UpdatedBy");
            CreateIndex("dbo.SystemAccess", "DeletedBy");
            CreateIndex("dbo.SystemAccessRoles", "CreatedBy");
            CreateIndex("dbo.SystemAccessRoles", "UpdatedBy");
            CreateIndex("dbo.SystemAccessRoles", "DeletedBy");
            AddForeignKey("dbo.College", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.College", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EducationLevel", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EducationLevel", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EducationLevel", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Locality", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Locality", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Township", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Township", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Township", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Locality", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Requirements", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Requirements", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Requirements", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Solicitude", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Solicitude", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Provenance", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Provenance", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TypeOrigin", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TypeOrigin", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TypeOrigin", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Provenance", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Record", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Record", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.DetailRecord", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.DetailRecord", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Department", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Department", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Institution", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Institution", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Institution", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Department", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Document", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Document", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Document", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.DetailRecord", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Record", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TypeSubject", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TypeSubject", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TypeSubject", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Solicitude", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.College", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Validation", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Validation", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Validation", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Contact", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Contact", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Contact", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Beneficiary", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Beneficiary", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Beneficiary", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.SystemAccess", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.SystemAccess", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.SystemAccessRoles", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.SystemAccessRoles", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.SystemAccessRoles", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.SystemAccess", "UpdatedBy", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemAccess", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.SystemAccessRoles", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.SystemAccessRoles", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.SystemAccessRoles", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.SystemAccess", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.SystemAccess", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Beneficiary", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Beneficiary", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Beneficiary", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contact", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contact", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contact", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Validation", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Validation", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Validation", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.College", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitude", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TypeSubject", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TypeSubject", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TypeSubject", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Record", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetailRecord", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Document", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Document", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Document", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Department", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Institution", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Institution", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Institution", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Department", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Department", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetailRecord", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetailRecord", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Record", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Record", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Provenance", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TypeOrigin", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TypeOrigin", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TypeOrigin", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Provenance", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Provenance", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitude", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitude", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Requirements", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Requirements", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Requirements", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Locality", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Township", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Township", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Township", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Locality", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Locality", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.EducationLevel", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.EducationLevel", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.EducationLevel", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.College", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.College", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.SystemAccessRoles", new[] { "DeletedBy" });
            DropIndex("dbo.SystemAccessRoles", new[] { "UpdatedBy" });
            DropIndex("dbo.SystemAccessRoles", new[] { "CreatedBy" });
            DropIndex("dbo.SystemAccess", new[] { "DeletedBy" });
            DropIndex("dbo.SystemAccess", new[] { "UpdatedBy" });
            DropIndex("dbo.SystemAccess", new[] { "CreatedBy" });
            DropIndex("dbo.Validation", new[] { "DeletedBy" });
            DropIndex("dbo.Validation", new[] { "UpdatedBy" });
            DropIndex("dbo.Validation", new[] { "CreatedBy" });
            DropIndex("dbo.TypeSubject", new[] { "DeletedBy" });
            DropIndex("dbo.TypeSubject", new[] { "UpdatedBy" });
            DropIndex("dbo.TypeSubject", new[] { "CreatedBy" });
            DropIndex("dbo.Document", new[] { "DeletedBy" });
            DropIndex("dbo.Document", new[] { "UpdatedBy" });
            DropIndex("dbo.Document", new[] { "CreatedBy" });
            DropIndex("dbo.Institution", new[] { "DeletedBy" });
            DropIndex("dbo.Institution", new[] { "UpdatedBy" });
            DropIndex("dbo.Institution", new[] { "CreatedBy" });
            DropIndex("dbo.Department", new[] { "DeletedBy" });
            DropIndex("dbo.Department", new[] { "UpdatedBy" });
            DropIndex("dbo.Department", new[] { "CreatedBy" });
            DropIndex("dbo.DetailRecord", new[] { "DeletedBy" });
            DropIndex("dbo.DetailRecord", new[] { "UpdatedBy" });
            DropIndex("dbo.DetailRecord", new[] { "CreatedBy" });
            DropIndex("dbo.Record", new[] { "DeletedBy" });
            DropIndex("dbo.Record", new[] { "UpdatedBy" });
            DropIndex("dbo.Record", new[] { "CreatedBy" });
            DropIndex("dbo.TypeOrigin", new[] { "DeletedBy" });
            DropIndex("dbo.TypeOrigin", new[] { "UpdatedBy" });
            DropIndex("dbo.TypeOrigin", new[] { "CreatedBy" });
            DropIndex("dbo.Provenance", new[] { "DeletedBy" });
            DropIndex("dbo.Provenance", new[] { "UpdatedBy" });
            DropIndex("dbo.Provenance", new[] { "CreatedBy" });
            DropIndex("dbo.Solicitude", new[] { "DeletedBy" });
            DropIndex("dbo.Solicitude", new[] { "UpdatedBy" });
            DropIndex("dbo.Solicitude", new[] { "CreatedBy" });
            DropIndex("dbo.Requirements", new[] { "DeletedBy" });
            DropIndex("dbo.Requirements", new[] { "UpdatedBy" });
            DropIndex("dbo.Requirements", new[] { "CreatedBy" });
            DropIndex("dbo.Township", new[] { "DeletedBy" });
            DropIndex("dbo.Township", new[] { "UpdatedBy" });
            DropIndex("dbo.Township", new[] { "CreatedBy" });
            DropIndex("dbo.Locality", new[] { "DeletedBy" });
            DropIndex("dbo.Locality", new[] { "UpdatedBy" });
            DropIndex("dbo.Locality", new[] { "CreatedBy" });
            DropIndex("dbo.EducationLevel", new[] { "DeletedBy" });
            DropIndex("dbo.EducationLevel", new[] { "UpdatedBy" });
            DropIndex("dbo.EducationLevel", new[] { "CreatedBy" });
            DropIndex("dbo.College", new[] { "DeletedBy" });
            DropIndex("dbo.College", new[] { "UpdatedBy" });
            DropIndex("dbo.College", new[] { "CreatedBy" });
            DropIndex("dbo.Contact", new[] { "DeletedBy" });
            DropIndex("dbo.Contact", new[] { "UpdatedBy" });
            DropIndex("dbo.Contact", new[] { "CreatedBy" });
            DropIndex("dbo.Beneficiary", new[] { "DeletedBy" });
            DropIndex("dbo.Beneficiary", new[] { "UpdatedBy" });
            DropIndex("dbo.Beneficiary", new[] { "CreatedBy" });
            DropColumn("dbo.SystemAccessRoles", "DeletedBy");
            DropColumn("dbo.SystemAccessRoles", "DeletedAt");
            DropColumn("dbo.SystemAccessRoles", "UpdatedBy");
            DropColumn("dbo.SystemAccessRoles", "UpdatedAt");
            DropColumn("dbo.SystemAccessRoles", "CreatedBy");
            DropColumn("dbo.SystemAccessRoles", "CreatedAt");
            DropColumn("dbo.SystemAccessRoles", "Deleted");
            DropColumn("dbo.SystemAccess", "DeletedBy");
            DropColumn("dbo.SystemAccess", "DeletedAt");
            DropColumn("dbo.SystemAccess", "UpdatedBy");
            DropColumn("dbo.SystemAccess", "UpdatedAt");
            DropColumn("dbo.SystemAccess", "CreatedBy");
            DropColumn("dbo.SystemAccess", "CreatedAt");
            DropColumn("dbo.SystemAccess", "Deleted");
            DropColumn("dbo.Validation", "DeletedBy");
            DropColumn("dbo.Validation", "DeletedAt");
            DropColumn("dbo.Validation", "UpdatedBy");
            DropColumn("dbo.Validation", "UpdatedAt");
            DropColumn("dbo.Validation", "CreatedBy");
            DropColumn("dbo.Validation", "CreatedAt");
            DropColumn("dbo.Validation", "Deleted");
            DropColumn("dbo.TypeSubject", "DeletedBy");
            DropColumn("dbo.TypeSubject", "DeletedAt");
            DropColumn("dbo.TypeSubject", "UpdatedBy");
            DropColumn("dbo.TypeSubject", "UpdatedAt");
            DropColumn("dbo.TypeSubject", "CreatedBy");
            DropColumn("dbo.TypeSubject", "CreatedAt");
            DropColumn("dbo.TypeSubject", "Deleted");
            DropColumn("dbo.Document", "DeletedBy");
            DropColumn("dbo.Document", "DeletedAt");
            DropColumn("dbo.Document", "UpdatedBy");
            DropColumn("dbo.Document", "UpdatedAt");
            DropColumn("dbo.Document", "CreatedBy");
            DropColumn("dbo.Document", "CreatedAt");
            DropColumn("dbo.Document", "Deleted");
            DropColumn("dbo.Institution", "DeletedBy");
            DropColumn("dbo.Institution", "DeletedAt");
            DropColumn("dbo.Institution", "UpdatedBy");
            DropColumn("dbo.Institution", "UpdatedAt");
            DropColumn("dbo.Institution", "CreatedBy");
            DropColumn("dbo.Institution", "CreatedAt");
            DropColumn("dbo.Institution", "Deleted");
            DropColumn("dbo.Department", "DeletedBy");
            DropColumn("dbo.Department", "DeletedAt");
            DropColumn("dbo.Department", "UpdatedBy");
            DropColumn("dbo.Department", "UpdatedAt");
            DropColumn("dbo.Department", "CreatedBy");
            DropColumn("dbo.Department", "CreatedAt");
            DropColumn("dbo.Department", "Deleted");
            DropColumn("dbo.DetailRecord", "DeletedBy");
            DropColumn("dbo.DetailRecord", "DeletedAt");
            DropColumn("dbo.DetailRecord", "UpdatedBy");
            DropColumn("dbo.DetailRecord", "UpdatedAt");
            DropColumn("dbo.DetailRecord", "CreatedBy");
            DropColumn("dbo.DetailRecord", "CreatedAt");
            DropColumn("dbo.DetailRecord", "Deleted");
            DropColumn("dbo.Record", "DeletedBy");
            DropColumn("dbo.Record", "DeletedAt");
            DropColumn("dbo.Record", "UpdatedBy");
            DropColumn("dbo.Record", "UpdatedAt");
            DropColumn("dbo.Record", "CreatedBy");
            DropColumn("dbo.Record", "CreatedAt");
            DropColumn("dbo.Record", "Deleted");
            DropColumn("dbo.TypeOrigin", "DeletedBy");
            DropColumn("dbo.TypeOrigin", "DeletedAt");
            DropColumn("dbo.TypeOrigin", "UpdatedBy");
            DropColumn("dbo.TypeOrigin", "UpdatedAt");
            DropColumn("dbo.TypeOrigin", "CreatedBy");
            DropColumn("dbo.TypeOrigin", "CreatedAt");
            DropColumn("dbo.TypeOrigin", "Deleted");
            DropColumn("dbo.Provenance", "DeletedBy");
            DropColumn("dbo.Provenance", "DeletedAt");
            DropColumn("dbo.Provenance", "UpdatedBy");
            DropColumn("dbo.Provenance", "UpdatedAt");
            DropColumn("dbo.Provenance", "CreatedBy");
            DropColumn("dbo.Provenance", "CreatedAt");
            DropColumn("dbo.Provenance", "Deleted");
            DropColumn("dbo.Solicitude", "DeletedBy");
            DropColumn("dbo.Solicitude", "DeletedAt");
            DropColumn("dbo.Solicitude", "UpdatedBy");
            DropColumn("dbo.Solicitude", "UpdatedAt");
            DropColumn("dbo.Solicitude", "CreatedBy");
            DropColumn("dbo.Solicitude", "CreatedAt");
            DropColumn("dbo.Solicitude", "Deleted");
            DropColumn("dbo.Requirements", "DeletedBy");
            DropColumn("dbo.Requirements", "DeletedAt");
            DropColumn("dbo.Requirements", "UpdatedBy");
            DropColumn("dbo.Requirements", "UpdatedAt");
            DropColumn("dbo.Requirements", "CreatedBy");
            DropColumn("dbo.Requirements", "CreatedAt");
            DropColumn("dbo.Requirements", "Deleted");
            DropColumn("dbo.Township", "DeletedBy");
            DropColumn("dbo.Township", "DeletedAt");
            DropColumn("dbo.Township", "UpdatedBy");
            DropColumn("dbo.Township", "UpdatedAt");
            DropColumn("dbo.Township", "CreatedBy");
            DropColumn("dbo.Township", "CreatedAt");
            DropColumn("dbo.Township", "Deleted");
            DropColumn("dbo.Locality", "DeletedBy");
            DropColumn("dbo.Locality", "DeletedAt");
            DropColumn("dbo.Locality", "UpdatedBy");
            DropColumn("dbo.Locality", "UpdatedAt");
            DropColumn("dbo.Locality", "CreatedBy");
            DropColumn("dbo.Locality", "CreatedAt");
            DropColumn("dbo.Locality", "Deleted");
            DropColumn("dbo.EducationLevel", "DeletedBy");
            DropColumn("dbo.EducationLevel", "DeletedAt");
            DropColumn("dbo.EducationLevel", "UpdatedBy");
            DropColumn("dbo.EducationLevel", "UpdatedAt");
            DropColumn("dbo.EducationLevel", "CreatedBy");
            DropColumn("dbo.EducationLevel", "CreatedAt");
            DropColumn("dbo.EducationLevel", "Deleted");
            DropColumn("dbo.College", "DeletedBy");
            DropColumn("dbo.College", "DeletedAt");
            DropColumn("dbo.College", "UpdatedBy");
            DropColumn("dbo.College", "UpdatedAt");
            DropColumn("dbo.College", "CreatedBy");
            DropColumn("dbo.College", "CreatedAt");
            DropColumn("dbo.College", "Deleted");
            DropColumn("dbo.Contact", "DeletedBy");
            DropColumn("dbo.Contact", "DeletedAt");
            DropColumn("dbo.Contact", "UpdatedBy");
            DropColumn("dbo.Contact", "UpdatedAt");
            DropColumn("dbo.Contact", "CreatedBy");
            DropColumn("dbo.Contact", "CreatedAt");
            DropColumn("dbo.Contact", "Deleted");
            DropColumn("dbo.Beneficiary", "DeletedBy");
            DropColumn("dbo.Beneficiary", "DeletedAt");
            DropColumn("dbo.Beneficiary", "UpdatedBy");
            DropColumn("dbo.Beneficiary", "UpdatedAt");
            DropColumn("dbo.Beneficiary", "CreatedBy");
            DropColumn("dbo.Beneficiary", "CreatedAt");
            DropColumn("dbo.Beneficiary", "Deleted");
            AlterTableAnnotations(
                "dbo.SystemAccessRoles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        InstitutionId = c.Int(nullable: false),
                        RoleId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_SystemAccessRoles_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.SystemAccess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Controller = c.String(nullable: false, maxLength: 75),
                        Action = c.String(nullable: false, maxLength: 75),
                        Description = c.String(nullable: false, maxLength: 250),
                        Status = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_SystemAccess_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Validation",
                c => new
                    {
                        ValidationId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Validation_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.TypeSubject",
                c => new
                    {
                        TypeSubjectId = c.Int(nullable: false, identity: true),
                        TSubject = c.String(nullable: false, maxLength: 100),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TypeSubject_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Document",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 50),
                        File = c.Binary(nullable: false, maxLength: 8000),
                        DetailRecordId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Document_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Institution_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Manager = c.String(nullable: false, maxLength: 75),
                        Description = c.String(unicode: false, storeType: "text"),
                        Extension = c.String(nullable: false, maxLength: 10),
                        InstitutionId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Department_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.DetailRecord",
                c => new
                    {
                        DetailRecordId = c.Int(nullable: false, identity: true),
                        RecordDate = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false, unicode: false, storeType: "text"),
                        Status = c.Int(nullable: false),
                        RecordId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        UserAssignsId = c.String(maxLength: 128),
                        UserAttendsId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_DetailRecord_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Record",
                c => new
                    {
                        RecordId = c.Int(nullable: false),
                        Validation = c.Int(nullable: false),
                        InstitutionId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Record_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.TypeOrigin",
                c => new
                    {
                        TypeOriginId = c.Int(nullable: false, identity: true),
                        TOrigin = c.String(nullable: false, maxLength: 100),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_TypeOrigin_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Provenance",
                c => new
                    {
                        ProvenanceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 75),
                        TypeOriginId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Provenance_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Solicitude",
                c => new
                    {
                        SolicitudeId = c.Int(nullable: false, identity: true),
                        Folio = c.String(nullable: false, maxLength: 50),
                        DeliverDate = c.DateTime(nullable: false),
                        Affair = c.String(nullable: false, unicode: false, storeType: "text"),
                        GeneralGoal = c.String(unicode: false, storeType: "text"),
                        ValidationDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        TypeSubjectId = c.Int(nullable: false),
                        ProvenanceId = c.Int(nullable: false),
                        CollegeId = c.Int(nullable: false),
                        BeneficiaryId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Solicitude_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Requirements",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Requirements_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Township",
                c => new
                    {
                        TownshipId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Township_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Locality",
                c => new
                    {
                        LocalityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        TownshipId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Locality_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.EducationLevel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, unicode: false, storeType: "text"),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_EducationLevel_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                        LocalityId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        EducationLevel_Id = c.Int(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_College_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Contact",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        CelPhone = c.String(maxLength: 20),
                        BeneficiaryId = c.Int(nullable: false),
                        CollegeId = c.Int(nullable: false),
                        ProvenanceId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Contact_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Beneficiary",
                c => new
                    {
                        BeneficiaryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        address = c.String(nullable: false, maxLength: 100),
                        LocalityId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Beneficiary_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
