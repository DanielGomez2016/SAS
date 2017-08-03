namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;

    public partial class sprintv10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccesoSistema",
                c => new
                {
                    AccesoSistemaId = c.Int(nullable: false, identity: true),
                    Controlador = c.String(),
                    Accion = c.String(),
                    Descripcion = c.String(),
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
                    Id = c.String(nullable: false, maxLength: 128),
                    InstitucionId = c.Int(nullable: false),
                    AccesoSistemaId = c.Int(nullable: false),
                    ApplicationRole_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccesoSistema", t => t.AccesoSistemaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.ApplicationRole_Id)
                .ForeignKey("dbo.Institucion", t => t.InstitucionId, cascadeDelete: true)
                .Index(t => t.InstitucionId)
                .Index(t => t.AccesoSistemaId)
                .Index(t => t.ApplicationRole_Id);

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
                    Extencion = c.String(),
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

            CreateTable(
                "dbo.Departamento",
                c => new
                {
                    DepartamentoId = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                    Titular = c.String(),
                    Descripcion = c.String(),
                    Extencion = c.String(),
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
                "dbo.DetCanalizacion",
                c => new
                {
                    DetCanalizacionId = c.Int(nullable: false, identity: true),
                    FechaCanalizacion = c.DateTime(nullable: false),
                    Comentario = c.String(),
                    CanalizacionId = c.Int(nullable: false),
                    Estatus = c.Int(nullable: false),
                    UserAsignaId = c.String(maxLength: 128),
                    UserAtiendeId = c.String(maxLength: 128),
                    DepartamentoId = c.Int(nullable: false),
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
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAsignaId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAtiendeId)
                .Index(t => t.CanalizacionId)
                .Index(t => t.UserAsignaId)
                .Index(t => t.UserAtiendeId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);

            CreateTable(
                "dbo.Canalizacion",
                c => new
                {
                    CanalizacionId = c.Int(nullable: false, identity: true),
                    Validacion = c.Boolean(nullable: false),
                    SolicitudId = c.Int(nullable: false),
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
                .ForeignKey("dbo.Solicitud", t => t.SolicitudId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.SolicitudId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);

            CreateTable(
                "dbo.Solicitud",
                c => new
                {
                    SolicitudId = c.Int(nullable: false, identity: true),
                    Folio = c.String(),
                    FechaEntrega = c.DateTime(nullable: false),
                    Asunto = c.String(),
                    MetaGeneral = c.String(),
                    FechaValidacion = c.DateTime(nullable: false),
                    Programa = c.String(),
                    Estatus = c.Int(nullable: false),
                    EscuelaId = c.Int(nullable: false),
                    BeneficiarioId = c.Int(nullable: false),
                    DepartamentoId = c.Int(nullable: false),
                    InstitucionId = c.Int(nullable: false),
                    ProcedenciaId = c.Int(nullable: false),
                    TipoAsuntoId = c.Int(nullable: false),
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
                .ForeignKey("dbo.Procedencia", t => t.ProcedenciaId, cascadeDelete: false)
                .ForeignKey("dbo.Escuela", t => t.EscuelaId, cascadeDelete: false)
                .ForeignKey("dbo.Beneficiario", t => t.BeneficiarioId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId, cascadeDelete: false)
                .ForeignKey("dbo.Institucion", t => t.InstitucionId, cascadeDelete: false)
                .ForeignKey("dbo.TipoAsunto", t => t.TipoAsuntoId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.EscuelaId)
                .Index(t => t.BeneficiarioId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.InstitucionId)
                .Index(t => t.ProcedenciaId)
                .Index(t => t.TipoAsuntoId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);

            CreateTable(
                "dbo.Beneficiario",
                c => new
                {
                    BeneficiarioId = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                    Domicilio = c.String(),
                    LocalidadId = c.Int(nullable: false),
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
                    { "DynamicFilter_Beneficiario_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.BeneficiarioId)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.LocalidadId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);

            CreateTable(
                "dbo.Contacto",
                c => new
                {
                    ContactoId = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                    Email = c.String(),
                    Telefono = c.String(),
                    Celular = c.String(),
                    EscuelaId = c.Int(nullable: false),
                    BeneficiarioId = c.Int(nullable: false),
                    ProcedenciaId = c.Int(nullable: false),
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
                    { "DynamicFilter_Contacto_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.ContactoId)
                .ForeignKey("dbo.Beneficiario", t => t.BeneficiarioId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Escuela", t => t.EscuelaId, cascadeDelete: true)
                .ForeignKey("dbo.Procedencia", t => t.ProcedenciaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.EscuelaId)
                .Index(t => t.BeneficiarioId)
                .Index(t => t.ProcedenciaId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);

            CreateTable(
                "dbo.Escuela",
                c => new
                {
                    EscuelaId = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                    Clave = c.String(),
                    Domicilio = c.String(),
                    Turno = c.String(),
                    Geox = c.String(),
                    Geoy = c.String(),
                    CodigoPostal = c.Int(nullable: false),
                    Colonia = c.String(),
                    Marginacion = c.String(),
                    Poblacion = c.String(),
                    Zona = c.Int(nullable: false),
                    Estatus = c.Int(nullable: false),
                    NivelEducativoId = c.Int(nullable: false),
                    LocalidadId = c.Int(nullable: false),
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
                    { "DynamicFilter_Escuela_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.EscuelaId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId, cascadeDelete: false)
                .ForeignKey("dbo.NivelEducativo", t => t.NivelEducativoId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.NivelEducativoId)
                .Index(t => t.LocalidadId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);

            CreateTable(
                "dbo.Localidad",
                c => new
                {
                    LocalidadId = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                    ClaveLocalidad = c.String(),
                    Latitud = c.String(),
                    Longitud = c.String(),
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
                    Nombre = c.String(),
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

            CreateTable(
                "dbo.Procedencia",
                c => new
                {
                    ProcedenciaId = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                    Domicilio = c.String(),
                    TipoProcedenciaId = c.Int(nullable: false),
                    LocalidadId = c.Int(nullable: false),
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
                .ForeignKey("dbo.Localidad", t => t.LocalidadId, cascadeDelete: false)
                .ForeignKey("dbo.TipoProcedencia", t => t.TipoProcedenciaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.TipoProcedenciaId)
                .Index(t => t.LocalidadId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);

            CreateTable(
                "dbo.TipoProcedencia",
                c => new
                {
                    TipoProcedenciaId = c.Int(nullable: false, identity: true),
                    Tipo = c.String(),
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

            CreateTable(
                "dbo.NivelEducativo",
                c => new
                {
                    NivelEducativoId = c.Int(nullable: false, identity: true),
                    Nivel = c.String(),
                    Descripcion = c.String(),
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
                    { "DynamicFilter_NivelEducativo_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.NivelEducativoId)
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
                    Asunto = c.String(),
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
                "dbo.Documentos",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                    Documento = c.Binary(),
                    Tipo = c.String(),
                    DetCanalizacionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetCanalizacion", t => t.DetCanalizacionId, cascadeDelete: true)
                .Index(t => t.DetCanalizacionId);

            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "Apellidos", c => c.String());
            AddColumn("dbo.AspNetUsers", "DepartamentoId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "DepartamentoId");
            AddForeignKey("dbo.AspNetUsers", "DepartamentoId", "dbo.Departamento", "DepartamentoId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.AccesoSistema", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AccesoSistema", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AccesoSistema", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Institucion", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Institucion", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Institucion", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Departamento_DepartamentoId1", "dbo.Departamento");
            DropForeignKey("dbo.Departamento", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Departamento", "InstitucionId", "dbo.Institucion");
            DropForeignKey("dbo.Departamento", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Departamento", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetCanalizacion", "UserAtiendeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetCanalizacion", "UserAsignaId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetCanalizacion", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documentos", "DetCanalizacionId", "dbo.DetCanalizacion");
            DropForeignKey("dbo.DetCanalizacion", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.DetCanalizacion", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetCanalizacion", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Canalizacion", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitud", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoAsunto", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitud", "TipoAsuntoId", "dbo.TipoAsunto");
            DropForeignKey("dbo.TipoAsunto", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoAsunto", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitud", "InstitucionId", "dbo.Institucion");
            DropForeignKey("dbo.Solicitud", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.Solicitud", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitud", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Canalizacion", "SolicitudId", "dbo.Solicitud");
            DropForeignKey("dbo.Beneficiario", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitud", "BeneficiarioId", "dbo.Beneficiario");
            DropForeignKey("dbo.Beneficiario", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Beneficiario", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacto", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Escuela", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitud", "EscuelaId", "dbo.Escuela");
            DropForeignKey("dbo.NivelEducativo", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Escuela", "NivelEducativoId", "dbo.NivelEducativo");
            DropForeignKey("dbo.NivelEducativo", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.NivelEducativo", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Localidad", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Procedencia", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoProcedencia", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Procedencia", "TipoProcedenciaId", "dbo.TipoProcedencia");
            DropForeignKey("dbo.TipoProcedencia", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoProcedencia", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solicitud", "ProcedenciaId", "dbo.Procedencia");
            DropForeignKey("dbo.Procedencia", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Procedencia", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Procedencia", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacto", "ProcedenciaId", "dbo.Procedencia");
            DropForeignKey("dbo.Municipio", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Localidad", "MunicipioId", "dbo.Municipio");
            DropForeignKey("dbo.Municipio", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Municipio", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Escuela", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Localidad", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Localidad", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Beneficiario", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Escuela", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Escuela", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacto", "EscuelaId", "dbo.Escuela");
            DropForeignKey("dbo.Contacto", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacto", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacto", "BeneficiarioId", "dbo.Beneficiario");
            DropForeignKey("dbo.DetCanalizacion", "CanalizacionId", "dbo.Canalizacion");
            DropForeignKey("dbo.Canalizacion", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Canalizacion", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Departamento_DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.AccesoSistemaRol", "InstitucionId", "dbo.Institucion");
            DropForeignKey("dbo.AccesoSistemaRol", "ApplicationRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AccesoSistemaRol", "AccesoSistemaId", "dbo.AccesoSistema");
            DropIndex("dbo.Documentos", new[] { "DetCanalizacionId" });
            DropIndex("dbo.TipoAsunto", new[] { "DeletedBy" });
            DropIndex("dbo.TipoAsunto", new[] { "UpdatedBy" });
            DropIndex("dbo.TipoAsunto", new[] { "CreatedBy" });
            DropIndex("dbo.NivelEducativo", new[] { "DeletedBy" });
            DropIndex("dbo.NivelEducativo", new[] { "UpdatedBy" });
            DropIndex("dbo.NivelEducativo", new[] { "CreatedBy" });
            DropIndex("dbo.TipoProcedencia", new[] { "DeletedBy" });
            DropIndex("dbo.TipoProcedencia", new[] { "UpdatedBy" });
            DropIndex("dbo.TipoProcedencia", new[] { "CreatedBy" });
            DropIndex("dbo.Procedencia", new[] { "DeletedBy" });
            DropIndex("dbo.Procedencia", new[] { "UpdatedBy" });
            DropIndex("dbo.Procedencia", new[] { "CreatedBy" });
            DropIndex("dbo.Procedencia", new[] { "LocalidadId" });
            DropIndex("dbo.Procedencia", new[] { "TipoProcedenciaId" });
            DropIndex("dbo.Municipio", new[] { "DeletedBy" });
            DropIndex("dbo.Municipio", new[] { "UpdatedBy" });
            DropIndex("dbo.Municipio", new[] { "CreatedBy" });
            DropIndex("dbo.Localidad", new[] { "DeletedBy" });
            DropIndex("dbo.Localidad", new[] { "UpdatedBy" });
            DropIndex("dbo.Localidad", new[] { "CreatedBy" });
            DropIndex("dbo.Localidad", new[] { "MunicipioId" });
            DropIndex("dbo.Escuela", new[] { "DeletedBy" });
            DropIndex("dbo.Escuela", new[] { "UpdatedBy" });
            DropIndex("dbo.Escuela", new[] { "CreatedBy" });
            DropIndex("dbo.Escuela", new[] { "LocalidadId" });
            DropIndex("dbo.Escuela", new[] { "NivelEducativoId" });
            DropIndex("dbo.Contacto", new[] { "DeletedBy" });
            DropIndex("dbo.Contacto", new[] { "UpdatedBy" });
            DropIndex("dbo.Contacto", new[] { "CreatedBy" });
            DropIndex("dbo.Contacto", new[] { "ProcedenciaId" });
            DropIndex("dbo.Contacto", new[] { "BeneficiarioId" });
            DropIndex("dbo.Contacto", new[] { "EscuelaId" });
            DropIndex("dbo.Beneficiario", new[] { "DeletedBy" });
            DropIndex("dbo.Beneficiario", new[] { "UpdatedBy" });
            DropIndex("dbo.Beneficiario", new[] { "CreatedBy" });
            DropIndex("dbo.Beneficiario", new[] { "LocalidadId" });
            DropIndex("dbo.Solicitud", new[] { "DeletedBy" });
            DropIndex("dbo.Solicitud", new[] { "UpdatedBy" });
            DropIndex("dbo.Solicitud", new[] { "CreatedBy" });
            DropIndex("dbo.Solicitud", new[] { "TipoAsuntoId" });
            DropIndex("dbo.Solicitud", new[] { "ProcedenciaId" });
            DropIndex("dbo.Solicitud", new[] { "InstitucionId" });
            DropIndex("dbo.Solicitud", new[] { "DepartamentoId" });
            DropIndex("dbo.Solicitud", new[] { "BeneficiarioId" });
            DropIndex("dbo.Solicitud", new[] { "EscuelaId" });
            DropIndex("dbo.Canalizacion", new[] { "DeletedBy" });
            DropIndex("dbo.Canalizacion", new[] { "UpdatedBy" });
            DropIndex("dbo.Canalizacion", new[] { "CreatedBy" });
            DropIndex("dbo.Canalizacion", new[] { "SolicitudId" });
            DropIndex("dbo.DetCanalizacion", new[] { "DeletedBy" });
            DropIndex("dbo.DetCanalizacion", new[] { "UpdatedBy" });
            DropIndex("dbo.DetCanalizacion", new[] { "CreatedBy" });
            DropIndex("dbo.DetCanalizacion", new[] { "DepartamentoId" });
            DropIndex("dbo.DetCanalizacion", new[] { "UserAtiendeId" });
            DropIndex("dbo.DetCanalizacion", new[] { "UserAsignaId" });
            DropIndex("dbo.DetCanalizacion", new[] { "CanalizacionId" });
            DropIndex("dbo.Departamento", new[] { "DeletedBy" });
            DropIndex("dbo.Departamento", new[] { "UpdatedBy" });
            DropIndex("dbo.Departamento", new[] { "CreatedBy" });
            DropIndex("dbo.Departamento", new[] { "InstitucionId" });
            DropIndex("dbo.AspNetUsers", new[] { "Departamento_DepartamentoId1" });
            DropIndex("dbo.AspNetUsers", new[] { "Departamento_DepartamentoId" });
            DropIndex("dbo.Institucion", new[] { "DeletedBy" });
            DropIndex("dbo.Institucion", new[] { "UpdatedBy" });
            DropIndex("dbo.Institucion", new[] { "CreatedBy" });
            DropIndex("dbo.AccesoSistemaRol", new[] { "ApplicationRole_Id" });
            DropIndex("dbo.AccesoSistemaRol", new[] { "AccesoSistemaId" });
            DropIndex("dbo.AccesoSistemaRol", new[] { "InstitucionId" });
            DropIndex("dbo.AccesoSistema", new[] { "DeletedBy" });
            DropIndex("dbo.AccesoSistema", new[] { "UpdatedBy" });
            DropIndex("dbo.AccesoSistema", new[] { "CreatedBy" });
            DropColumn("dbo.AspNetUsers", "Departamento_DepartamentoId1");
            DropColumn("dbo.AspNetUsers", "Departamento_DepartamentoId");
            DropColumn("dbo.AspNetUsers", "DepartamentoId");
            DropColumn("dbo.AspNetUsers", "Apellidos");
            DropColumn("dbo.AspNetUsers", "Nombre");
            DropTable("dbo.Documentos");
            DropTable("dbo.TipoAsunto",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TipoAsunto_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.NivelEducativo",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_NivelEducativo_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TipoProcedencia",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TipoProcedencia_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Procedencia",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Procedencia_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
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
            DropTable("dbo.Escuela",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Escuela_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Contacto",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Contacto_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Beneficiario",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Beneficiario_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Solicitud",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Solicitud_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Canalizacion",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Canalizacion_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DetCanalizacion",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DetCanalizacion_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Departamento",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Departamento_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
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
        }
    }
}
