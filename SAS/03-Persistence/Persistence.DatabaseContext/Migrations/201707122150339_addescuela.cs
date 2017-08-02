namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addescuela : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Escuela",
                c => new
                    {
                        EscuelaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Clave = c.String(nullable: false, maxLength: 150),
                        Domicilio = c.String(maxLength: 150),
                        Turno = c.String(maxLength: 150),
                        Geox = c.String(maxLength: 500),
                        Geoy = c.String(maxLength: 500),
                        CodigoPostal = c.Int(nullable: false),
                        Colonia = c.String(maxLength: 100),
                        Marginacion = c.String(maxLength: 50),
                        Poblacion = c.String(maxLength: 50),
                        Zona = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        LocalidadId = c.Int(nullable: false),
                        NivelEducativoId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Escuela_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.EscuelaId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId, cascadeDelete: true)
                .ForeignKey("dbo.NivelEducativo", t => t.NivelEducativoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.LocalidadId)
                .Index(t => t.NivelEducativoId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            AlterTableAnnotations(
                "dbo.NivelEducativo",
                c => new
                    {
                        NivelEducativoId = c.Int(nullable: false, identity: true),
                        Nivel = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, unicode: false, storeType: "text"),
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
                        "DynamicFilter_NivelEducativo_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.NivelEducativo", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.NivelEducativo", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.NivelEducativo", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.NivelEducativo", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.NivelEducativo", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.NivelEducativo", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.NivelEducativo", "DeletedBy", c => c.String(maxLength: 128));
            CreateIndex("dbo.NivelEducativo", "CreatedBy");
            CreateIndex("dbo.NivelEducativo", "UpdatedBy");
            CreateIndex("dbo.NivelEducativo", "DeletedBy");
            AddForeignKey("dbo.NivelEducativo", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.NivelEducativo", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.NivelEducativo", "UpdatedBy", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Escuela", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.NivelEducativo", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Escuela", "NivelEducativoId", "dbo.NivelEducativo");
            DropForeignKey("dbo.NivelEducativo", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.NivelEducativo", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Escuela", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Escuela", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Escuela", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.NivelEducativo", new[] { "DeletedBy" });
            DropIndex("dbo.NivelEducativo", new[] { "UpdatedBy" });
            DropIndex("dbo.NivelEducativo", new[] { "CreatedBy" });
            DropIndex("dbo.Escuela", new[] { "DeletedBy" });
            DropIndex("dbo.Escuela", new[] { "UpdatedBy" });
            DropIndex("dbo.Escuela", new[] { "CreatedBy" });
            DropIndex("dbo.Escuela", new[] { "NivelEducativoId" });
            DropIndex("dbo.Escuela", new[] { "LocalidadId" });
            DropColumn("dbo.NivelEducativo", "DeletedBy");
            DropColumn("dbo.NivelEducativo", "DeletedAt");
            DropColumn("dbo.NivelEducativo", "UpdatedBy");
            DropColumn("dbo.NivelEducativo", "UpdatedAt");
            DropColumn("dbo.NivelEducativo", "CreatedBy");
            DropColumn("dbo.NivelEducativo", "CreatedAt");
            DropColumn("dbo.NivelEducativo", "Deleted");
            AlterTableAnnotations(
                "dbo.NivelEducativo",
                c => new
                    {
                        NivelEducativoId = c.Int(nullable: false, identity: true),
                        Nivel = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, unicode: false, storeType: "text"),
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
                        "DynamicFilter_NivelEducativo_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropTable("dbo.Escuela",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Escuela_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
