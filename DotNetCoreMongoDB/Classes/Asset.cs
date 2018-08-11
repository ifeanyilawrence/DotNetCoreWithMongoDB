using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMongoDB.Classes
{
    public class Asset : MongoEntity
    {
        public Guid? AssetId { get; set; } = Guid.NewGuid();
        public string Symbol { get; set; }
    }
}
