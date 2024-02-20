using GbLib.MongoDb.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application
{
    [BsonIgnoreExtraElements]
    public class ActionEntity : MongoEntityBase
    {
        public Guid SessionId { get; set; }
        public int FK_ClientId { get; set; }
        public string? OSType { get; set; }
        public int FK_CompanyId { get; set; }
        public Guid FK_UserId { get; set; }
        public int FK_MenuId { get; set; }
        public int FK_FeatureId { get; set; }
        public int FK_ActionId { get; set; }
        public long ActionTime { get; set; }
    }
}
