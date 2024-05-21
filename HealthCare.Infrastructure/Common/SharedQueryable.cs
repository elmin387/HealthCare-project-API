using HealthCare.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace HealthCare.Infrastructure.Common
{
    public static class SharedQueryable
    {
        private const string IS_NOT_DELETED_PROPERTY = "isDeleted";
        private const string IS_USER_CREATED_ID = @"UserCreatedId == ""{0}""";
        private const string IS_USER_CREATED_ID_OR_UNASSIGNED = @"UserCreatedId == ""{0}"" || UserCreatedId == null";
        public static string SORT_ORDER_DESC => "DESC";
        public static string SORT_ORDER_ASC => "ASC";


        /// <summary>
        /// Filters all undeleted records. Use it for always global filtering.
        /// </summary>
        /// <typeparam name="T">Type of queryable</typeparam>
        /// <param name="query">Queryable to filter</param>
        /// <returns>Returns undeleted records</returns>
        public static IQueryable<T> GlobalFilter<T>(this IQueryable<T> query)
        {
            // Parameter for the lambda expression (e.g., x => x.isDeleted != true)
            var parameter = Expression.Parameter(typeof(T), "x");

            // Expression to access the 'isDeleted' property
            var property = Expression.Property(parameter, IS_NOT_DELETED_PROPERTY);

            // Expression to represent the comparison (isDeleted != true)
            var comparison = Expression.NotEqual(property, Expression.Constant(true));

            // Compile the expression into a lambda expression of type Func<T, bool>
            var lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter);

            // Use the lambda expression in the Where method
            return query.Where(lambda);
        }
        public static IQueryable<T> Sort<T>(this IQueryable<T> query, BaseFilter request)
        {
            if (!string.IsNullOrEmpty(request.SortBy))
            {
                return query.SortBy(
                    request.SortBy,
                    request.SortOrder);
            }

            return query;
        }
        /// <summary>
        /// Sort by column name and order it based on sortOrder value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public static IQueryable<T> SortBy<T>(this IQueryable<T> source, string sortColumn, string? sortOrder)
        {
            sortOrder = sortOrder?.Trim().ToUpper();

            if (sortOrder != SORT_ORDER_ASC && sortOrder != SORT_ORDER_DESC)
            {
                sortOrder = SORT_ORDER_ASC;
            }

            return source.OrderBy($"{sortColumn} {sortOrder}");
        }
        public static IQueryable<T> SortPaginate<T>(this IQueryable<T> query, BaseFilter request, BaseGridResponse response)
        {
            return query
                .Sort(request)
                .Paginate(request, response);
        }
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, BaseFilter request, BaseGridResponse response)
        {
            if (response == null)
                response = new BaseGridResponse();

            int count = query.Count();

            request.PageSize = request.TakeAll ? count : request.PageSize;
            request.PageNumber = request.TakeAll ? 1 : request.PageNumber;

            response.TotalRecords = count;
            response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);

            return query
                .Skip(--request.PageNumber * request.PageSize)
                .Take(request.PageSize);
        }
    }
}
