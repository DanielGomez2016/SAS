using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Municipio : AuditEntity, ISoftDeleted
    {
        public int MunicipioId { get; set; }
        public string Nombre { get; set; }

        public bool Deleted { get; set; }

        public List<Localidad> Localidades { get; set; }
    }
}
