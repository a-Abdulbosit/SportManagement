using Newtonsoft.Json;
using SportManagement.Domain.Common;
using SportManagement.Domain.Configurations.Helpers;
using SportManagement.Domain.Configurations.Pagination;

namespace SportManagement.Domain.Configurations
{
    public static class ServicePagination
    {
        public static IQueryable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> entities, PaginationParams @params)
                    where TEntity : Auditable
        {
            var metaData = new PaginationMetaData(entities.Count(), @params);
            var json = JsonConvert.SerializeObject(metaData);

            if (HttpAccessor.ResponseHeaders != null)
            {
                if (HttpAccessor.ResponseHeaders.ContainsKey("X-Pagination"))
                    HttpAccessor.ResponseHeaders.Remove("X-Pagination");

                HttpAccessor.ResponseHeaders.Add("X-Pagination", json);
            }

            if (@params.PageIndex < 1 || @params.PageSize < 1)
                throw new Exception("Please, enter valid numbers");

            return @params.PageIndex > 0 && @params.PageSize > 0 ?
                entities.OrderBy(e => e.Id)
                        .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize) :
                              throw new Exception("Plese enter a valid number");
        }
    }
}
