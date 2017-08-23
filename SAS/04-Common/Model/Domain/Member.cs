using Common.CustomFilters;
using Model.Auth;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Member : AuditEntity, ISoftDeleted
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte[] BigFile { get; set; }
        public byte[] SmallFile { get; set; }

        public Institution Institution { get; set; }
        public int? InstitutionId { get; set; }

        public Department Department { get; set; }
        public int? DepartmentId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public bool Deleted { get; set; }

    }
}
