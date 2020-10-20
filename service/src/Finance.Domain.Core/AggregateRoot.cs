namespace Finance.Domain.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class AggregateRoot : Entity<Guid>
    {
        private static IList<IEvent> _domainEvents;

        protected AggregateRoot()
        {
            _domainEvents = new List<IEvent>();
        }

        public IReadOnlyCollection<IEvent> DomainEvents => _domainEvents.ToList();

        public virtual void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected virtual void AddDomainEvent(IEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}