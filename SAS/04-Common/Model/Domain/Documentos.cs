using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Documentos
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte[] Documento { get; set; }
        public string Tipo { get; set; }

        public int DetCanalizacionId { get; set; }
        public DetCanalizacion DetCanalizacion { get; set; }
    }
}
