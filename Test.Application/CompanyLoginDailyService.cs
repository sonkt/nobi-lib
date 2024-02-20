using GbLib.MongoDb.Repositories;
using GbLib.MongoDb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application
{
    public class CompanyLoginDailyService : MongoBaseService<TracklogCompanyDailyEntity>, ICompanyLoginDailyService
    {
        public CompanyLoginDailyService(IMongoRepository<TracklogCompanyDailyEntity> repository, string collectionName = "") : base(repository, collectionName)
        {
        }
    }
}
