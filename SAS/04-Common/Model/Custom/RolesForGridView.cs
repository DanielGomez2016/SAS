using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class RolesForGridView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<BodyAccess> bodyAccess { get; set; }
        public int TotalUsers { get; set; }
        public int InstituteId { get; set; }
    }

    public class BodyAccess
    {
        public int AccessId { get; set; }
        public string AccessName { get; set; }
        public bool Status { get; set; }
    }
}
