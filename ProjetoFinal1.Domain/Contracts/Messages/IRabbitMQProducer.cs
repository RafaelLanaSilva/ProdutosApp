using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Domain.Contracts.Messages
{
    public interface IRabbitMQProducer
    {
        public void Send(string message);
    }
}
