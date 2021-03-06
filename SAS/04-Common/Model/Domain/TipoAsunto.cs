﻿using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class TipoAsunto : AuditEntity, ISoftDeleted
    {
        public int TipoAsuntoId { get; set; }
        public string Asunto { get; set; }

        public List<Solicitud> Solicitudes { get; set; }
        public bool Deleted { get; set; }
    }
}
