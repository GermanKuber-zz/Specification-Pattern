using System;
using System.Linq.Expressions;

namespace Events.Data
{
    public abstract class Specification<T>
    {
        //TODO : 04 - Implemento un Specification base
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            return ToExpression().Compile().Invoke(entity);
        }
    }
}