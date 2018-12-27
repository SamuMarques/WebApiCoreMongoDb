using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreWithMongoDb.Models;

namespace WebApiCoreWithMongoDb
{
    public class Context
    {
        private readonly IMongoDatabase database;

        public Context()
        {
            database = new MongoClient("mongodb://admin:desenv1@ds113873.mlab.com:13873/samuelsdb").GetDatabase("samuelsdb");
        }

        public IMongoCollection<Post> Posts
        {
            get
            {
                return database.GetCollection<Post>("Posts");
            }
        }
    }
}
