using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class AccessForGridView
    {
        public int Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public Enums.StatusAccess Status { get; set; }
        public List<string> Roles { get; set; }
    }
}
