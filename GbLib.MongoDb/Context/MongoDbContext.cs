using MongoDB.Driver;

namespace GbLib.MongoDb.Context
{
    public class MongoDbContext : IDisposable
    {
        #region Fields

        private readonly IMongoDatabase _database;

        #endregion Fields

        #region Constructors

        public MongoDbContext(MongoDbOptions options)
        {
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