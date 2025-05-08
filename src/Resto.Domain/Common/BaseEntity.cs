using System.ComponentModel.DataAnnotations.Schema;

namespace Resto.Domain.Common
{
   public class BaseEntity<T>
    {
        public T Id { get; set; }

        [NotMapped]
        public readonly List<IBaseEvent> _domainEvent = new();

        public IReadOnlyCollection<IBaseEvent> DomainEvents => _domainEvent.AsReadOnly();

        public void AddDomainEvent (IBaseEvent domainEvent) => 
            _domainEvent.Add (domainEvent);

        public void RemoveDomainEvent(IBaseEvent domainEvent )=>
            _domainEvent.Remove(domainEvent);

        public void ClearDomainEvents () => _domainEvent.Clear();


    }
}
