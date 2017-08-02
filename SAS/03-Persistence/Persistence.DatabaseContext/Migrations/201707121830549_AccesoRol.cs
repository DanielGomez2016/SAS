namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AccesoRol : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Courses", newName: "Course");
            RenameTable(name: "dbo.StudentPerCourses", newName: "StudentPerCourse");
            RenameTable(name: "dbo.Students", newName: "Student");
            CreateTable(
                "dbo.AccesoSistema",
                c => new
                    {
                        AccesoSistemaId = c.Int(nullable: false, identity: true),
                        Controlador = c.String(nullable: false, maxLength: 50),
                        Accion = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                        Activo = c.Boolean(nullable: false),
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
                    { "DynamicFilter_AccesoSistema_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.AccesoSistemaId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.AccesoSistemaRol",
                c => new
                    {
                        AccesoSistemaId = c.Int(nullable: false),
                        Id = c.String(nullable: false, maxLength: 128),
                        InstitucionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccesoSistemaId, t.Id, t.InstitucionId })
                .ForeignKey("dbo.AccesoSistema", t => t.AccesoSistemaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Institucion", t => t.InstitucionId, cascadeDelete: true)
                .Index(t => t.AccesoSistemaId)
                .Index(t => t.Id)
                .Index(t => t.InstitucionId);
            
            CreateTable(
                "dbo.Institucion",
                c => new
                    {
                        InstitucionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Siglas = c.String(),
                        Titular = c.String(),
                        Descripcion = c.String(),
                        Telefono = c.String(),
                        Ext = c.String(),
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
                    { "DynamicFilter_Institucion_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.InstitucionId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccesoSistema", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AccesoSistema", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AccesoSistema", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Institucion", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Institucion", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Institucion", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AccesoSistemaRol", "InstitucionId", "dbo.Institucion");
            DropForeignKey("dbo.AccesoSistemaRol", "Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AccesoSistemaRol", "AccesoSistemaId", "dbo.AccesoSistema");
            DropIndex("dbo.Institucion", new[] { "DeletedBy" });
            DropIndex("dbo.Institucion", new[] { "UpdatedBy" });
            DropIndex("dbo.Institucion", new[] { "CreatedBy" });
            DropIndex("dbo.AccesoSistemaRol", new[] { "InstitucionId" });
            DropIndex("dbo.AccesoSistemaRol", new[] { "Id" });
            DropIndex("dbo.AccesoSistemaRol", new[] { "AccesoSistemaId" });
            DropIndex("dbo.AccesoSistema", new[] { "DeletedBy" });
            DropIndex("dbo.AccesoSistema", new[] { "UpdatedBy" });
            DropIndex("dbo.AccesoSistema", new[] { "CreatedBy" });
            DropTable("dbo.Institucion",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Institucion_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AccesoSistemaRol");
            DropTable("dbo.AccesoSistema",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AccesoSistema_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            RenameTable(name: "dbo.Student", newName: "Students");
            RenameTable(name: "dbo.StudentPerCourse", newName: "StudentPerCourses");
            RenameTable(name: "dbo.Course", newName: "Courses");
        }
    }
}
