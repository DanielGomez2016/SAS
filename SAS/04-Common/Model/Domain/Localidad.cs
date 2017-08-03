using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Localidad : AuditEntity, ISoftDeleted
    {
        public int LocalidadId { get; set; }
        public string Nombre { get; set; }
        public string ClaveLocalidad { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int Altitud { get; set; }

        public bool Deleted { get; set; }

        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }

        public List<Escuela> Escuelas { get; set; }
        public List<Beneficiario> Beneficiarios { get; set; }

        public List<Procedencia> Procedencia { get; set; }

    }
}
