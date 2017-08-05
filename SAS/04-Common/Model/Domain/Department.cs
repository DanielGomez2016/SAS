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
    public class Department : AuditEntity, ISoftDeleted
    {
        public int DepartmentId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Titular")]
        public string Manager { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Display(Name = "Extencion")]
        public string Extension { get; set; }

        public Institution Institution { get; set; }
        public int InstitutionId { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        public ICollection<DetailRecord> DetailRecords { get; set; }

        public bool Deleted { get; set; }



    }
}
