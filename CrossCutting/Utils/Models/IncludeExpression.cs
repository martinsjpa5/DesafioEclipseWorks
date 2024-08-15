
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Utils.Models
{
    public class IncludeExpression<T>
    {
        public Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Expression { get; }

        public IncludeExpression(Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>> expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
    }
}
