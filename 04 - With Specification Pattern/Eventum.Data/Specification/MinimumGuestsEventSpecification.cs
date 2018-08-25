using System;
using System.Linq.Expressions;

namespace Eventum.Data.Specification
{
    public class MinimumGuestsEventSpecification : Specification<Event>
    {
        private readonly int _minimumGuests;

        //TODO : 05 - Implemento la validacion para minimo de invitados Specification

        public MinimumGuestsEventSpecification(int minimumGuests)
        {
            _minimumGuests = minimumGuests;
        }
        public override Expression<Func<Event, bool>> ToExpression()
        {
            return x => x.Guests >= _minimumGuests;
        }
    }
}