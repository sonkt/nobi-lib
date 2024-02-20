using GbLib.MongoDb.Context;
using GbLib.MongoDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application
{
    public class CompanyLoginDailyRepository : MongoRepository<TracklogCompanyDailyEntity>, ICompanyLoginDailyRepository
    {
        public CompanyLoginDailyRepository(MongoDbContext mongoDbContext) : base(mongoDbContext)
        {
        }
    }
}
