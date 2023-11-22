using Dapper;
using GbLib.Base;
using GbLib.Base.Helpers;
using GbLib.DapperOrm.Context;
using GbLib.DapperOrm.Entities;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using MicroOrm.Dapper.Repositories.SqlGenerator.Filters;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace GbLib.DapperOrm.Repositories
{
    public class DpRepository<TEntity, TId> : DapperRepository<TEntity>, IDpRepository<TEntity, TId>
        where TEntity : class, IAuditEntity<TId>
    {
        public bool UseTVP { get; set; } = false;

        //private readonly IDbConnection _connection;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        private readonly IDbConnectionFactory _dbConnectionFactory;
        private IDbTransaction _dbTransaction;

        public DpRepository(IDbConnectionFactory dbConnectionFactory, ISqlGenerator<TEntity> generator, IDomainEventDispatcher domainEventDispatcher) : base(dbConnectionFactory.OpenDbConnection(), generator)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public IDbTransaction GetTransaction()
        {
            return _dbConnectionFactory.GetDbTransaction();
        }

        public Task<PaginationSet<TEntity>> GetListPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, string sortColumnName, bool descending = false, IDbTransaction? dbTransaction = null)
        {
            var sortList = new Dictionary<string, bool>();
            sortList.Add(sortColumnName, descending); ;
            return GetListPagedAsync(pageNumber, pageSize, predicate, sortList, dbTransaction);
        }

        public async Task<PaginationSet<TEntity>> GetListPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Dictionary<string, bool> sortList, IDbTransaction? dbTransaction = null)
        {
            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }
            var sortingBuilder = new List<string> { };
            foreach (var item in sortList)
            {
                var order = item.Value ? "DESC " : "ASC ";
                sortingBuilder.Add($"{item.Key} {order}");
            }
            var offset = (pageNumber - 1) * pageSize;
            var strSort = string.Join(", ", sortingBuilder);

            var countQueryResult = SqlGenerator.GetCount(predicate);
            var countSqlQuery = countQueryResult.GetSql();
            countSqlQuery = ReGenerateQuery(countQueryResult, countSqlQuery);
            var count = Connection.QueryFirstOrDefault<int>(countSqlQuery, countQueryResult.Param, dbTransaction);

            base.SetOrderBy(strSort).SetLimit((uint)pageSize, (uint)offset);
            var queryResult = SqlGenerator.GetSelectAll(predicate, FilterData);
            var sqlQuery = queryResult.GetSql();
            sqlQuery = ReGenerateQuery(queryResult, sqlQuery);

            var items = await Connection.QueryAsync<TEntity>(new CommandDefinition(sqlQuery, queryResult.Param, dbTransaction));

            return new PaginationSet<TEntity>
            {
                Items = items,
                TotalCount = count
            };
        }

        private string ReGenerateQuery(SqlQuery queryResult, string sqlQuery)
        {
            if (queryResult.Param != null)
            {
                if (queryResult.Param.GetType() == typeof(Dictionary<string, object>))
                {
                    var listParams = (Dictionary<string, object>)queryResult.Param;
                    foreach (var param in listParams)
                    {
                        var paramValueType = param.Value.GetType();
                        if (paramValueType.IsArray || paramValueType.GetTypeInfo().ReflectedType == typeof(Enumerable) || paramValueType.GetTypeInfo().ReflectedType == typeof(List<>))
                        {
                            var lstData = ((IEnumerable)param.Value).Cast<object>().ToArray();
                            var type = TypeHelper.GetItemTypeOfList(lstData);
                            sqlQuery = ProccessParams(sqlQuery, listParams, param, lstData, type);
                        }
                    }
                }
            }

            return sqlQuery;
        }

        private string ProccessParams(string sqlQuery, Dictionary<string, object> listParams, KeyValuePair<string, object> param, object[] lstData, Type type)
        {
            if (lstData.Count() > 1500 || UseTVP) // 2100 params
            {
                var tvpCondition = new DataTable();
                tvpCondition.Columns.Add("[Value]", type);
                foreach (var dataItem in lstData)
                {
                    tvpCondition.Rows.Add(dataItem);
                }
                var tvp = tvpCondition.AsTableValuedParameter();
                if (type == typeof(string))
                {
                    tvp = tvpCondition.AsTableValuedParameter("dbo.TVP_NVarchar");
                }
                else if (type == typeof(Guid))
                {
                    tvp = tvpCondition.AsTableValuedParameter("dbo.TVP_Guid");
                }
                else if (type == typeof(long))
                {
                    tvp = tvpCondition.AsTableValuedParameter("dbo.TVP_BigInt");
                }
                else if (type == typeof(int))
                {
                    tvp = tvpCondition.AsTableValuedParameter("dbo.TVP_Int");
                }
                else if (type == typeof(short))
                {
                    tvp = tvpCondition.AsTableValuedParameter("dbo.TVP_SmallInt");
                }
                else if (type == typeof(byte))
                {
                    tvp = tvpCondition.AsTableValuedParameter("dbo.TVP_TinyInt");
                }
                else if (type == typeof(bool))
                {
                    tvp = tvpCondition.AsTableValuedParameter("dbo.TVP_Bit");
                }
                else if (type == typeof(char))
                {
                    tvp = tvpCondition.AsTableValuedParameter("dbo.TVP_Char");
                }
                else if (type == typeof(float) || type == typeof(double))
                {
                    tvp = tvpCondition.AsTableValuedParameter("dbo.TVP_Float");
                }
                else if (type == typeof(decimal))
                {
                    tvp = tvpCondition.AsTableValuedParameter("dbo.TVP_Decimal");
                }
                else if (type == typeof(DateTime))
                {
                    tvp = tvpCondition.AsTableValuedParameter("dbo.TVP_DateTime");
                }

                sqlQuery = sqlQuery.Replace($"@{param.Key}", $"(SELECT [Value] FROM @{param.Key})");
                listParams[param.Key] = tvp;
            }

            return sqlQuery;
        }

        public async Task<int> ExecuteRawSql(string sql, IDbTransaction? dbTransaction = null)
        {
            return await Connection.ExecuteAsync(sql, null, dbTransaction);
        }

        public async Task<int> ExecuteStoreProcedure(string storeProcedureName, SqlParameter[] parammeters, IDbTransaction? dbTransaction = null)
        {
            try
            {
                var dynParams = new DynamicParameters();
                foreach (var item in parammeters)
                {
                    if (item.Direction == ParameterDirection.Output)
                    {
                        dynParams.Add(item.ParameterName, dbType: item.DbType, direction: item.Direction);
                    }
                    else
                    {
                        dynParams.Add(item.ParameterName, item.Value, item.DbType, item.Direction);
                    }
                }
                var commandDefinition = new CommandDefinition(storeProcedureName, dynParams, dbTransaction, null, CommandType.StoredProcedure);
                return await Connection.ExecuteAsync(commandDefinition);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<SqlParameter>> ExecuteStoreProcedureWithOutput(string storeProcedureName, SqlParameter[] parammeters, IDbTransaction? dbTransaction = null)
        {
            try
            {
                var lstReturn = new List<SqlParameter>();
                var dynParams = new DynamicParameters();
                foreach (var item in parammeters)
                {
                    if (item.Direction == ParameterDirection.Output)
                    {
                        dynParams.Add(item.ParameterName, dbType: item.DbType, direction: item.Direction);
                    }
                    else
                    {
                        dynParams.Add(item.ParameterName, item.Value, item.DbType, item.Direction);
                    }
                }

                var commandDefinition = new CommandDefinition(storeProcedureName, dynParams, dbTransaction, null, CommandType.StoredProcedure);
                var result = await Connection.ExecuteAsync(commandDefinition);
                if (result > 0)
                {
                    foreach (var item in parammeters)
                    {
                        if (item.Direction == ParameterDirection.Output)
                        {
                            item.Value = dynParams.Get<object>(item.ParameterName);
                            lstReturn.Add(item);
                        }
                    }
                }
                return lstReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public bool Add(List<TEntity> entities, IDbTransaction? dbTransaction = null)
        {
            foreach (var item in entities)
            {
                SetMinDateIfNull(item);
                if (typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
                {
                    ((IAuditEntity)item).CreatedDate = DateTime.UtcNow;
                    AutoGuidKeyValueIfNullOrEmpty(item);
                }
            }
            var result = base.BulkInsert(entities, dbTransaction) > 0;
            if (result)
            {
                SaveChangesWithEvents(_domainEventDispatcher, entities);
            }
            return result;
        }

        public async Task<bool> AddAsync(List<TEntity> entities, IDbTransaction? dbTransaction = null)
        {
            foreach (var item in entities)
            {
                SetMinDateIfNull(item);
                if (typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
                {
                    ((IAuditEntity)item).CreatedDate = DateTime.UtcNow;
                    AutoGuidKeyValueIfNullOrEmpty(item);
                }
            }
            var result = (await base.BulkInsertAsync(entities, dbTransaction)) > 0;
            if (result)
            {
                SaveChangesWithEvents(_domainEventDispatcher, entities);
            }
            return result;
        }

        public bool Add(TEntity entity, IDbTransaction? dbTransaction = null)
        {
            SetMinDateIfNull(entity);
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IAuditEntity)entity).CreatedDate = DateTime.UtcNow;
            }
            AutoGuidKeyValueIfNullOrEmpty(entity);
            var result = base.Insert(entity, dbTransaction);
            if (result)
            {
                SaveChangesWithEvents(_domainEventDispatcher, new List<TEntity> { entity });
            }
            return result;
        }

        public async Task<bool> AddAsync(TEntity entity, IDbTransaction? dbTransaction = null)
        {
            SetMinDateIfNull(entity);
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IAuditEntity)entity).CreatedDate = DateTime.UtcNow;
            }
            AutoGuidKeyValueIfNullOrEmpty(entity);
            var result = await base.InsertAsync(entity, dbTransaction);
            if (result)
            {
                SaveChangesWithEvents(_domainEventDispatcher, new List<TEntity> { entity });
            }
            return result;
        }

        public bool Delete(List<TEntity> entities, IDbTransaction? dbTransaction = null)
        {
            var result = true;
            if (typeof(IHardDeleteEntity).IsAssignableFrom(typeof(TEntity)))
            {
                foreach (var item in entities)
                {
                    result = result && base.Delete(item, dbTransaction, null);
                }
            }
            else
            {
                foreach (var item in entities)
                {
                    if (typeof(IDeleteEntity).IsAssignableFrom(typeof(TEntity)))
                    {
                        ((IDeleteEntity)item).IsDeleted = true;
                        item.DeletedDate = DateTime.Now;
                        SetMinDateIfNull(item);
                    }
                }
                result = result && base.BulkUpdate(entities, dbTransaction);
            }
            if (result)
            {
                SaveChangesWithEvents(_domainEventDispatcher, entities);
            }
            return result;
        }

        public bool Delete(TEntity entity, IDbTransaction? dbTransaction = null)
        {
            return base.Delete(entity, dbTransaction, null);
        }

        public async Task<bool> DeleteAsync(List<TEntity> entities, IDbTransaction? dbTransaction = null)
        {
            var result = true;
            if (entities != null)
            {
                if (typeof(IHardDeleteEntity).IsAssignableFrom(typeof(TEntity)))
                {
                    foreach (var item in entities)
                    {
                        result = result && await base.DeleteAsync(item, dbTransaction, null);
                    }
                }
                else
                {
                    foreach (var item in entities)
                    {
                        if (typeof(IDeleteEntity).IsAssignableFrom(typeof(TEntity)))
                        {
                            ((IDeleteEntity)item).IsDeleted = true;
                            item.DeletedDate = DateTime.Now;
                            SetMinDateIfNull(item);
                        }
                    }
                    result = result && await base.BulkUpdateAsync(entities, dbTransaction);
                }

                if (result)
                {
                    SaveChangesWithEvents(_domainEventDispatcher, entities);
                }
            }
            return result;
        }

        public async Task<bool> DeleteAsync(TEntity entity, IDbTransaction? dbTransaction = null)
        {
            if (typeof(IHardDeleteEntity).IsAssignableFrom(typeof(TEntity)))
            {
                var result = await base.DeleteAsync(entity, dbTransaction, null);
                if (result)
                {
                    SaveChangesWithEvents(_domainEventDispatcher, new List<TEntity> { entity });
                }
                return result;
            }
            else if (typeof(IDeleteEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IDeleteEntity)entity).IsDeleted = true;
                entity.DeletedDate = DateTime.Now;
                SetMinDateIfNull(entity);
                var result = await base.UpdateAsync(entity, dbTransaction);
                if (result)
                {
                    SaveChangesWithEvents(_domainEventDispatcher, new List<TEntity> { entity });
                }
                return result;
            }
            return false;
        }

        public Task<TEntity> GetObject(TId id, IDbTransaction? dbTransaction = null)
        {
            return base.FindByIdAsync(id, dbTransaction);
        }

        public bool Update(List<TEntity> entities, IDbTransaction? dbTransaction = null)
        {
            foreach (var item in entities)
            {
                SetMinDateIfNull(item);
                item.UpdatedDate = DateTime.Now;
            }
            var result = base.BulkUpdate(entities, dbTransaction);
            if (result)
            {
                SaveChangesWithEvents(_domainEventDispatcher, entities);
            }
            return result;
        }

        public async Task<bool> UpdateAsync(List<TEntity> entities, IDbTransaction? dbTransaction = null)
        {
            foreach (var item in entities)
            {
                SetMinDateIfNull(item);
                item.UpdatedDate = DateTime.Now;
            }
            var result = await base.BulkUpdateAsync(entities, dbTransaction);
            if (result)
            {
                SaveChangesWithEvents(_domainEventDispatcher, entities);
            }
            return result;
        }

        public bool Update(TEntity entity, IDbTransaction? dbTransaction = null)
        {
            SetMinDateIfNull(entity);
            entity.UpdatedDate = DateTime.Now;
            var result = base.Update(entity, dbTransaction);
            if (result)
            {
                SaveChangesWithEvents(_domainEventDispatcher, new List<TEntity> { entity });
            }
            return result;
        }

        public async Task<bool> UpdateAsync(TEntity entity, IDbTransaction? dbTransaction = null)
        {
            SetMinDateIfNull(entity);
            entity.UpdatedDate = DateTime.Now;
            if (base.Connection.State == ConnectionState.Closed)
            {
                base.Connection.Open();
            }
            var result = await base.UpdateAsync(entity, dbTransaction);
            if (result)
            {
                SaveChangesWithEvents(_domainEventDispatcher, new List<TEntity> { entity });
            }
            return result;
        }

        /// <summary>
        /// Hàm này với Dapper vô dụng
        /// </summary>
        /// <param name="entity"></param>
        public void Detach(TEntity entity)
        {
        }

        public IEnumerable<TEntity> GetObjects(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null)
        {
            return base.SetOrderBy(OrderInfo.SortDirection.DESC, x => x.Id).FindAll(predicate, dbTransaction);
        }

        public Task<TEntity> GetObject(Expression<Func<TEntity, bool>> predicate, IDbTransaction? dbTransaction = null)
        {
            return base.FindAsync(predicate, dbTransaction);
        }

        private void AutoGuidKeyValueIfNullOrEmpty(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute is GbLib.Base.Attributes.KeyAttribute || attribute is KeyAttribute)
                    {
                        if (property.PropertyType == typeof(Guid))
                        {
                            Guid.TryParse($"{property.GetValue(entity, null)}", out Guid currentValue);
                            if (currentValue == Guid.Empty)
                            {
                                property.SetValue(entity, Guid.NewGuid());
                                return;
                            }
                        }
                    }
                }
            }
        }

        private string GetFieldNameOfKey(Type type)
        {
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute is GbLib.Base.Attributes.KeyAttribute || attribute is KeyAttribute)
                    {
                        return property.Name;
                    }
                }
            }
            return "";
        }

        private void SetMinDateIfNull(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attType = property.PropertyType;
                // Nếu là kiểu DateTime (không cho phép null) mà giá trị truyền vào là MinValue thì set nó về MinSystemDate
                if (attType == typeof(DateTime))
                {
                    var value = (DateTime)property.GetValue(entity, null);
                    if (value == System.DateTime.MinValue)
                    {
                        property.SetValue(entity, DateTimeHelper.MinSystemDate);
                    }
                }
                // Nếu là kiểu DateTime cho phép null mà giá trị = MinValue thì Set nó về null
                else if (attType == typeof(DateTime?))
                {
                    var value = (DateTime?)property.GetValue(entity, null);
                    if (value == System.DateTime.MinValue)
                    {
                        property.SetValue(entity, null);
                    }
                }
            }
        }

        private void SaveChangesWithEvents(IDomainEventDispatcher domainEventDispatcher, List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                string keyNameOfEntity = GetFieldNameOfKey(entity.GetType());
                if (!string.IsNullOrEmpty(keyNameOfEntity))
                {
                    PropertyInfo keyOfEntity = entity.GetType().GetProperty(keyNameOfEntity, BindingFlags.Public | BindingFlags.Instance);
                    PropertyInfo createdDateOfEntity = entity.GetType().GetProperty("CreatedDate", BindingFlags.Public | BindingFlags.Instance);
                    PropertyInfo updatedDateOfEntity = entity.GetType().GetProperty("UpdatedDate", BindingFlags.Public | BindingFlags.Instance);
                    PropertyInfo deletedDateOfEntity = entity.GetType().GetProperty("DeletedDate", BindingFlags.Public | BindingFlags.Instance);
                    PropertyInfo createdUserOfEntity = entity.GetType().GetProperty("CreatedUser", BindingFlags.Public | BindingFlags.Instance);
                    PropertyInfo updatedUserOfEntity = entity.GetType().GetProperty("UpdatedUser", BindingFlags.Public | BindingFlags.Instance);
                    PropertyInfo deletedUserOfEntity = entity.GetType().GetProperty("DeletedUser", BindingFlags.Public | BindingFlags.Instance);
                    PropertyInfo isDeletedOfEntity = entity.GetType().GetProperty("IsDeleted", BindingFlags.Public | BindingFlags.Instance);

                    var events = ((dynamic)entity).GetUncommittedEvents();

                    foreach (var domainEvent in events)
                    {
                        string keyNameOfEvent = GetFieldNameOfKey(domainEvent.GetType());
                        if (!string.IsNullOrEmpty(keyNameOfEvent))
                        {
                            // Key
                            PropertyInfo keyOfEvent = domainEvent.GetType().GetProperty(keyNameOfEvent, BindingFlags.Public | BindingFlags.Instance);
                            if (null != keyOfEvent && keyOfEvent.CanWrite && keyOfEntity.GetType().FullName == keyOfEvent.GetType().FullName)
                            {
                                keyOfEvent.SetValue(domainEvent, keyOfEntity.GetValue(entity), null);
                            }
                            // CreatedDate
                            PropertyInfo createdDateOfEvent = domainEvent.GetType().GetProperty("CreatedDate", BindingFlags.Public | BindingFlags.Instance);
                            if (null != createdDateOfEvent && createdDateOfEvent.CanWrite)
                            {
                                createdDateOfEvent.SetValue(domainEvent, createdDateOfEntity.GetValue(entity), null);
                            }
                            // UpdatedDate
                            PropertyInfo updatedDateOfEvent = domainEvent.GetType().GetProperty("UpdatedDate", BindingFlags.Public | BindingFlags.Instance);
                            if (null != updatedDateOfEvent && updatedDateOfEvent.CanWrite)
                            {
                                updatedDateOfEvent.SetValue(domainEvent, updatedDateOfEntity.GetValue(entity), null);
                            }

                            // DeletedDate
                            PropertyInfo deletedDateOfEvent = domainEvent.GetType().GetProperty("DeletedDate", BindingFlags.Public | BindingFlags.Instance);
                            if (null != deletedDateOfEvent && deletedDateOfEvent.CanWrite)
                            {
                                deletedDateOfEvent.SetValue(domainEvent, deletedDateOfEntity.GetValue(entity), null);
                            }

                            // CreatedUser
                            PropertyInfo createdUserOfEvent = domainEvent.GetType().GetProperty("CreatedUser", BindingFlags.Public | BindingFlags.Instance);
                            if (null != createdUserOfEvent && createdUserOfEvent.CanWrite)
                            {
                                createdUserOfEvent.SetValue(domainEvent, createdUserOfEntity.GetValue(entity), null);
                            }
                            // UpdatedUser
                            PropertyInfo updatedUserOfEvent = domainEvent.GetType().GetProperty("UpdatedUser", BindingFlags.Public | BindingFlags.Instance);
                            if (null != updatedUserOfEvent && updatedUserOfEvent.CanWrite)
                            {
                                updatedUserOfEvent.SetValue(domainEvent, updatedUserOfEntity.GetValue(entity), null);
                            }

                            // DeletedUser
                            PropertyInfo deletedUserOfEvent = domainEvent.GetType().GetProperty("DeletedUser", BindingFlags.Public | BindingFlags.Instance);
                            if (null != deletedUserOfEvent && deletedUserOfEvent.CanWrite)
                            {
                                deletedUserOfEvent.SetValue(domainEvent, deletedUserOfEntity.GetValue(entity), null);
                            }

                            // IsDeleted
                            PropertyInfo isDeletedUserOfEvent = domainEvent.GetType().GetProperty("IsDeleted", BindingFlags.Public | BindingFlags.Instance);
                            if (null != isDeletedUserOfEvent && isDeletedUserOfEvent.CanWrite)
                            {
                                isDeletedUserOfEvent.SetValue(domainEvent, isDeletedOfEntity.GetValue(entity), null);
                            }

                            domainEventDispatcher.Dispatch(domainEvent);
                        }
                    }

                    ((dynamic)entity).GetUncommittedEvents().Clear();
                }
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction? dbTransaction = null)
        {
            return await Connection.QueryAsync<T>(sql, param, dbTransaction);
        }
    }
}