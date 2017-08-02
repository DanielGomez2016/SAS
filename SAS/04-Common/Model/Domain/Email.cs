using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Email
    {
        public int Id { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string TipoEmail { get; set; }
    
    }
}
