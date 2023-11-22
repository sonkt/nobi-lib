using GbLib.Base;
using GbLib.MongoDb.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GbLib.MongoDb.Services
{
    public interface IMongoBaseService<TEntity> where TEntity : MongoEntityBase
    {
        #region Methods

        Task<bool> DeleteAsync(TEntity data, string collectionName = "");

        Task<bool> DeleteListAsync(List<TEntity> listData, string collectionName = "");

        Task<PaginationSet<TEntity>> GetListPagedAsync(int pageNumber, int rowsPerPage, FilterDefinition<TEntity> predicate, SortDefinition<TEntity> sortColumn, string collectionName = "");

        Task<ObjectId> InsertAsync(TEntity data, string collectionName = "");

        Task<List<ObjectId>> InsertListAsync(List<TEntity> listData, string collectionName = "");

        Task<bool> UpdateAsync(TEntity data, string collectionName = "");

        Task<bool> UpdateListAsync(List<TEntity> listData, string collectionName = "");

        Task<TEntity> GetById(ObjectId id, string collectionName = "");

        Task<TEntity> GetByCondition(FilterDefinition<TEntity> predicate, string collectionName = "");

        #endregion Methods
    }
}