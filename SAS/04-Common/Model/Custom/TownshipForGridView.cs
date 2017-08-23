using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class TownshipForGridView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Localities { get; set; }
    }
}
