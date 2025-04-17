using Resto.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Domain.Common.Models
{
   public class BaseEntity<T>
    {
        public T Id { get; set; }

        public readonly List<BaseEvent> _domainEvent = new();

        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvent.AsReadOnly();

        public void AddDomainEvent (BaseEvent domainEvent) => 
            _domainEvent.Add (domainEvent);

        public void RemoveDomainEvent(BaseEvent domainEvent )=>
            _domainEvent.Remove(domainEvent);

        public void ClearDomainEvents () => _domainEvent.Clear();


    }
}
