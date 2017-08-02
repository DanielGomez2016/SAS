using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class NivelEducativo : AuditEntity, ISoftDeleted
    {
        public int NivelEducativoId { get; set; }
        public string Nivel { get; set; }
        public string Descripcion { get; set; }

        public List<Escuela> Escuelas { get; set; }

        public bool Deleted { get; set; }


    }
}
