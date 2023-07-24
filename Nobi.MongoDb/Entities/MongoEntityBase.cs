using MongoDB.Bson;

namespace Nobi.MongoDb.Entities
{
    public abstract class MongoEntityBase
    {
        public virtual ObjectId Id { get; set; }
    }
}
