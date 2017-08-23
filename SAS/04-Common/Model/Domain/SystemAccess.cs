using Common;
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
    public class SystemAccess : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }

        [Display(Name = "Controlador")]
        [Required]
        public string Controller { get; set; }

        [Display(Name = "Accion")]
        [Required]
        public string ActionController { get; set; }

        [Display(Name = "Descripcion")]
        public string DescriptionAccess { get; set; }

        [Display(Name = "Estatus")]
        public Enums.StatusAccess Status { get; set; }

        public bool Deleted { get; set; }

    }
}
