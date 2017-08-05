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
    public class Departamento : AuditEntity, ISoftDeleted
    {
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public string Titular { get; set; }
        public string Descripcion { get; set; }
        public string Extencion { get; set; }

        public bool Deleted { get; set; }

        public int InstitucionId { get; set; }
        public Institucion Institucion { get; set; }

        public List<DetCanalizacion> Canalizaciones { get; set; }

    }
}
