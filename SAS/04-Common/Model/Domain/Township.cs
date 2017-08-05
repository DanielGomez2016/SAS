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
    public class Township : AuditEntity, ISoftDeleted
    {
        public int TownshipId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public ICollection<Locality> Localities { get; set; }

        public bool Deleted { get; set; }

    }
}
