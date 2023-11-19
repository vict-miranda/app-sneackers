using System.Linq.Expressions;

namespace AppSneackers.Domain.Common.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, IEnumerable<SortBy> sortModels)
        {
            var expression = source.Expression;
            var count = 0;
            foreach (var item in sortModels)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var selector = Expression.PropertyOrField(parameter, item.Key);
                var method = string.Equals(item.Order, "desc", StringComparison.OrdinalIgnoreCase) ?
                    count == 0 ? "OrderByDescending" : "ThenByDescending" :
                    count == 0 ? "OrderBy" : "ThenBy";
                expression = Expression.Call(typeof(Queryable), method,
                    new[] { source.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));
                count++;
            }
            return count > 0 ? source.Provider.CreateQuery<T>(expression) : source;
        }
    }
}
