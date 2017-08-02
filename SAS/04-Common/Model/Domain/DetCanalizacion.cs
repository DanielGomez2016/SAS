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
    public class DetCanalizacion : AuditEntity, ISoftDeleted
    {
        public int DetCanalizacionId { get; set; }
        public DateTime FechaCanalizacion { get; set; }
        public string Comentario { get; set; }
        public string AtiendeId { get; set; }

        public int CanalizacionId { get; set; }
        public Canalizacion Canalizacion { get; set; }

        public bool Deleted { get; set; }

    }
}
