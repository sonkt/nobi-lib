using MongoDB.Bson;
using MongoDB.Driver;
using GbLib.Base;
using GbLib.MongoDb.Entities;

namespace GbLib.MongoDb.Repositories
{
    public interface IMongoRepository<TEntity>
       where TEntity : MongoEntityBase
    {
        #region Command Action

        Task<List<TEntity>> AddAsync(List<TEntity> entities, string collectionName = "");

        Task<TEntity> AddAsync(TEntity entity, string collectionName = "");

        Task<bool> DeleteAsync(TEntity entity, string collectionName = "");

        Task<bool> DeleteAsync(List<TEntity> entities, string collectionName = "");

        Task<TEntity> UpdateAsync(TEntity entity, string collectionName = "");

        Task<List<TEntity>> UpdateAsync(List<TEntity> entities, string collectionName = "");

        #endregion Command Action

        #region Query Action

        Task<PaginationSet<TEntity>> GetListPagedAsync(int pageNumber, int rowsPerPage, FilterDefinition<TEntity> predicate, SortDefinition<TEntity> sortColumn, string collectionName = "");

        TEntity GetObject(FilterDefinition<TEntity> predicate, string collectionName = "");

        Task<TEntity> GetObjectAsync(FilterDefinition<TEntity> predicate, string collectionName = "");

        TEntity GetObjectById(ObjectId id, string collectionName = "");

        Task<TEntity> GetObjectByIdAsync(ObjectId id, string collectionName = "");

        int RecordCount(FilterDefinition<TEntity> predicate, string collectionName = "");

        #endregion Query Action
    }
}
