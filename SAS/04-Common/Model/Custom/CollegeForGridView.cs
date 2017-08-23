using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class CollegeForGridView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Locality { get; set; }
        public string EducationLevel { get; set; }
        public string Principal { get; set; }
        public Enums.StatusCollege Status { get; set; }

    }
}
