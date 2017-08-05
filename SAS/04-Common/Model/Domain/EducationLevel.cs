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
    public class EducationLevel : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }

        [Display(Name = "Nivel")]
        public string Level { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        public ICollection<College> College { get; set; }

        public bool Deleted { get; set; }

    }
}
