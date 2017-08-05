using Common;
using Common.CustomFilters;
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
    public class Record : AuditEntity, ISoftDeleted
    {
        [Key, ForeignKey("Solicitude")]
        public int RecordId { get; set; }

        [Display(Name = "Estatus")]
        public Enums.Status Validation { get; set; }

        public Institution Institution { get; set; }
        public int InstitutionId { get; set; }

        public Solicitude Solicitude { get; set; }

        public ICollection<DetailRecord> Details { get; set; }

        public bool Deleted { get; set; }


    }
}
