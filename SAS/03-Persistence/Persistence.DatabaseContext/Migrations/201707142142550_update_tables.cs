namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class update_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Solicitud",
                c => new
                    {
                        SolicitudId = c.Int(nullable: false, identity: true),
                        Folio = c.String(nullable: false, maxLength: 25),
                        FechaEntrega = c.DateTime(nullable: false),
                        Asunto = c.String(nullable: false, unicode: false, storeType: "text"),
                        MetaGeneral = c.String(unicode: false, storeType: "text"),
                        FechaValidacion = c.DateTime(nullable: false),
                        Programa = c.String(nullable: false, maxLength: 50),
                        EscuelaId = c.Int(nullable: false),
                        BeneficiarioId = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        InstitucionId = c.Int(nullable: false),
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
                    { "DynamicFilter_Solicitud_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.SolicitudId)
                .ForeignKey("dbo.Beneficiario", t => t.BeneficiarioId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId, cascadeDelete: true)
                .ForeignKey("dbo.Escuela", t => t.EscuelaId, cascadeDelete: true)
                .ForeignKey("dbo.Institucion", t => t.InstitucionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.EscuelaId)
                .Index(t => t.BeneficiarioId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.InstitucionId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Canalizacion",
                c => new
                    {
                        CanalizacionId = c.Int(nullable: false, identity: true),
                        Validacion = c.Boolean(nullable: false),
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
                    { "DynamicFilter_Canalizacion_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.CanalizacionId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.DetCanalizacion",
                c => new
                    {
                        DetCanalizacionId = c.Int(nullable: false, identity: true),
                        FechaCanalizacion = c.DateTime(nullable: false),
                        Comentario = c.String(nullable: false, unicode: false, storeType: "text"),
                        AtiendeId = c.String(),
                        CanalizacionId = c.Int(nullable: false),
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
                    { "DynamicFilter_DetCanalizacion_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.DetCanalizacionId)
                .ForeignKey("dbo.Canalizacion", t => t.CanalizacionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CanalizacionId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Estatus",
                c => new
                    {
                        EstatusId = c.Int(nullable: false, identity: true),
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
                    { "DynamicFilter_Estatus_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.EstatusId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Procedencia",
                c => new
                    {
                        ProcedenciaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        Domicilio = c.String(nullable: false, maxLength: 250),
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
                    { "DynamicFilter_Procedencia_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.ProcedenciaId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.TipoAsunto",
                c => new
                    {
                        TipoAsuntoId = c.Int(nullable: false, identity: true),
                        Asunto = c.String(nullable: false, maxLength: 250),
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
                    { "DynamicFilter_TipoAsunto_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.TipoAsuntoId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.TipoProcedencia",
                c => new
                    {
                        TipoProcedenciaId = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 250),
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
                    { "DynamicFilter_TipoProcedencia_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.TipoProcedenciaId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "ApellidoPaterno", c => c.String());
            AddColumn("dbo.AspNetUsers", "ApellidoMaterno", c => c.String());
            AddColumn("dbo.AspNetUsers", "Imagen", c => c.Binary());
            AddColumn("dbo.AspNetUsers", "InstitucionId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "DepartamentoId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Departamento_DepartamentoId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Departamento_DepartamentoId1", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Institucion_InstitucionId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Institucion_InstitucionId1", c => c.Int());
            AlterColumn("dbo.Beneficiario", "Nombre", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.AspNetUsers", "Departamento_DepartamentoId");
            CreateIndex("dbo.AspNetUsers", "Departamento_DepartamentoId1");
            CreateIndex("dbo.AspNetUsers", "Institucion_InstitucionId");
            CreateIndex("dbo.AspNetUsers", "Institucion_InstitucionId1");
            AddForeignKey("dbo.AspNetUsers", "Departamento_DepartamentoId", "dbo.Departamento", "DepartamentoId");
            AddForeignKey("dbo.AspNetUsers", "Departamento_DepartamentoId1", "dbo.Departamento", "DepartamentoId");
            AddForeignKey("dbo.AspNetUsers", "Institucion_InstitucionId", "dbo.Institucion", "InstitucionId");
            AddForeignKey("dbo.AspNetUsers", "Institucion_InstitucionId1", "dbo.Institucion", "InstitucionId");
            DropColumn("dbo.Beneficiario", "Email");
            DropColumn("dbo.Beneficiario", "Telefono");
            DropColumn("dbo.Beneficiario", "Celular");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Beneficiario", "Celular", c => c.String(maxLength: 20));
            AddColumn("dbo.Beneficiario", "Telefono", c => c.String(maxLength: 20));
            AddColumn("dbo.Beneficiario", "Email", c => c.String(nullable: false, maxLength: 150));
            DropForeignKey("dbo.TipoProcedencia", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoProcedencia", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoProcedencia", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoAsunto", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoAsunto", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoAsunto", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Procedencia", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Procedencia", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Procedencia", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Estatus", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Estatus", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Estatus", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Canalizacion", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetCanalizacion", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetCanalizacion", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetCanalizacion", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetCanalizacion", "CanalizacionId", "dbo.Canalizacion");
            DropForeignKey("dbo.Canalizacion", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Canalizacion", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitud", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitud", "InstitucionId", "dbo.Institucion");
            DropForeignKey("dbo.Solicitud", "EscuelaId", "dbo.Escuela");
            DropForeignKey("dbo.Solicitud", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.Solicitud", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitud", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitud", "BeneficiarioId", "dbo.Beneficiario");
            DropForeignKey("dbo.AspNetUsers", "Institucion_InstitucionId1", "dbo.Institucion");
            DropForeignKey("dbo.AspNetUsers", "Institucion_InstitucionId", "dbo.Institucion");
            DropForeignKey("dbo.AspNetUsers", "Departamento_DepartamentoId1", "dbo.Departamento");
            DropForeignKey("dbo.AspNetUsers", "Departamento_DepartamentoId", "dbo.Departamento");
            DropIndex("dbo.TipoProcedencia", new[] { "DeletedBy" });
            DropIndex("dbo.TipoProcedencia", new[] { "UpdatedBy" });
            DropIndex("dbo.TipoProcedencia", new[] { "CreatedBy" });
            DropIndex("dbo.TipoAsunto", new[] { "DeletedBy" });
            DropIndex("dbo.TipoAsunto", new[] { "UpdatedBy" });
            DropIndex("dbo.TipoAsunto", new[] { "CreatedBy" });
            DropIndex("dbo.Procedencia", new[] { "DeletedBy" });
            DropIndex("dbo.Procedencia", new[] { "UpdatedBy" });
            DropIndex("dbo.Procedencia", new[] { "CreatedBy" });
            DropIndex("dbo.Estatus", new[] { "DeletedBy" });
            DropIndex("dbo.Estatus", new[] { "UpdatedBy" });
            DropIndex("dbo.Estatus", new[] { "CreatedBy" });
            DropIndex("dbo.DetCanalizacion", new[] { "DeletedBy" });
            DropIndex("dbo.DetCanalizacion", new[] { "UpdatedBy" });
            DropIndex("dbo.DetCanalizacion", new[] { "CreatedBy" });
            DropIndex("dbo.DetCanalizacion", new[] { "CanalizacionId" });
            DropIndex("dbo.Canalizacion", new[] { "DeletedBy" });
            DropIndex("dbo.Canalizacion", new[] { "UpdatedBy" });
            DropIndex("dbo.Canalizacion", new[] { "CreatedBy" });
            DropIndex("dbo.Solicitud", new[] { "DeletedBy" });
            DropIndex("dbo.Solicitud", new[] { "UpdatedBy" });
            DropIndex("dbo.Solicitud", new[] { "CreatedBy" });
            DropIndex("dbo.Solicitud", new[] { "InstitucionId" });
            DropIndex("dbo.Solicitud", new[] { "DepartamentoId" });
            DropIndex("dbo.Solicitud", new[] { "BeneficiarioId" });
            DropIndex("dbo.Solicitud", new[] { "EscuelaId" });
            DropIndex("dbo.AspNetUsers", new[] { "Institucion_InstitucionId1" });
            DropIndex("dbo.AspNetUsers", new[] { "Institucion_InstitucionId" });
            DropIndex("dbo.AspNetUsers", new[] { "Departamento_DepartamentoId1" });
            DropIndex("dbo.AspNetUsers", new[] { "Departamento_DepartamentoId" });
            AlterColumn("dbo.Beneficiario", "Nombre", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AspNetUsers", "Institucion_InstitucionId1");
            DropColumn("dbo.AspNetUsers", "Institucion_InstitucionId");
            DropColumn("dbo.AspNetUsers", "Departamento_DepartamentoId1");
            DropColumn("dbo.AspNetUsers", "Departamento_DepartamentoId");
            DropColumn("dbo.AspNetUsers", "DepartamentoId");
            DropColumn("dbo.AspNetUsers", "InstitucionId");
            DropColumn("dbo.AspNetUsers", "Imagen");
            DropColumn("dbo.AspNetUsers", "ApellidoMaterno");
            DropColumn("dbo.AspNetUsers", "ApellidoPaterno");
            DropColumn("dbo.AspNetUsers", "Nombre");
            DropTable("dbo.TipoProcedencia",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TipoProcedencia_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TipoAsunto",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TipoAsunto_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Procedencia",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Procedencia_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Estatus",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Estatus_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DetCanalizacion",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DetCanalizacion_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Canalizacion",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Canalizacion_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Solicitud",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Solicitud_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
