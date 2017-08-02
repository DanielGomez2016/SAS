using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Solicitud : AuditEntity, ISoftDeleted
    {
        public int SolicitudId { get; set; }
        public string Folio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Asunto { get; set; }
        public string MetaGeneral { get; set; }
        public DateTime FechaValidacion { get; set; }
        public string Programa { get; set; }

        public int EscuelaId { get; set; }
        public Escuela Escuela { get; set; }

        public int BeneficiarioId { get; set; }
        public Beneficiario Beneficiario { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        public int InstitucionId { get; set; }
        public Institucion Institucion { get; set; }

        public bool Deleted { get; set; }
    }
}
