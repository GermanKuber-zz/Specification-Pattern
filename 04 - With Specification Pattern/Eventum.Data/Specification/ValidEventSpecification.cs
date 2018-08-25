using System;
using System.Linq.Expressions;

namespace Eventum.Data.Specification
{
    public class ValidEventSpecification : Specification<Event>
    {
        //TODO : 01 - Implemento la validacion de Evento mediante Specification
        private const int DiffeceOfDays = 2;
        public override Expression<Func<Event, bool>> ToExpression()
        {
            return x => (x.EventDate - DateTime.Now).Days >= DiffeceOfDays
                        &&
                        x.Validated;
        }
    }
}