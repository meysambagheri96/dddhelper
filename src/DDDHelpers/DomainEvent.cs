using Domain;
using System;

namespace News.Domain
{
    public abstract class DomainEvent : Event
    {
        protected DomainEvent()
        {
        }

        protected DomainEvent(Guid aggregateRootId)
        {
            Guard.NotNullOrDefault(aggregateRootId, nameof(aggregateRootId));

            this.AggregateRootId = aggregateRootId;
        }

        public Guid AggregateRootId { get; private set; }
    }
}
