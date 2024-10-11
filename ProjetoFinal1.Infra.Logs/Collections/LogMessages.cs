using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Infra.Logs.Collections
{
    public class LogMessages
    {
        public Guid? Id { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
    }
}
