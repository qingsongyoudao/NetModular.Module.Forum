using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Forum.Domain.Category;
using NetModular.Module.Forum.Domain.Category.Models;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SqlServer
{
    public class CategoryRepository : RepositoryAbstract<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<CategoryEntity>> Query(CategoryQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();

            if (!paging.OrderBy.Any())
            {
                query.OrderByDescending(m => m.Id);
            }

            var result = await query.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;

            return result;
        }
    }
}
