using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Estatus : AuditEntity, ISoftDeleted
    {
        public int EstatusId { get; set; }
        public string Nombre { get; set; }


        public bool Deleted { get; set; }

    }
}
