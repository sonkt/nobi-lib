using GbLib.Base;
using GbLib.Base.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.DapperOrm.Entities
{
    public abstract class AuditEntity<TKey> : DeleteEntity<TKey>, IAuditEntity<TKey>
    {
        #region Properties
        [IgnoreUpdate]
        public DateTime CreatedDate { get; set; }

        [IgnoreUpdate]
        public Guid CreatedUser { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedUser { get; set; }

        public string? Description { get; set; }

        [IgnoreUpdate]
        [IgnoreInsert]
        public Guid? DeletedUser { get; set; }

        [IgnoreUpdate]
        [IgnoreInsert]
        public DateTime? DeletedDate { get; set; }

        #endregion Properties
    }

    public abstract class DeleteEntity<TKey> : EntityBase<TKey>, IDeleteEntity<TKey>
    {
        #region Properties

        public bool? IsDeleted { get; set; }

        #endregion Properties
    }
    public abstract class EntityBase<TKey> : IEntityBase<TKey>, IDisposable
    {
        #region Fields

        private readonly IDictionary<Type, Action<object>> _handlers = new ConcurrentDictionary<Type, Action<object>>();

        private readonly List<IEvent> _uncommittedEvents = new List<IEvent>();

        #endregion Fields

        #region Properties

        [Key]
        public virtual TKey Id { get; set; }

        #endregion Properties

        #region Methods

        public EntityBase<TKey> AddEvent(IEvent uncommittedEvent)
        {
            _uncommittedEvents.Add(uncommittedEvent);
            ApplyEvent(uncommittedEvent);
            return this;
        }

        public EntityBase<TKey> ApplyEvent(IEvent payload)
        {
            if (!_handlers.ContainsKey(payload.GetType()))
                return this;
            _handlers[payload.GetType()]?.Invoke(payload);
            return this;
        }

        public void ClearUncommittedEvents()
        {
            _uncommittedEvents.Clear();
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public List<IEvent> GetUncommittedEvents()
        {
            return _uncommittedEvents;
        }

        public EntityBase<TKey> RegisterHandler<T>(Action<T> handler)
        {
            _handlers.Add(typeof(T), e => handler((T)e));
            return this;
        }

        public EntityBase<TKey> RemoveEvent(IEvent @event)
        {
            if (_uncommittedEvents.Find(e => e == @event) != null)
                _uncommittedEvents.Remove(@event);
            return this;
        }

        #endregion Methods
    }
}
