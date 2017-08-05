using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Requirements : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }

        public College College { get; set; }
        public int CollegeId { get; set; }

        public bool Deleted { get; set; }
    }
}
