using Amazon.Runtime.Internal.Util;
using ProjetoFinal1.Infra.Logs.Collections;
using ProjetoFinal1.Infra.Logs.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Infra.Logs.Persistence
{
    public class LogMessagesPersistence
    {
        public void Insert(LogMessages log)
        {
            var mongoDBContexts = new MongoDBContexts();
            mongoDBContexts.LogMessages.InsertOne(log);
        }
    }
}
