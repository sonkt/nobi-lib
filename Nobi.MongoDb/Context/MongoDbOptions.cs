using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.MongoDb.Context
{
    public class MongoDbOptions
    {
        #region Properties

        public string ConnectionString { get; set; }

        public string Database { get; set; }

        public bool Enabled { get; set; }

        public bool Seed { get; set; }

        #endregion Properties
    }
}
