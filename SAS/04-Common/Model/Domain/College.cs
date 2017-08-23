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
    public class College : AuditEntity, ISoftDeleted
    {
        public int CollegeId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "CCT")]
        public string Code { get; set; }

        [Display(Name = "Direccion")]
        public string Address { get; set; }

        [Display(Name = "Nombre")]
        public Enums.Turn Turn { get; set; }

        [Display(Name = "Coordenada x")]
        public string Geox { get; set; }

        [Display(Name = "Coordenada y")]
        public string Geoy { get; set; }

        [Display(Name = "Estatus")]
        public Enums.StatusCollege Status { get; set; }
        public int Postcode { get; set; }

        [Display(Name = "Colonia")]
        public string Colony { get; set; }

        [Display(Name = "Marginacion")]
        public string Marginalization { get; set; }

        [Display(Name = "Poblacion")]
        public string Population { get; set; }

        [Display(Name = "Zona")]
        public int Zone { get; set; }

        public Locality Locality { get; set; }
        public int LocalityId { get; set; }

        [ForeignKey("LevelId")]
        public EducationLevel EducationLevel { get; set; }
        public int LevelId { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public ICollection<Solicitude> Solicitudes { get; set; }

        public bool Deleted { get; set; }

    }
}
