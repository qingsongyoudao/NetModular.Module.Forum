using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.MySql
{
    public class CategoryRepository : SqlServer.CategoryRepository
    {
        public CategoryRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}