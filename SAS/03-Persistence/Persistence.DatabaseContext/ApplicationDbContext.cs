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
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
        public DbSet<AccesoSistema> AccesoSistema { get; set; }
        public DbSet<AccesoSistemaRol> AccesoSistemaRol { get; set; }
        public DbSet<Beneficiario> Beneficiario { get; set; }
        public DbSet<Canalizacion> Canalizacion { get; set; }
        public DbSet<Contacto> Contacto { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<DetCanalizacion> DetCanalizacion { get; set; }
        public DbSet<Documentos> Documentos { get; set; }
        public DbSet<Escuela> Escuela { get; set; }
        public DbSet<Institucion> Institucion { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<NivelEducativo> NivelEducativo { get; set; }
        public DbSet<Procedencia> Procedencia { get; set; }
        public DbSet<Solicitud> Solicitud { get; set; }
        public DbSet<TipoAsunto> TipoAsunto { get; set; }
        public DbSet<TipoProcedencia> TipoProcedencia { get; set; }


        public ApplicationDbContext()
            : base(string.Format("name={0}", Parameters.AppContext))
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            AddMyFilters(ref modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)));

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
