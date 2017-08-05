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
    public class Contact : AuditEntity, ISoftDeleted
    {
        public int ContactId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Display(Name = "Celular")]
        public string CelPhone { get; set; }

        public Beneficiary Beneficiary { get; set; }
        public int BeneficiaryId { get; set; }

        public College College { get; set; }
        public int CollegeId { get; set; }

        public Provenance Provenance { get; set; }
        public int ProvenanceId { get; set; }

        public bool Deleted { get; set; }

    }
}
