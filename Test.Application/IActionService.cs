﻿using GbLib.MongoDb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application
{
    public interface IActionService : IMongoBaseService<ActionEntity>
    {
    }
}
