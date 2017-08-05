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
    public class Document : AuditEntity, ISoftDeleted
    {
        public int DocumentId { get; set; }

        [Display(Name = "Nombre Archivo")]
        public string Name { get; set; }

        [Display(Name = "Tipo")]
        public string Type { get; set; }

        [Display(Name = "Archivo")]
        public byte[] File { get; set; }

        public DetailRecord DetailRecord { get; set; }
        public int DetailRecordId { get; set; }

        public bool Deleted { get; set; }

    }
}
