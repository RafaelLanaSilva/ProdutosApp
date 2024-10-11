using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Infra.Messages.Settings
{
    public class RabbitMQSettings
    {
        public static string Url => @"amqps://ayhevthj:GiWSHEVapCA8j9AnuAcTNrYOxyAFsdyg@jackal.rmq.cloudamqp.com/ayhevthj";

        public static string Queue => "mensagens_produto";
    }
}
