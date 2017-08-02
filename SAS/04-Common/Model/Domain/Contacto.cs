using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Contacto : AuditEntity, ISoftDeleted
    {
        public int ContactoId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }

        public int EscuelaId { get; set; }
        public Escuela Escuela { get; set; }

        public bool Deleted { get; set; }

    }
}
