using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Domain.Models.Services
{
    public class EmailServiceModel
    {
        public string? EmailReceiver { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
