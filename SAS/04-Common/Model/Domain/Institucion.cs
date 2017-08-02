using Common.CustomFilters;
using Model.Auth;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Institucion : AuditEntity, ISoftDeleted
    {
        public int InstitucionId { get; set; }
        public string Nombre { get; set; }
        public string Siglas { get; set; }
        public string Titular { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public string Extencion { get; set; }

        public bool Deleted { get; set; }


        public List<AccesoSistemaRol> AccesosRol { get; set; }
        public List<Departamento> Departamentos { get; set; }

        public List<ApplicationUser> ApplicationUser { get; set; }

    }
}
