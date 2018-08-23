using System;
using System.Linq.Expressions;

namespace Events.Data
{
    public abstract class Specification<T>
    {
        //TODO : 01 - Implemento un Specification base
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            return ToExpression().Compile().Invoke(entity);
        }
    }

    public class ValidEventSpecification : Specification<Event>
    {
        //TODO : 02 - Implemento la validacion de Evento mediante Specification
        private const int DiffeceOfDays = 2;
        public override Expression<Func<Event, bool>> ToExpression()
        {
            return x => (x.EventDate - DateTime.Now).Days >= DiffeceOfDays
                        &&
                        x.Validated;
        }
    }
}