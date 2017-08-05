using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class TypeSubject : AuditEntity, ISoftDeleted
    {
        public int TypeSubjectId { get; set; }

        [Display(Name = "Tipo Asunto")]
        public string TSubject { get; set; }

        public ICollection<Solicitude> Solicitudes { get; set; }

        public bool Deleted { get; set; }

    }
}
