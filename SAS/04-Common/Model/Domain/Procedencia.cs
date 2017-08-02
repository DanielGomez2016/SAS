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


        public bool Deleted { get; set; }
    }
}
