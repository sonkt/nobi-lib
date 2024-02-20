using GbLib.MongoDb.Repositories;
using GbLib.MongoDb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application
{
    public class ActionService : MongoBaseService<ActionEntity>, IActionService
    {
        public ActionService(IMongoRepository<ActionEntity> repository, string collectionName = "") : base(repository, collectionName)
        {
        }
    }
}
