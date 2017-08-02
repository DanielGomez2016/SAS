using Model.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class AccesoSistemaRol
    {
        public int InstitucionId { get; set; }
        public Institucion Institucion { get; set; }

        public string Id { get; set; }
        public ApplicationRole ApplicationRole { get; set; }

        public int AccesoSistemaId { get; set; }
        public AccesoSistema AccesoSistema { get; set; }
    }
}
