using News.Domain;
using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class AggregateRoot<T> : Entity<T>
    {
        private readonly List<Event> _changes = new List<Event>();

        public int Version { get; private set; }

        public IEnumerable<Event> UncommittedChanges => _changes;

        public bool IsNew => Version == default;

        public void MarkChangeAsCommitted(Event @event)
        {
            Guard.NotNull(@event, nameof(@event));

            _changes.Remove(@event);
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<DomainEvent> history)
        {
            foreach (var e in history)
            {
                ApplyChange(e, false);
            }
        }

        public virtual string StreamName => $"{GetType().FullName}-{Id}";

        protected void ApplyChange(DomainEvent @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(DomainEvent @event, bool isNew)
        {
            this.AsDynamic().Apply(@event);

            if (isNew)
            {
                _changes.Add(@event);
            }

            Version++;
        }
    }
}