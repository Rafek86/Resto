using MediatR;
namespace Resto.Infrastructure.Data.Interceptors
{
   public class DispatchDomainEventsInterceptor(IMediator mediator) : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            DispatchEventsAsync(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await DispatchEventsAsync(eventData.Context); 
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public async Task DispatchEventsAsync(DbContext? dbContext)
        {
            if(dbContext == null) return;

            var domainEntities = dbContext.ChangeTracker
                .Entries<AuditableEntity>()
                .Where(x => x.Entity.DomainEvents.Any())
                .Select(x => x.Entity);

            var domainEvents = domainEntities
                .SelectMany(x => x.DomainEvents)
                .ToList();

            domainEntities.ToList().ForEach(a => a.ClearDomainEvents());

            foreach (var d in domainEvents)
            {
                await mediator.Publish(d);
            }
        }
        
    }
}
