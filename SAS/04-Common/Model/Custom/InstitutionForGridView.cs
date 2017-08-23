using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class InstitutionForGridView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public string Manager { get; set; }
        public string Phone { get; set; }
        public int Departments { get; set; }
        public int Users { get; set; }
    }
}
