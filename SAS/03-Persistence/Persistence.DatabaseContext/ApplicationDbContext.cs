using Microsoft.AspNet.Identity.EntityFramework;
using Common;
using System.Data.Entity;
using Model.Domain;
using System.Reflection;
using System.Linq;
using Model.Helper;
using System;
using EntityFramework.DynamicFilters;
using Common.CustomFilters;
using Model.Auth;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistence.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRole { get; set; }
        public virtual DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

        public virtual DbSet<Student> Student { get;set; }
        public virtual DbSet<StudentPerCourse> StudentPerCourse { get; set; }
        public virtual DbSet<Course> Course { get; set; }

        public virtual DbSet<AccesoSistema> AccesoSistema { get; set; }
        public virtual DbSet<Institucion> Institucion { get; set; }
        public virtual DbSet<AccesoSistemaRol> AccesoSistemaRol { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<NivelEducativo> NivelEducativo {get;set;}
        public virtual DbSet<Escuela> Escuela { get; set; }
        public virtual DbSet<Beneficiario> Beneficiario { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Canalizacion> Canalizacion { get; set; }
        public virtual DbSet<DetCanalizacion> DetCanalizacion { get; set; }
        public virtual DbSet<Procedencia> Procedencia { get; set; }
        public virtual DbSet<TipoProcedencia> TipoProcedencia { get; set; }
        public virtual DbSet<TipoAsunto> TipoAsunto { get; set; }
        public virtual DbSet<Estatus> Estatus { get; set; }


        public ApplicationDbContext()
            : base(string.Format("name={0}", Parameters.AppContext))
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            AddMyFilters(ref modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)));

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region AccesoSistema

            modelBuilder.Entity<AccesoSistema>()
                        .Property(x => x.Controlador)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<AccesoSistema>()
                        .Property(x => x.Accion)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<AccesoSistema>()
                        .Property(x => x.Descripcion)
                        .HasMaxLength(500)
                        .IsRequired();

            modelBuilder.Entity<AccesoSistema>()
                        .Property(x => x.Activo)
                        .IsRequired();

            #endregion

            #region AccesoSistemaRol

            modelBuilder.Entity<AccesoSistemaRol>()
                        .HasKey(x => new { x.AccesoSistemaId, x.Id, x.InstitucionId});

            #endregion

            #region Institucion

            modelBuilder.Entity<Institucion>()
                        .Property(x => x.Nombre)
                        .HasMaxLength(150)
                        .IsRequired();

            modelBuilder.Entity<Institucion>()
                        .Property(x => x.Siglas)
                        .HasMaxLength(20)
                        .IsRequired();

            modelBuilder.Entity<Institucion>()
                        .Property(x => x.Titular)
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Institucion>()
                        .Property(x => x.Descripcion)
                        .HasColumnType("text")
                        .IsRequired();

            modelBuilder.Entity<Institucion>()
                        .Property(x => x.Telefono)
                        .HasMaxLength(10)
                        .IsRequired();

            modelBuilder.Entity<Institucion>()
                        .Property(x => x.Extencion)
                        .HasMaxLength(10)
                        .IsRequired();

            #endregion

            #region Departamento

            modelBuilder.Entity<Departamento>()
                        .Property(x => x.Nombre)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Departamento>()
                        .Property(x => x.Titular)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Departamento>()
                        .Property(x => x.Descripcion)
                        .HasColumnType("text")
                        .IsRequired();

            modelBuilder.Entity<Departamento>()
                        .Property(x => x.Extencion)
                        .IsRequired();

            #endregion

            #region Municipio

            modelBuilder.Entity<Municipio>()
                        .Property(x => x.Nombre)
                        .HasMaxLength(50)
                        .IsRequired();

            #endregion

            #region Localidad

            modelBuilder.Entity<Localidad>()
                        .Property(x => x.Nombre)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Localidad>()
                        .Property(x => x.ClaveLocalidad)
                        .HasMaxLength(20)
                        .IsRequired();

            modelBuilder.Entity<Localidad>()
                        .Property(x => x.Latitud)
                        .HasMaxLength(50);

            modelBuilder.Entity<Localidad>()
                        .Property(x => x.Longitud)
                        .HasMaxLength(50);

            modelBuilder.Entity<Localidad>()
                        .Property(x => x.Altitud);

            #endregion

            #region Nivel Educativo

            modelBuilder.Entity<NivelEducativo>()
                        .Property(x => x.Nivel)
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<NivelEducativo>()
                        .Property(x => x.Descripcion)
                        .HasColumnType("text")
                        .IsRequired();

            #endregion

            #region Escuela

            modelBuilder.Entity<Escuela>()
                        .Property(x => x.Nombre)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Escuela>()
                        .Property(x => x.Clave)
                        .HasMaxLength(150)
                        .IsRequired();

            modelBuilder.Entity<Escuela>()
                        .Property(x => x.Domicilio)
                        .HasMaxLength(150);

            modelBuilder.Entity<Escuela>()
                        .Property(x => x.Turno)
                        .HasMaxLength(150);

            modelBuilder.Entity<Escuela>()
                        .Property(x => x.Geox)
                        .HasMaxLength(500);

            modelBuilder.Entity<Escuela>()
                        .Property(x => x.Geoy)
                        .HasMaxLength(500);

            modelBuilder.Entity<Escuela>()
                        .Property(x => x.Colonia)
                        .HasMaxLength(100);

            modelBuilder.Entity<Escuela>()
                        .Property(x => x.Marginacion)
                        .HasMaxLength(50);

            modelBuilder.Entity<Escuela>()
                        .Property(x => x.Poblacion)
                        .HasMaxLength(50);

            #endregion

            #region Beneficiario

            modelBuilder.Entity<Beneficiario>()
                         .Property(x => x.Nombre)
                         .HasMaxLength(150)
                         .IsRequired();

            modelBuilder.Entity<Beneficiario>()
                        .Property(x => x.Domicilio)
                        .HasMaxLength(150)
                        .IsRequired();

            #endregion

            #region Solicitud

            modelBuilder.Entity<Solicitud>()
                         .Property(x => x.Asunto)
                         .HasColumnType("text")
                         .IsRequired();

            modelBuilder.Entity<Solicitud>()
                        .Property(x => x.Folio)
                        .HasMaxLength(25)
                        .IsRequired();

            modelBuilder.Entity<Solicitud>()
                        .Property(x => x.FechaEntrega)
                        .IsRequired();

            modelBuilder.Entity<Solicitud>()
                        .Property(x => x.MetaGeneral)
                        .HasColumnType("text");

            modelBuilder.Entity<Solicitud>()
                        .Property(x => x.Programa)
                        .HasMaxLength(50)
                        .IsRequired();

            #endregion

            #region Canalizacion

            #endregion

            #region Canalizacion detalle

            modelBuilder.Entity<DetCanalizacion>()
                         .Property(x => x.Comentario)
                         .HasColumnType("text")
                         .IsRequired();

            #endregion

            #region Procedencia

            modelBuilder.Entity<Procedencia>()
                         .Property(x => x.Nombre)
                         .HasMaxLength(250)
                         .IsRequired();

            modelBuilder.Entity<Procedencia>()
                         .Property(x => x.Domicilio)
                         .HasMaxLength(250)
                         .IsRequired();

            #endregion

            #region Tipo Asunto

            modelBuilder.Entity<TipoAsunto>()
                         .Property(x => x.Asunto)
                         .HasMaxLength(250)
                         .IsRequired();

            #endregion

            #region Tipo Procendencia

            modelBuilder.Entity<TipoProcedencia>()
                         .Property(x => x.Tipo)
                         .HasMaxLength(250)
                         .IsRequired();

            #endregion

            #region Estatus

            modelBuilder.Entity<Estatus>()
                         .Property(x => x.Nombre)
                         .HasMaxLength(50)
                         .IsRequired();

            #endregion


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            MakeAudit();
            return base.SaveChanges();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        private void MakeAudit()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(
                x => x.Entity is AuditEntity
                    && (
                    x.State == EntityState.Added
                    || x.State == EntityState.Modified
                    || x.State == EntityState.Deleted
                )
            );

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AuditEntity;
                if (entity != null)
                {
                    var date = DateTime.Now;
                    var userId = CurrentUserHelper.Get != null ? CurrentUserHelper.Get.UserId : null;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = date;
                        entity.CreatedBy = userId;
                    }
                    else if (entity is ISoftDeleted && ((ISoftDeleted)entity).Deleted)
                    {
                        entity.DeletedAt = date;
                        entity.DeletedBy = userId;
                    }

                    Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;

                    entity.UpdatedAt = date;
                    entity.UpdatedBy = userId;
                }
            }
        }

        private void AddMyFilters(ref DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter(Enums.MyFilters.IsDeleted.ToString(), (ISoftDeleted ea) => ea.Deleted, false);
        }
    }
}
