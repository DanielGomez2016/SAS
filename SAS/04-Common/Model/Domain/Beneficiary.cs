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
    public class Beneficiary : AuditEntity, ISoftDeleted
    {
        public int BeneficiaryId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Direccion")]
        public string address { get; set; }

        public Locality Locality { get; set; }
        public int LocalityId { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public ICollection<Solicitude> Solicitudes { get; set; }
        public bool Deleted { get; set; }
    }
}
