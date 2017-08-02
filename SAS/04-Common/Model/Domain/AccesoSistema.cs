using Common.CustomFilters;
using Model.Auth;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class AccesoSistema : AuditEntity, ISoftDeleted
    {
        public int AccesoSistemaId { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public bool Deleted { get; set; }

        public List<AccesoSistemaRol> AccesosRol { get; set; }

    }
}
