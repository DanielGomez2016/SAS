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

        public DbSet<Beneficiary> Beneficiary { get; set; }
        public DbSet<College> College { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<DetailRecord> DetailRecord { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<EducationLevel> EducationLevel { get; set; }
        public DbSet<Institution> Institution { get; set; }
        public DbSet<Locality> Locality { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Provenance> Provenance { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<Requirements> Requirements { get; set; }
        public DbSet<Solicitude> Solicitude { get; set; }
        public DbSet<SystemAccess> SystemAccess { get; set; }
        public DbSet<SystemAccessRoles> SystemAccessRoles { get; set; }
        public DbSet<Township> Township { get; set; }
        public DbSet<TypeOrigin> TypeOrigin { get; set; }
        public DbSet<TypeSubject> TypeSubject { get; set; }
        public DbSet<Validation> Validation { get; set; }


        public ApplicationDbContext()
            : base(string.Format("name={0}", Parameters.AppContext))
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            AddMyFilters(ref modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)));
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Beneficiary

            modelBuilder.Entity<Beneficiary>()
                        .Property(x => x.Name)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Beneficiary>()
                        .Property(x => x.address)
                        .HasMaxLength(100)
                        .IsRequired();

            #endregion

            #region College

            modelBuilder.Entity<College>()
                        .Property(x => x.Name)
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<College>()
                            .Property(x => x.Code)
                            .HasMaxLength(25)
                            .IsRequired();

            modelBuilder.Entity<College>()
                        .Property(x => x.Address)
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<College>()
                        .Property(x => x.Geox)
                        .HasMaxLength(8000)
                        .IsOptional();

            modelBuilder.Entity<College>()
                        .Property(x => x.Geoy)
                        .HasMaxLength(8000)
                        .IsOptional();

            modelBuilder.Entity<College>()
                        .Property(x => x.Postcode)
                        .IsOptional();

            modelBuilder.Entity<College>()
                        .Property(x => x.Colony)
                        .HasMaxLength(100)
                        .IsOptional();

            modelBuilder.Entity<College>()
                        .Property(x => x.Marginalization)
                        .HasMaxLength(100)
                        .IsOptional();

            modelBuilder.Entity<College>()
                        .Property(x => x.Population)
                        .HasMaxLength(100)
                        .IsOptional();

            modelBuilder.Entity<College>()
                        .Property(x => x.Zone)
                        .IsOptional();

            #endregion

            #region Contact

            modelBuilder.Entity<Contact>()
                        .Property(x => x.Name)
                        .HasMaxLength(75)
                        .IsRequired();

            modelBuilder.Entity<Contact>()
                        .Property(x => x.Email)
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Contact>()
                        .Property(x => x.Phone)
                        .HasMaxLength(20)
                        .IsOptional();

            modelBuilder.Entity<Contact>()
                        .Property(x => x.CelPhone)
                        .HasMaxLength(20)
                        .IsOptional();

            #endregion

            #region Department

            modelBuilder.Entity<Department>()
                        .Property(x => x.Name)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Department>()
                        .Property(x => x.Manager)
                        .HasMaxLength(75)
                        .IsRequired();

            modelBuilder.Entity<Department>()
                        .Property(x => x.Description)
                        .HasColumnType("text")
                        .IsOptional();

            modelBuilder.Entity<Department>()
                        .Property(x => x.Extension)
                        .HasMaxLength(10)
                        .IsRequired();

            #endregion

            #region Detail Record

            modelBuilder.Entity<DetailRecord>()
                        .Property(x => x.RecordDate)
                        .IsRequired();

            modelBuilder.Entity<DetailRecord>()
                        .Property(x => x.Comment)
                        .HasColumnType("text")
                        .IsRequired();

            #endregion

            #region Document

            modelBuilder.Entity<Document>()
                        .Property(x => x.Name)
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Document>()
                        .Property(x => x.Type)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Document>()
                        .Property(x => x.File)
                        .HasMaxLength(8000)
                        .IsRequired();

            #endregion

            #region Education lavel

            modelBuilder.Entity<EducationLevel>()
                        .Property(x => x.Level)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<EducationLevel>()
                        .Property(x => x.Description)
                        .HasColumnType("text")
                        .IsRequired();

            #endregion

            #region Institution

            modelBuilder.Entity<Institution>()
                        .Property(x => x.Name)
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Institution>()
                        .Property(x => x.Acronym)
                        .HasMaxLength(15)
                        .IsRequired();

            modelBuilder.Entity<Institution>()
                        .Property(x => x.Manager)
                        .HasMaxLength(150)
                        .IsRequired();

            modelBuilder.Entity<Institution>()
                        .Property(x => x.Description)
                        .HasColumnType("text")
                        .IsOptional();

            modelBuilder.Entity<Institution>()
                        .Property(x => x.Phone)
                        .HasMaxLength(15)
                        .IsRequired();

            modelBuilder.Entity<Institution>()
                        .Property(x => x.extension)
                        .HasMaxLength(50)
                        .IsRequired();

            #endregion

            #region Locality

            modelBuilder.Entity<Locality>()
                        .Property(x => x.Name)
                        .HasMaxLength(75)
                        .IsRequired();

            #endregion

            #region Provenance

            modelBuilder.Entity<Provenance>()
                        .Property(x => x.Name)
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Provenance>()
                        .Property(x => x.Address)
                        .HasMaxLength(75)
                        .IsRequired();

            #endregion

            #region Record



            #endregion

            #region Requeriments



            #endregion

            #region Solicitude

            modelBuilder.Entity<Solicitude>()
                        .Property(x => x.Folio)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Solicitude>()
                        .Property(x => x.DeliverDate)
                        .IsRequired();

            modelBuilder.Entity<Solicitude>()
                        .Property(x => x.Affair)
                        .HasColumnType("text")
                        .IsRequired();

            modelBuilder.Entity<Solicitude>()
                        .Property(x => x.GeneralGoal)
                        .HasColumnType("text")
                        .IsOptional();

            modelBuilder.Entity<Solicitude>()
                        .Property(x => x.ValidationDate)
                        .IsOptional();

            #endregion

            #region System Access

            modelBuilder.Entity<SystemAccess>()
                        .Property(x => x.Controller)
                        .HasMaxLength(75)
                        .IsRequired();

            modelBuilder.Entity<SystemAccess>()
                        .Property(x => x.ActionController)
                        .HasMaxLength(75)
                        .IsRequired();

            modelBuilder.Entity<SystemAccess>()
                        .Property(x => x.DescriptionAccess)
                        .HasMaxLength(250)
                        .IsRequired();

            modelBuilder.Entity<SystemAccess>()
                        .Property(x => x.Status)
                        .IsRequired();

            modelBuilder.Entity<SystemAccessRoles>()
                        .HasKey(t => new {
                            t.InstitutionId,
                            t.RoleId,
                            t.Id
                        });

            #endregion

            #region Township

            modelBuilder.Entity<Township>()
                        .Property(x => x.Name)
                        .HasMaxLength(100)
                        .IsRequired();

            #endregion

            #region Type Origin

            modelBuilder.Entity<TypeOrigin>()
                        .Property(x => x.TOrigin)
                        .HasMaxLength(100)
                        .IsRequired();

            #endregion

            #region Type Subject

            modelBuilder.Entity<TypeSubject>()
                        .Property(x => x.TSubject)
                        .HasMaxLength(100)
                        .IsRequired();

            #endregion

            #region Validation



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
