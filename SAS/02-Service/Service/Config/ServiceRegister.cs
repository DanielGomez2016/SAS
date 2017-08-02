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


            container.Register<IRepository<Course>>((x) => new Repository<Course>(ambientDbContextLocator));
            container.Register<IRepository<Student>>((x) => new Repository<Student>(ambientDbContextLocator));
            container.Register<IRepository<StudentPerCourse>>((x) => new Repository<StudentPerCourse>(ambientDbContextLocator));


            container.Register<IRepository<AccesoSistema>>((x) => new Repository<AccesoSistema>(ambientDbContextLocator));
            container.Register<IRepository<AccesoSistemaRol>>((x) => new Repository<AccesoSistemaRol>(ambientDbContextLocator));
            container.Register<IRepository<Beneficiario>>((x) => new Repository<Beneficiario>(ambientDbContextLocator));
            container.Register<IRepository<Departamento>>((x) => new Repository<Departamento>(ambientDbContextLocator));
            container.Register<IRepository<Email>>((x) => new Repository<Email>(ambientDbContextLocator));
            container.Register<IRepository<Estatus>>((x) => new Repository<Estatus>(ambientDbContextLocator));
            container.Register<IRepository<Institucion>>((x) => new Repository<Institucion>(ambientDbContextLocator));
            container.Register<IRepository<Localidad>>((x) => new Repository<Localidad>(ambientDbContextLocator));
            container.Register<IRepository<Municipio>>((x) => new Repository<Municipio>(ambientDbContextLocator));
            container.Register<IRepository<NivelEducativo>>((x) => new Repository<NivelEducativo>(ambientDbContextLocator));
            container.Register<IRepository<Escuela>>((x) => new Repository<Escuela>(ambientDbContextLocator));
            container.Register<IRepository<Contacto>>(x => new Repository<Contacto>(ambientDbContextLocator));


            container.Register<IStudentService, StudentService>();
            container.Register<IStudentPerCourseService, StudentPerCourseService>();
            container.Register<ICourseService, CourseService>();


            container.Register<IUserService, UserService>();
            container.Register<IEscuelaService, EscuelaService>();
            container.Register<IContactoService, ContactoService>();
            container.Register<IAccesoSistemaService, AccesoSistemaService>();
            container.Register<IAccesoSistemaRolService, AccesoSistemaRolService>();
            container.Register<IBeneficiarioService, BeneficiarioService>();
            container.Register<IDepartamentoService, DepartamentoService>();
            container.Register<IInstitucionService, InstitucionService>();
            container.Register<ILocalidadService, LocalidadService>();
            container.Register<IMunicipioService, MunicipioService>();
            container.Register<INivelEducativoService, NivelEducativoService>();

        }
    }
}
