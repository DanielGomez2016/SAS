using Common;
using Common.CustomFilters;
using Model.Auth;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class DetCanalizacion : AuditEntity, ISoftDeleted
    {
        public int DetCanalizacionId { get; set; }
        public DateTime FechaCanalizacion { get; set; }
        public string Comentario { get; set; }

        public int CanalizacionId { get; set; }
        public Canalizacion Canalizacion { get; set; }

        public Enums.Status Estatus { get; set; }

        [ForeignKey("UserAsignaId")]
        public ApplicationUser UserAsigna { get; set; }
        public string UserAsignaId { get; set; }

        [ForeignKey("UserAtiendeId")]
        public ApplicationUser UserAtiende { get; set; }
        public string UserAtiendeId { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        public List<Documentos> Documentos { get; set; }


        public bool Deleted { get; set; }

    }
}
