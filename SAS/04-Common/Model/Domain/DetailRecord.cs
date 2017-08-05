using Common;
using Common.CustomFilters;
using Model.Auth;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class DetailRecord : AuditEntity, ISoftDeleted
    {
        public int DetailRecordId { get; set; }

        [Display(Name = "Fecha Historial")]
        public DateTime RecordDate { get; set; }

        [Display(Name = "Comentario")]
        public string Comment { get; set; }

        [Display(Name = "Estatus")]
        public Enums.Status Status { get; set; }

        public Record Record { get; set; }
        public int RecordId { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("UserAssignsId")]
        public ApplicationUser UserAssigns { get; set; }
        public string UserAssignsId { get; set; }

        [ForeignKey("UserAttendsId")]
        public ApplicationUser UserAttends { get; set; }
        public string UserAttendsId { get; set; }

        public ICollection<Document> Documents { get; set; }

        public bool Deleted { get; set; }

    }
}
