namespace Finance.Infrastructure.Data
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Core;
    using NHibernate.Event;

    internal class EventListener :
        IPostInsertEventListener,
        IPostDeleteEventListener,
        IPostUpdateEventListener,
        IPostCollectionUpdateEventListener
    {
        public void OnPostDelete(PostDeleteEvent @event)
        {
            throw new NotImplementedException();
        }

        public async Task OnPostDeleteAsync(
            PostDeleteEvent @event,
            CancellationToken cancellationToken)
        {
            await DispatchEventsAsync(@event.Entity as AggregateRoot);
        }

        public void OnPostInsert(PostInsertEvent @event)
        {
            throw new NotImplementedException();
        }

        public async Task OnPostInsertAsync(
            PostInsertEvent @event,
            CancellationToken cancellationToken)
        {
            await DispatchEventsAsync(@event.Entity as AggregateRoot);
        }

        public void OnPostUpdate(PostUpdateEvent @event)
        {
            throw new NotImplementedException();
        }

        public async Task OnPostUpdateAsync(
            PostUpdateEvent @event,
            CancellationToken cancellationToken)
        {
            await DispatchEventsAsync(@event.Entity as AggregateRoot);
        }

        public void OnPostUpdateCollection(PostCollectionUpdateEvent @event)
        {
            throw new NotImplementedException();
        }

        public async Task OnPostUpdateCollectionAsync(
            PostCollectionUpdateEvent @event,
            CancellationToken cancellationToken)
        {
            await DispatchEventsAsync(@event.AffectedOwnerOrNull as AggregateRoot);
        }

        private async Task DispatchEventsAsync(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                return;

            foreach (var @event in aggregateRoot.DomainEvents)
            {
                await DomainEvents.Raise(@event);
            }

            aggregateRoot.ClearDomainEvents();
        }
    }
}