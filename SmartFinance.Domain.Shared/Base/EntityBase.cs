using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Shared.Base
{
    public abstract class EntityBase<TId>
    {
        public TId Id { get; protected set; }
        protected EntityBase(TId id) 
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not EntityBase<TId> other)
                return false;
            if(ReferenceEquals(this, other)) return true;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
