using System;
using System.Linq.Expressions;
using Events.Data.Specification;

namespace Events.Data
{
    public class IsPremiumEventSpecification : Specification<Event>
    {
        //TODO : 02 - Implemento la validacion de Evento mediante Specification
        private const int DiffeceOfDays = 2;
        public override Expression<Func<Event, bool>> ToExpression()
        {
            return x => x.Premium;
        }
    }
}