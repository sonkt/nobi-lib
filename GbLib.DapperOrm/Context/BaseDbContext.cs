using GbLib.Base;
using GbLib.DapperOrm.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GbLib.DapperOrm.Context
{
    public class BaseDbContext : DbContext
    {
        #region Fields

        private readonly IDomainEventDispatcher _domainEventDispatcher;

        #endregion Fields

        #region Constructors

        protected BaseDbContext(DbContextOptions options, IDomainEventDispatcher domainEventDispatcher)
         : base(options)
        {
            _domainEventDispatcher = domainEventDispatcher;
        }

        #endregion Constructors

        #region Methods

        public override int SaveChanges()
        {
            var result = base.SaveChanges();
            SaveChangesWithEvents(_domainEventDispatcher);
            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            bool saveFailed;
            int result = 0;
            do
            {
                saveFailed = false;
                try
                {
                    result = await base.SaveChangesAsync(cancellationToken);
                    SaveChangesWithEvents(_domainEventDispatcher);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }
            } while (saveFailed);

            return result;
        }

        private string GetFieldNameOfKey(Type type)
        {
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute is Base.Attributes.KeyAttribute || attribute is KeyAttribute)
                    {
                        return property.Name;
                    }
                }
            }
            return "";
        }

        private void SaveChangesWithEvents(IDomainEventDispatcher domainEventDispatcher)
        {
            var entities = ChangeTracker.Entries().Select(e => e.Entity);
            entities
                .Where(e =>
                    e.GetType().BaseType.IsGenericType &&
                    typeof(AuditEntity<>).IsAssignableFrom(e.GetType().BaseType.GetGenericTypeDefinition()))
                .Select(entity =>
                {
                    string keyNameOfEntity = GetFieldNameOfKey(entity.GetType());
                    if (!string.IsNullOrEmpty(keyNameOfEntity))
                    {
                        PropertyInfo keyOfEntity = entity.GetType().GetProperty(keyNameOfEntity, BindingFlags.Public | BindingFlags.Instance);
                        PropertyInfo createdDateOfEntity = entity.GetType().GetProperty("CreatedDate", BindingFlags.Public | BindingFlags.Instance);
                        PropertyInfo updatedDateOfEntity = entity.GetType().GetProperty("UpdatedDate", BindingFlags.Public | BindingFlags.Instance);
                        PropertyInfo createdUserOfEntity = entity.GetType().GetProperty("CreatedUser", BindingFlags.Public | BindingFlags.Instance);
                        PropertyInfo updatedUserOfEntity = entity.GetType().GetProperty("UpdatedUser", BindingFlags.Public | BindingFlags.Instance);
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
                                // CreatedDate
                                PropertyInfo updatedDateOfEvent = domainEvent.GetType().GetProperty("UpdatedDate", BindingFlags.Public | BindingFlags.Instance);
                                if (null != updatedDateOfEvent && updatedDateOfEvent.CanWrite)
                                {
                                    updatedDateOfEvent.SetValue(domainEvent, updatedDateOfEntity.GetValue(entity), null);
                                }

                                // CreatedUser
                                PropertyInfo createdUserOfEvent = domainEvent.GetType().GetProperty("CreatedUser", BindingFlags.Public | BindingFlags.Instance);
                                if (null != createdUserOfEvent && createdUserOfEvent.CanWrite)
                                {
                                    createdUserOfEvent.SetValue(domainEvent, createdUserOfEntity.GetValue(entity), null);
                                }
                                // CreatedUser
                                PropertyInfo updatedUserOfEvent = domainEvent.GetType().GetProperty("UpdatedUser", BindingFlags.Public | BindingFlags.Instance);
                                if (null != updatedUserOfEvent && updatedUserOfEvent.CanWrite)
                                {
                                    updatedUserOfEvent.SetValue(domainEvent, updatedUserOfEntity.GetValue(entity), null);
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
                    return entity;
                })
                .ToArray();
            entities
               .Where(e =>
                   e.GetType().BaseType.IsGenericType &&
                   typeof(DeleteEntity<>).IsAssignableFrom(e.GetType().BaseType.GetGenericTypeDefinition()))
               .Select(entity =>
               {
                   string keyNameOfEntity = GetFieldNameOfKey(entity.GetType());
                   if (!string.IsNullOrEmpty(keyNameOfEntity))
                   {
                       PropertyInfo keyOfEntity = entity.GetType().GetProperty(keyNameOfEntity, BindingFlags.Public | BindingFlags.Instance);
                       PropertyInfo createdDateOfEntity = entity.GetType().GetProperty("CreatedDate", BindingFlags.Public | BindingFlags.Instance);
                       PropertyInfo updatedDateOfEntity = entity.GetType().GetProperty("UpdatedDate", BindingFlags.Public | BindingFlags.Instance);
                       PropertyInfo createdUserOfEntity = entity.GetType().GetProperty("CreatedUser", BindingFlags.Public | BindingFlags.Instance);
                       PropertyInfo updatedUserOfEntity = entity.GetType().GetProperty("UpdatedUser", BindingFlags.Public | BindingFlags.Instance);
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
                               // CreatedDate
                               PropertyInfo updatedDateOfEvent = domainEvent.GetType().GetProperty("UpdatedDate", BindingFlags.Public | BindingFlags.Instance);
                               if (null != updatedDateOfEvent && updatedDateOfEvent.CanWrite)
                               {
                                   updatedDateOfEvent.SetValue(domainEvent, updatedDateOfEntity.GetValue(entity), null);
                               }

                               // CreatedUser
                               PropertyInfo createdUserOfEvent = domainEvent.GetType().GetProperty("CreatedUser", BindingFlags.Public | BindingFlags.Instance);
                               if (null != createdUserOfEvent && createdUserOfEvent.CanWrite)
                               {
                                   createdUserOfEvent.SetValue(domainEvent, createdUserOfEntity.GetValue(entity), null);
                               }
                               // CreatedUser
                               PropertyInfo updatedUserOfEvent = domainEvent.GetType().GetProperty("UpdatedUser", BindingFlags.Public | BindingFlags.Instance);
                               if (null != updatedUserOfEvent && updatedUserOfEvent.CanWrite)
                               {
                                   updatedUserOfEvent.SetValue(domainEvent, updatedUserOfEntity.GetValue(entity), null);
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
                   return entity;
               })
               .ToArray();
            entities
               .Where(e =>
                   e.GetType().BaseType.IsGenericType &&
                   typeof(EntityBase<>).IsAssignableFrom(e.GetType().BaseType.GetGenericTypeDefinition()))
               .Select(entity =>
               {
                   string keyNameOfEntity = GetFieldNameOfKey(entity.GetType());
                   if (!string.IsNullOrEmpty(keyNameOfEntity))
                   {
                       PropertyInfo keyOfEntity = entity.GetType().GetProperty(keyNameOfEntity, BindingFlags.Public | BindingFlags.Instance);
                       PropertyInfo createdDateOfEntity = entity.GetType().GetProperty("CreatedDate", BindingFlags.Public | BindingFlags.Instance);
                       PropertyInfo updatedDateOfEntity = entity.GetType().GetProperty("UpdatedDate", BindingFlags.Public | BindingFlags.Instance);
                       PropertyInfo createdUserOfEntity = entity.GetType().GetProperty("CreatedUser", BindingFlags.Public | BindingFlags.Instance);
                       PropertyInfo updatedUserOfEntity = entity.GetType().GetProperty("UpdatedUser", BindingFlags.Public | BindingFlags.Instance);
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
                               // CreatedDate
                               PropertyInfo updatedDateOfEvent = domainEvent.GetType().GetProperty("UpdatedDate", BindingFlags.Public | BindingFlags.Instance);
                               if (null != updatedDateOfEvent && updatedDateOfEvent.CanWrite)
                               {
                                   updatedDateOfEvent.SetValue(domainEvent, updatedDateOfEntity.GetValue(entity), null);
                               }

                               // CreatedUser
                               PropertyInfo createdUserOfEvent = domainEvent.GetType().GetProperty("CreatedUser", BindingFlags.Public | BindingFlags.Instance);
                               if (null != createdUserOfEvent && createdUserOfEvent.CanWrite)
                               {
                                   createdUserOfEvent.SetValue(domainEvent, createdUserOfEntity.GetValue(entity), null);
                               }
                               // CreatedUser
                               PropertyInfo updatedUserOfEvent = domainEvent.GetType().GetProperty("UpdatedUser", BindingFlags.Public | BindingFlags.Instance);
                               if (null != updatedUserOfEvent && updatedUserOfEvent.CanWrite)
                               {
                                   updatedUserOfEvent.SetValue(domainEvent, updatedUserOfEntity.GetValue(entity), null);
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
                   return entity;
               })
               .ToArray();
        }

        #endregion Methods
    }
}