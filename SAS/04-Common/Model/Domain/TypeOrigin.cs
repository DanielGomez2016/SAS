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
    public class TypeOrigin : AuditEntity, ISoftDeleted
    {
        public int TypeOriginId { get; set; }

        [Display(Name = "Tipo Procedencia")]
        public string TOrigin { get; set; }

        public ICollection<Provenance> Provenances { get; set; }

        public bool Deleted { get; set; }

    }
}
