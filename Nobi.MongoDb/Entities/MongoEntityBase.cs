using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.MongoDb.Entities
{
    public abstract class MongoEntityBase
    {
        public virtual ObjectId Id { get; set; }
    }
}
