using System;
using System.Linq.Expressions;

namespace Eventum.Data.Specification
{
    public class IsPremiumEventSpecification : Specification<Event>
    {
        public override Expression<Func<Event, bool>> ToExpression()
        {
            return x => x.Premium;
        }
    }
}