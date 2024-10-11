using Amazon.Runtime.Internal.Util;
using MongoDB.Driver;
using ProjetoFinal1.Infra.Logs.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Infra.Logs.Contexts
{
    public class MongoDBContexts
    {
        private IMongoDatabase? _mongoDatabase;

        //constructor method
        public MongoDBContexts()
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017/"));
            var mongoClient = new MongoClient(settings);

            _mongoDatabase = mongoClient.GetDatabase("BDLogs_produtos");
        }

        //mapping collections
        public IMongoCollection<LogMessages> LogMessages
            => _mongoDatabase.GetCollection<LogMessages>("LogMessageProduct");
    }
}
