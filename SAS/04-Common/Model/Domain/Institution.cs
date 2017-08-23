using Common.CustomFilters;
using Model.Auth;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Institution : AuditEntity, ISoftDeleted
    {
        public int InstitutionId { get; set; }

        [Required]
        [Display(Name = "Nombre Institucion")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Siglas")]
        public string Acronym { get; set; }

        [Required]
        [Display(Name = "Titular")]
        public string Manager { get; set; }

        [Display(Name = "Descrpcion")]
        public string Description { get; set; }

        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Display(Name = "Extencion")]
        public string extension { get; set; }

        public ICollection<Department> Deparments { get; set; }

        public ICollection<Record> Records { get; set; }

        public ICollection<Member> Member { get; set; }

        public bool Deleted { get; set; }
    }
}
