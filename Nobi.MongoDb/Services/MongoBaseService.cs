using MongoDB.Bson;
using MongoDB.Driver;
using Nobi.Base;
using Nobi.MongoDb.Entities;
using Nobi.MongoDb.Repositories;

namespace Nobi.MongoDb.Services
{
    public class MongoBaseService<TEntity> : IMongoBaseService<TEntity> where TEntity : MongoEntityBase
    {
        private readonly IMongoRepository<TEntity> _repository;

        public MongoBaseService(IMongoRepository<TEntity> repository, string collectionName = "")
        {
            _repository = repository;
        }

        public virtual async Task<bool> DeleteAsync(TEntity data, string collectionName = "")
        {
            return await _repository.DeleteAsync(data, collectionName);
        }

        public virtual async Task<bool> DeleteListAsync(List<TEntity> listData, string collectionName = "")
        {
            return await _repository.DeleteAsync(listData, collectionName);
        }

        public virtual async Task<TEntity> GetByCondition(FilterDefinition<TEntity> predicate, string collectionName = "")
        {
            return await _repository.GetObjectAsync(predicate, collectionName);
        }

        public virtual async Task<TEntity> GetById(ObjectId id, string collectionName = "")
        {
            return await _repository.GetObjectByIdAsync(id, collectionName);
        }

        public virtual async Task<PaginationSet<TEntity>> GetListPagedAsync(int pageNumber, int rowsPerPage, FilterDefinition<TEntity> predicate, SortDefinition<TEntity> sortColumn, string collectionName = "")
        {
            return await _repository.GetListPagedAsync(pageNumber, rowsPerPage, predicate, sortColumn, collectionName);
        }

        public virtual async Task<ObjectId> InsertAsync(TEntity data, string collectionName = "")
        {
            var result = await _repository.AddAsync(data, collectionName);
            return result.Id;
        }

        public virtual async Task<List<ObjectId>> InsertListAsync(List<TEntity> listData, string collectionName = "")
        {
            var result = await _repository.AddAsync(listData, collectionName);
            return result?.Select(m => m.Id)?.ToList();
        }

        public virtual async Task<bool> UpdateAsync(TEntity data, string collectionName = "")
        {
            var result = await _repository.UpdateAsync(data, collectionName);
            return result.Id != ObjectId.Empty;
        }

        public virtual async Task<bool> UpdateListAsync(List<TEntity> listData, string collectionName = "")
        {
            var result = await _repository.UpdateAsync(listData, collectionName);
            return result.Count > 0;
        }
    }
}
