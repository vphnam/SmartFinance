using SmartFinance.Domain.Shared.Base.Event;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Shared.Base
{
    public abstract class EntityBase<TId>
    {
        public TId Id { get; protected set; }

        private readonly List<IDomainEvent> _domainEvents = new();

        public IReadOnlyCollection<IDomainEvent> DomainEvents
            => _domainEvents.AsReadOnly();

        protected EntityBase()
        {
        }

        protected EntityBase(TId id)
        {
            Id = id;
        }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not EntityBase<TId> other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Id!.Equals(other.Id);
        }

        public override int GetHashCode()
            => Id!.GetHashCode();
    }
}
