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
        public string Controller { get; set; }

        [Display(Name = "Accion")]
        public string Action { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Display(Name = "Estatus")]
        public Enums.StatusAccess Status { get; set; }

        public List<SystemAccessRoles> Roles { get; set; }

        public bool Deleted { get; set; }

    }
}
