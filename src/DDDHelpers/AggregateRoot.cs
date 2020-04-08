using News.Domain;
using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class AggregateRoot : Entity<Guid>
    {
        private readonly List<Event> _changes = new List<Event>();

        public int Version { get; private set; }

        public IEnumerable<Event> UncommittedChanges => _changes;

        public bool IsNew => this.Version == default;

        public void MarkChangeAsCommitted(Event @event)
        {
            Guard.NotNull(@event, nameof(@event));

            this._changes.Remove(@event);
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
            this.ThrowIfDeleted();
            this.AsDynamic().Apply(@event);

            if (isNew)
            {
                _changes.Add(@event);
            }

            Version++;
        }

        protected void ThrowIfDeleted()
        {
            if (this.Deleted)
            {
                throw new InvalidOperationException("No operation is allowed on a deleted object");
            }
        }
    }
}