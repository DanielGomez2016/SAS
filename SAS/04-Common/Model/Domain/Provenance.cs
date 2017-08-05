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
    public class Provenance : AuditEntity, ISoftDeleted
    {
        public int ProvenanceId { get; set; }

        [Display(Name = "Nombre Procedencia")]
        public string Name { get; set; }

        [Display(Name = "Direccion")]
        public string Address { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public TypeOrigin TypeOrigin { get; set; }
        public int TypeOriginId { get; set; }

        public ICollection<Solicitude> Solicitudes { get; set; }

        public bool Deleted { get; set; }

    }
}
