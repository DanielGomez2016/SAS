using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Procedencia : AuditEntity, ISoftDeleted
    {
        public int ProcedenciaId { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }

        public int TipoProcedenciaId { get; set; }
        public TipoProcedencia Tipo{ get; set; }

        public List<Solicitud> Solicitudes { get; set; }

        public List<Contacto> Contactos { get; set; }

        public int LocalidadId { get; set; }
        public Localidad Localidad { get; set; }

        public bool Deleted { get; set; }
    }
}
