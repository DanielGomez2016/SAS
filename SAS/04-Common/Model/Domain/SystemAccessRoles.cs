using Common.CustomFilters;
using Model.Auth;
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
    public class SystemAccessRoles : AuditEntity, ISoftDeleted
    {
        [Key, Column(Order = 1)]
        public ApplicationRole Role { get; set; }
        public string RoleId { get; set; }


        [Key, Column(Order = 2)]
        public int Id { get; set; }
        public SystemAccess SystemAccess { get; set; }

        [Key, Column(Order = 3)]
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }

        public bool Access { get; set; }

        public bool Deleted { get; set; }

    }
}
