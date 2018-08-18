using System;
using System.Linq.Expressions;

namespace Movies.Data
{
    //TODO: 03 - Implemento un GenericSpecification
    public class GenericSpecification<T>
    {
        public Expression<Func<T, bool>> Expression { get; }

        public GenericSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public bool IsSatisfiedBy(T entity) =>
            Expression.Compile().Invoke(entity);
    }
}