using System;
using System.Linq.Expressions;

namespace Events.Data.Specification
{
    public sealed class IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}