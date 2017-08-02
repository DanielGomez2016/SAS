namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class add_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Titular = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, unicode: false, storeType: "text"),
                        Extencion = c.String(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        InstitucionId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Departamento_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.DepartamentoId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Institucion", t => t.InstitucionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.InstitucionId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        LocalidadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        ClaveLocalidad = c.String(nullable: false, maxLength: 20),
                        Latitud = c.String(maxLength: 50),
                        Longitud = c.String(maxLength: 50),
                        Altitud = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        MunicipioId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Localidad_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.LocalidadId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Municipio", t => t.MunicipioId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.MunicipioId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Municipio",
                c => new
                    {
                        MunicipioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
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
                    { "DynamicFilter_Municipio_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.MunicipioId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            AddColumn("dbo.Institucion", "Extencion", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Institucion", "Nombre", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Institucion", "Siglas", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Institucion", "Titular", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Institucion", "Descripcion", c => c.String(nullable: false, unicode: false, storeType: "text"));
            AlterColumn("dbo.Institucion", "Telefono", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Institucion", "Ext");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Institucion", "Ext", c => c.String());
            DropForeignKey("dbo.Localidad", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Municipio", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Localidad", "MunicipioId", "dbo.Municipio");
            DropForeignKey("dbo.Municipio", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Municipio", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Localidad", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Localidad", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Departamento", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Departamento", "InstitucionId", "dbo.Institucion");
            DropForeignKey("dbo.Departamento", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Departamento", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Municipio", new[] { "DeletedBy" });
            DropIndex("dbo.Municipio", new[] { "UpdatedBy" });
            DropIndex("dbo.Municipio", new[] { "CreatedBy" });
            DropIndex("dbo.Localidad", new[] { "DeletedBy" });
            DropIndex("dbo.Localidad", new[] { "UpdatedBy" });
            DropIndex("dbo.Localidad", new[] { "CreatedBy" });
            DropIndex("dbo.Localidad", new[] { "MunicipioId" });
            DropIndex("dbo.Departamento", new[] { "DeletedBy" });
            DropIndex("dbo.Departamento", new[] { "UpdatedBy" });
            DropIndex("dbo.Departamento", new[] { "CreatedBy" });
            DropIndex("dbo.Departamento", new[] { "InstitucionId" });
            AlterColumn("dbo.Institucion", "Telefono", c => c.String());
            AlterColumn("dbo.Institucion", "Descripcion", c => c.String());
            AlterColumn("dbo.Institucion", "Titular", c => c.String());
            AlterColumn("dbo.Institucion", "Siglas", c => c.String());
            AlterColumn("dbo.Institucion", "Nombre", c => c.String());
            DropColumn("dbo.Institucion", "Extencion");
            DropTable("dbo.Municipio",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Municipio_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Localidad",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Localidad_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Departamento",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Departamento_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
