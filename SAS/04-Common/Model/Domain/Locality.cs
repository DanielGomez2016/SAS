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
    public class Locality : AuditEntity, ISoftDeleted
    {
        public int LocalityId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public string code { get; set; }

        public string latitude { get; set; }

        public string Length { get; set; }

        public int Altitude { get; set; }

        public ICollection<College> Collages { get; set; }

        public ICollection<Beneficiary> Beneficiary { get; set; }

        public Township Township { get; set; }
        public int TownshipId { get; set; }

        public bool Deleted { get ; set; }
    }
}
