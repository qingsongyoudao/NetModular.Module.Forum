using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SQLite
{
    public class MarkRepository : SqlServer.MarkRepository
    {
        public MarkRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
