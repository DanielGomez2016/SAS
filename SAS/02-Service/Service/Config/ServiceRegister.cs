using LightInject;
using Model.Auth;
using Model.Domain;
using Persistence.DbContextScope;
using Persistence.Repository;

namespace Service.Config
{
    public class ServiceRegister : ICompositionRoot
    {               
        public void Compose(IServiceRegistry container)
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();

            container.Register<IDbContextScopeFactory>((x) => new DbContextScopeFactory(null));
            container.Register<IAmbientDbContextLocator, AmbientDbContextLocator>(new PerScopeLifetime());

            container.Register<IRepository<ApplicationUser>>((x) => new Repository<ApplicationUser>(ambientDbContextLocator));
            container.Register<IRepository<ApplicationRole>>((x) => new Repository<ApplicationRole>(ambientDbContextLocator));
            container.Register<IRepository<ApplicationUserRole>>((x) => new Repository<ApplicationUserRole>(ambientDbContextLocator));
            container.Register<IRepository<SystemAccess>>((x) => new Repository<SystemAccess>(ambientDbContextLocator));
            container.Register<IRepository<SystemAccessRoles>>((x) => new Repository<SystemAccessRoles>(ambientDbContextLocator));
            container.Register<IRepository<Institution>>((x) => new Repository<Institution>(ambientDbContextLocator));
            container.Register<IRepository<Member>>((x) => new Repository<Member>(ambientDbContextLocator));
            container.Register<IRepository<College>>((x) => new Repository<College>(ambientDbContextLocator));
            container.Register<IRepository<Contact>>((x) => new Repository<Contact>(ambientDbContextLocator));
            container.Register<IRepository<Township>>((x) => new Repository<Township>(ambientDbContextLocator));
            container.Register<IRepository<Locality>>((x) => new Repository<Locality>(ambientDbContextLocator));



            container.Register<IUserService, UserService>();
            container.Register<ISystemAccessService, SystemAccessService>();
            container.Register<IInstitutionService, InstitutionService>();
            container.Register<IMemberService, MemberService>();
            container.Register<ICollegeService, CollegeService>();
            container.Register<ITownshipService, TownshipService>();




        }
    }
}
