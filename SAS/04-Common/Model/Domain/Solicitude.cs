using Common;
using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Solicitude : AuditEntity, ISoftDeleted
    {
        public int SolicitudeId { get; set; }
        public string Folio { get; set; }

        [Display(Name = "Fecha de Entrega")]
        public DateTime DeliverDate { get; set; }

        [Display(Name = "Asunto")]
        public string Affair { get; set; }

        [Display(Name = "Metas Generales")]
        public string GeneralGoal { get; set; }

        [Display(Name = "Fecha de Validacion")]
        public DateTime ValidationDate { get; set; }

        public Enums.Status Status { get; set; }

        public TypeSubject TypeSubject { get; set; }
        public int TypeSubjectId { get; set; }

        public Provenance Provenance { get; set; }
        public int ProvenanceId { get; set; }

        public College College { get; set; }
        public int CollegeId { get; set; }

        public Beneficiary Beneficiaries { get; set; }
        public int BeneficiaryId { get; set; }

        public Record Record { get; set; }

        public bool Deleted { get; set; }

    }
}
