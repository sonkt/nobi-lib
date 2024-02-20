using GbLib.Base;
using GbLib.MongoDb.Context;
using GbLib.MongoDb.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GbLib.MongoDb.Repositories
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity>
      where TEntity : MongoEntityBase
    {
        private readonly MongoDbContext _mongoDbContext;

        #region Constructors

        public MongoRepository(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        #endregion Constructors

        #region Private Methods

        private async Task<TEntity> FindOneAsync(ObjectId id, string collectionName = "")
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);

            return await _mongoDbContext
                .Collection<TEntity>(collectionName)
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        private async Task<List<TEntity>> FindListAsync(List<ObjectId> ids, string collectionName = "")
        {
            var filter = Builders<TEntity>.Filter.Where(x => ids.Contains(x.Id));

            return await _mongoDbContext
                .Collection<TEntity>(collectionName)
                .Find(filter)
                .ToListAsync();
        }

        #endregion Private Methods

        #region Public Methods

        public async Task<List<TEntity>> AddAsync(List<TEntity> entities, string collectionName = "")
        {
            await _mongoDbContext.Collection<TEntity>(collectionName).InsertManyAsync(entities);
            var listIds = entities.Select(m => m.Id)?.ToList();
            return await FindListAsync(listIds, collectionName);
        }

        public async Task<TEntity> AddAsync(TEntity entity, string collectionName = "")
        {
            await _mongoDbContext.Collection<TEntity>(collectionName).InsertOneAsync(entity);
            return await FindOneAsync(entity.Id, collectionName);
        }

        public async Task<bool> DeleteAsync(TEntity entity, string collectionName = "")
        {
            await _mongoDbContext
                .Collection<TEntity>(collectionName)
                .DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", entity.Id));
            return true;
        }

        public async Task<bool> DeleteAsync(List<TEntity> entities, string collectionName = "")
        {
            var listIds = entities.Select(m => m.Id)?.ToList();
            if (listIds == null) return false;

            await _mongoDbContext.Collection<TEntity>(collectionName)
                .DeleteManyAsync(Builders<TEntity>.Filter.Where(x => listIds.Contains(x.Id)));
            return true;
        }

        public async Task<PaginationSet<TEntity>> GetListPagedAsync(int pageNumber, int rowsPerPage, FilterDefinition<TEntity> predicate, SortDefinition<TEntity> sortColumn, string collectionName = "")
        {
            var results = await _mongoDbContext.Collection<TEntity>(collectionName).AggregateByPage(
                predicate,
                sortColumn,
                pageNumber,
                rowsPerPage);

            return new PaginationSet<TEntity>
            {
                Items = results.data,
                TotalCount = (int)results.totalRows
            };
        }

        public TEntity GetObject(FilterDefinition<TEntity> predicate, string collectionName = "")
        {
            return _mongoDbContext
                .Collection<TEntity>(collectionName)
                .Find(predicate)
                .FirstOrDefault();
        }

        public async Task<TEntity> GetObjectAsync(FilterDefinition<TEntity> predicate, string collectionName = "")
        {
            return await _mongoDbContext
                .Collection<TEntity>(collectionName)
                .Find(predicate)
                .FirstOrDefaultAsync();
        }

        public TEntity GetObjectById(ObjectId id, string collectionName = "")
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);

            return _mongoDbContext
                .Collection<TEntity>(collectionName)
                .Find(filter)
                .FirstOrDefault();
        }

        public async Task<TEntity> GetObjectByIdAsync(ObjectId id, string collectionName = "")
        {
            return await FindOneAsync(id, collectionName);
        }

        public int RecordCount(FilterDefinition<TEntity> predicate, string collectionName = "")
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, string collectionName = "")
        {
            await _mongoDbContext
                .Collection<TEntity>(collectionName)
                .ReplaceOneAsync(n => n.Id.Equals(entity.Id), entity, new ReplaceOptions() { IsUpsert = true });
            return await FindOneAsync(entity.Id, collectionName);
        }

        public async Task<List<TEntity>> UpdateAsync(List<TEntity> entities, string collectionName = "")
        {
            foreach (var entity in entities)
            {
                await _mongoDbContext
                .Collection<TEntity>(collectionName)
                .ReplaceOneAsync(n => n.Id.Equals(entity.Id), entity, new ReplaceOptions() { IsUpsert = true });
            }
            var listIds = entities.Select(m => m.Id)?.ToList();
            return await FindListAsync(listIds, collectionName);
        }

        public IMongoCollection<TEntity> GetCollection(string collectionName = "")
        {
            return _mongoDbContext.Collection<TEntity>(collectionName);
        }

        #endregion Public Methods
    }
}