using Common;
using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Escuela : AuditEntity, ISoftDeleted
    {
        public int EscuelaId { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Domicilio { get; set; }
        public string Turno { get; set; }
        public string Geox { get; set; }
        public string Geoy { get; set; }
        public int CodigoPostal { get; set; }
        public string Colonia { get; set; }
        public string Marginacion { get; set; }
        public string Poblacion { get; set; }
        public int Zona { get; set; }

        public Enums.StatusEscolar Estatus { get; set; }

        public List<Contacto> Contactos { get; set; }

        public int NivelEducativoId { get; set; }
        public NivelEducativo NivelEducativo { get; set; }

        public int LocalidadId { get; set; }
        public Localidad Localidad { get; set; }

        public List<Solicitud> Solicitudes { get; set; }

        public bool Deleted { get; set; }

    }
}
