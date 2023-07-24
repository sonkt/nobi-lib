using MongoDB.Driver;

namespace Nobi.MongoDb.Context
{
    public class MongoDbContext : IDisposable
    {
        #region Fields

        private readonly IMongoDatabase _database;

        private readonly MongoDbOptions _options;

        #endregion Fields

        #region Constructors

        public MongoDbContext(MongoDbOptions options)
        {
            _options = options;
            var client = new MongoClient(options.ConnectionString);
            _database = client.GetDatabase(options.Database);
        }

        #endregion Constructors

        #region Methods

        public IMongoCollection<TEntity> Collection<TEntity>(string customName = "") where TEntity : class
        {
            if (string.IsNullOrEmpty(customName)) { customName = typeof(TEntity).Name; }
            return _database.GetCollection<TEntity>(customName);
        }

        public void Dispose()
        {
        }

        #endregion Methods
    }
}
