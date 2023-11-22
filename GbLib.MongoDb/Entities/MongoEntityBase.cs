using MongoDB.Bson;

namespace GbLib.MongoDb.Entities
{
    public abstract class MongoEntityBase
    {
        public virtual ObjectId Id { get; set; }
    }
}