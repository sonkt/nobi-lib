using Dapper;
using GbLib.Base.Helpers;
using GbLib.Entities;
using GbLib.Entities.Context;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq.Expressions;

namespace GbLib.Repositories
{
    public class DapperOrmRepository<TEntity, TId> : DapperRepository<TEntity>, IDapperOrmRepository<TEntity, TId>
         where TEntity : class, IAuditEntity<TId>
    {
        public DapperOrmRepository(IDbConnectionFactory dbConnectionFactory, ISqlGenerator<TEntity> sqlGenerator) : base(dbConnectionFactory.OpenDbConnection(), sqlGenerator)
        {
        }

        public override bool Insert(TEntity instance)
        {
            ModifyCreatedInstance(instance);
            return base.Insert(instance);
        }

        public override bool Insert(TEntity instance, IDbTransaction? transaction)
        {
            ModifyCreatedInstance(instance);
            return base.Insert(instance, transaction);
        }

        public override Task<bool> InsertAsync(TEntity instance, CancellationToken cancellationToken)
        {
            ModifyCreatedInstance(instance);
            return base.InsertAsync(instance, cancellationToken);
        }

        public override Task<bool> InsertAsync(TEntity instance, IDbTransaction? transaction, CancellationToken cancellationToken)
        {
            ModifyCreatedInstance(instance);
            return base.InsertAsync(instance, transaction, cancellationToken);
        }

        public override int BulkInsert(IEnumerable<TEntity> instances)
        {
            ModifyCreatedInstances(instances);
            return base.BulkInsert(instances);
        }

        public override int BulkInsert(IEnumerable<TEntity> instances, IDbTransaction? transaction)
        {
            ModifyCreatedInstances(instances);
            return base.BulkInsert(instances, transaction);
        }

        public override Task<int> BulkInsertAsync(IEnumerable<TEntity> instances, CancellationToken cancellationToken)
        {
            ModifyCreatedInstances(instances);
            return base.BulkInsertAsync(instances, cancellationToken);
        }

        public override Task<int> BulkInsertAsync(IEnumerable<TEntity> instances, IDbTransaction? transaction, CancellationToken cancellationToken)
        {
            ModifyCreatedInstances(instances);
            return base.BulkInsertAsync(instances, transaction, cancellationToken);
        }

        public override bool Delete(TEntity instance)
        {
            ModifyDeletedInstance(instance);
            return base.Delete(instance);
        }

        public override bool Delete(TEntity instance, TimeSpan? timeout)
        {
            ModifyDeletedInstance(instance);
            return base.Delete(instance, timeout);
        }

        public override bool Delete(TEntity instance, IDbTransaction? transaction, TimeSpan? timeout)
        {
            ModifyDeletedInstance(instance);
            return base.Delete(instance, transaction, timeout);
        }

        public override Task<bool> DeleteAsync(TEntity instance, CancellationToken cancellationToken = default)
        {
            ModifyDeletedInstance(instance);
            return base.DeleteAsync(instance, cancellationToken);
        }

        public override Task<bool> DeleteAsync(TEntity instance, IDbTransaction? transaction, TimeSpan? timeout, CancellationToken cancellationToken = default)
        {
            ModifyDeletedInstance(instance);
            return base.DeleteAsync(instance, transaction, timeout, cancellationToken);
        }

        public override Task<bool> DeleteAsync(TEntity instance, TimeSpan? timeout, CancellationToken cancellationToken = default)
        {
            ModifyDeletedInstance(instance);
            return base.DeleteAsync(instance, timeout, cancellationToken);
        }

        public override bool Update(TEntity instance, IDbTransaction? transaction, params Expression<Func<TEntity, object>>[] includes)
        {
            ModifyUpdatedInstance(instance);
            return base.Update(instance, transaction, includes);
        }

        public override bool Update(TEntity instance, params Expression<Func<TEntity, object>>[] includes)
        {
            ModifyUpdatedInstance(instance);
            return base.Update(instance, includes);
        }

        public override bool Update(Expression<Func<TEntity, bool>>? predicate, TEntity instance, IDbTransaction? transaction, params Expression<Func<TEntity, object>>[] includes)
        {
            ModifyUpdatedInstance(instance);
            return base.Update(predicate, instance, transaction, includes);
        }

        public override bool Update(Expression<Func<TEntity, bool>>? predicate, TEntity instance, params Expression<Func<TEntity, object>>[] includes)
        {
            ModifyUpdatedInstance(instance);
            return base.Update(predicate, instance, includes);
        }

        public override Task<bool> UpdateAsync(Expression<Func<TEntity, bool>>? predicate, TEntity instance, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes)
        {
            ModifyUpdatedInstance(instance);
            return base.UpdateAsync(predicate, instance, cancellationToken, includes);
        }

        public override Task<bool> UpdateAsync(Expression<Func<TEntity, bool>>? predicate, TEntity instance, IDbTransaction? transaction, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes)
        {
            ModifyUpdatedInstance(instance);
            return base.UpdateAsync(predicate, instance, transaction, cancellationToken, includes);
        }

        public override Task<bool> UpdateAsync(Expression<Func<TEntity, bool>>? predicate, TEntity instance, IDbTransaction? transaction, params Expression<Func<TEntity, object>>[] includes)
        {
            ModifyUpdatedInstance(instance);
            return base.UpdateAsync(predicate, instance, transaction, includes);
        }

        public override Task<bool> UpdateAsync(Expression<Func<TEntity, bool>>? predicate, TEntity instance, params Expression<Func<TEntity, object>>[] includes)
        {
            ModifyUpdatedInstance(instance);
            return base.UpdateAsync(predicate, instance, includes);
        }

        public override Task<bool> UpdateAsync(TEntity instance, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes)
        {
            ModifyUpdatedInstance(instance);
            return base.UpdateAsync(instance, cancellationToken, includes);
        }

        public override Task<bool> UpdateAsync(TEntity instance, IDbTransaction? transaction, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes)
        {
            ModifyUpdatedInstance(instance);
            return base.UpdateAsync(instance, transaction, cancellationToken, includes);
        }

        public override Task<bool> UpdateAsync(TEntity instance, IDbTransaction? transaction, params Expression<Func<TEntity, object>>[] includes)
        {
            ModifyUpdatedInstance(instance);
            return base.UpdateAsync(instance, transaction, includes);
        }

        public override Task<bool> UpdateAsync(TEntity instance, params Expression<Func<TEntity, object>>[] includes)
        {
            ModifyUpdatedInstance(instance);
            return base.UpdateAsync(instance, includes);
        }

        public override bool BulkUpdate(IEnumerable<TEntity> instances)
        {
            ModifyUpdatedInstances(instances);
            return base.BulkUpdate(instances);
        }

        public override bool BulkUpdate(IEnumerable<TEntity> instances, IDbTransaction? transaction)
        {
            ModifyUpdatedInstances(instances);
            return base.BulkUpdate(instances, transaction);
        }

        public override Task<bool> BulkUpdateAsync(IEnumerable<TEntity> instances)
        {
            ModifyUpdatedInstances(instances);
            return base.BulkUpdateAsync(instances);
        }

        public override Task<bool> BulkUpdateAsync(IEnumerable<TEntity> instances, CancellationToken cancellationToken)
        {
            ModifyUpdatedInstances(instances);
            return base.BulkUpdateAsync(instances, cancellationToken);
        }

        public override Task<bool> BulkUpdateAsync(IEnumerable<TEntity> instances, IDbTransaction? transaction)
        {
            ModifyUpdatedInstances(instances);
            return base.BulkUpdateAsync(instances, transaction);
        }

        public override Task<bool> BulkUpdateAsync(IEnumerable<TEntity> instances, IDbTransaction? transaction, CancellationToken cancellationToken)
        {
            foreach (TEntity instance in instances)
            {
                ModifyUpdatedInstance(instance);
            }
            return base.BulkUpdateAsync(instances, transaction, cancellationToken);
        }

        private void ModifyUpdatedInstance(TEntity instance)
        {
            SetMinDateIfNull(instance);
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IAuditEntity)instance).UpdatedDate = DateTime.UtcNow;
            }
            AutoGuidKeyValueIfNullOrEmpty(instance);
        }

        private void ModifyDeletedInstance(TEntity instance)
        {
            if (typeof(IDeleteEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IDeleteEntity)instance).IsDeleted = true;
                instance.DeletedDate = DateTime.Now;
                SetMinDateIfNull(instance);
            }
            AutoGuidKeyValueIfNullOrEmpty(instance);
        }

        private void ModifyCreatedInstance(TEntity instance)
        {
            SetMinDateIfNull(instance);
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IAuditEntity)instance).CreatedDate = DateTime.UtcNow;
            }
            AutoGuidKeyValueIfNullOrEmpty(instance);
        }

        private void ModifyUpdatedInstances(IEnumerable<TEntity> instances)
        {
            foreach (TEntity instance in instances)
            {
                ModifyUpdatedInstance(instance);
                AutoGuidKeyValueIfNullOrEmpty(instance);
            }
        }

        private void ModifyCreatedInstances(IEnumerable<TEntity> instances)
        {
            foreach (TEntity instance in instances)
            {
                ModifyCreatedInstance(instance);
                AutoGuidKeyValueIfNullOrEmpty(instance);
            }
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
    }
}