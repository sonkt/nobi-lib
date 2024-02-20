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
    public class TracklogCompanyDailyEntity : MongoEntityBase
    {
        public int FK_CompanyId { get; set; }
        public long FK_Date { get; set; }
        public List<ActionCount> ActionCounts { get; set; } = new List<ActionCount>();
        public List<MenuCount> MenuCounts { get; set; } = new List<MenuCount>();
        public List<FeatureCount> FeatureCounts { get; set; } = new List<FeatureCount>();
        public DateTime TimeSync { get; set; }
    }
    public class ActionCount
    {
        public int FK_ActionId { get; set; }
        public int FK_ClientId { get; set; }
        public int Count { get; set; }
    }
    public class MenuCount
    {
        public int FK_MenuId { get; set; }
        public int FK_ClientId { get; set; }
        public int Count { get; set; }
    }
    public class FeatureCount
    {
        public int FK_FeatureId { get; set; }
        public int FK_ClientId { get; set; }
        public int Count { get; set; }
    }
}
