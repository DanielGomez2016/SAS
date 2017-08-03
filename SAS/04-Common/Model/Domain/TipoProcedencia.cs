using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class TipoProcedencia : AuditEntity, ISoftDeleted
    {
        public int TipoProcedenciaId { get; set; }
        public string Tipo { get; set; }

        public List<Procedencia> Procedencia { get; set; }

        public bool Deleted { get; set; }
    }
}
