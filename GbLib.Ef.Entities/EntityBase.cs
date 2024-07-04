using GbLib.Events;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;

namespace GbLib.Ef.Entities
{
    public abstract class EntityBase<TKey> : IDisposable
    {
        #region Fields

        private readonly IDictionary<Type, Action<object>> _handlers = new ConcurrentDictionary<Type, Action<object>>();
        private readonly List<IEvent> _uncommittedEvents = new List<IEvent>();

        #endregion Fields

        #region Properties

        [Key]
        public virtual TKey Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public Guid CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedUser { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid? DeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? Description { get; set; }
        public Guid? TenantId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        #endregion Properties

        #region Methods

        public void Dispose()
        {
            this.Dispose();
        }

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