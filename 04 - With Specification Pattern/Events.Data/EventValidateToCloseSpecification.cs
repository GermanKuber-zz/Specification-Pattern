using System;
using System.Linq.Expressions;
using Events.Data.Specification;

namespace Events.Data
{
    public class EventToCloseSpecification : Specification<Event>
    {
        //TODO : 04 - Implemento la validacion de Evento para poder cerralro
        private const int MinimumGuests = 15;

        public override Expression<Func<Event, bool>> ToExpression()
        {
            return x => x.Validated && x.Guests > MinimumGuests;
        }
    }
}