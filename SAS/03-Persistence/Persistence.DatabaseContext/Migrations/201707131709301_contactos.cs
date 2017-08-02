namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class contactos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beneficiario",
                c => new
                    {
                        BeneficiarioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Domicilio = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 150),
                        Telefono = c.String(maxLength: 20),
                        Celular = c.String(maxLength: 20),
                        Deleted = c.Boolean(nullable: false),
                        LocalidadId = c.Int(nullable: false),
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
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId, cascadeDelete: true)
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
                        Deleted = c.Boolean(nullable: false),
                        EscuelaId = c.Int(nullable: false),
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
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Escuela", t => t.EscuelaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.EscuelaId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beneficiario", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacto", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacto", "EscuelaId", "dbo.Escuela");
            DropForeignKey("dbo.Contacto", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacto", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Beneficiario", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Beneficiario", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Beneficiario", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Contacto", new[] { "DeletedBy" });
            DropIndex("dbo.Contacto", new[] { "UpdatedBy" });
            DropIndex("dbo.Contacto", new[] { "CreatedBy" });
            DropIndex("dbo.Contacto", new[] { "EscuelaId" });
            DropIndex("dbo.Beneficiario", new[] { "DeletedBy" });
            DropIndex("dbo.Beneficiario", new[] { "UpdatedBy" });
            DropIndex("dbo.Beneficiario", new[] { "CreatedBy" });
            DropIndex("dbo.Beneficiario", new[] { "LocalidadId" });
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
        }
    }
}
