using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public static class QueryableExtensions
{
    
    public static IQueryable<T> ApplySearch<T>(
        this IQueryable<T> query,
        string? search,
        params Expression<Func<T, string>>[] fields)
    {
        if (string.IsNullOrWhiteSpace(search) || fields.Length == 0)
            return query;

        var parameter = Expression.Parameter(typeof(T), "x");
        Expression? body = null;

        var toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes)!;
        var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;

        var searchConstant = Expression.Constant(search.ToLower());

        foreach (var field in fields)
        {
            var property = Expression.Invoke(field, parameter);

            
            var notNull = Expression.NotEqual(property, Expression.Constant(null));

            
            var toLower = Expression.Call(property, toLowerMethod);
            var contains = Expression.Call(toLower, containsMethod, searchConstant);

            var safeContains = Expression.AndAlso(notNull, contains);

            body = body == null ? safeContains : Expression.OrElse(body, safeContains);
        }

        var lambda = Expression.Lambda<Func<T, bool>>(body!, parameter);
        return query.Where(lambda);
    }


    public static IQueryable<T> ApplySorting<T>(
        this IQueryable<T> query,
        string? sortBy,
        bool isDescending)
    {
        if (string.IsNullOrWhiteSpace(sortBy))
            return query;

        var property = typeof(T).GetProperty(sortBy);
        if (property == null)
            return query; 

        return isDescending
            ? query.OrderByDescending(e => EF.Property<object>(e, sortBy))
            : query.OrderBy(e => EF.Property<object>(e, sortBy));
    }

    public static IQueryable<T> ApplyPagination<T>(
        this IQueryable<T> query,
        int pageNumber,
        int pageSize)
    {
        if (pageNumber <= 0) pageNumber = 1;
        if (pageSize <= 0) pageSize = 10;

        return query.Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);
    }
}