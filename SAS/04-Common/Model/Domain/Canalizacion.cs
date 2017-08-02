using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Canalizacion : AuditEntity, ISoftDeleted
    {
        public int CanalizacionId { get; set; }
        public bool Validacion { get; set; }

        public List<DetCanalizacion> DetCanalizacion { get; set; }

        public bool Deleted { get; set; }
    }
}
