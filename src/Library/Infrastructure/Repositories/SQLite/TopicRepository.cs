using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SQLite
{
    public class TopicRepository : SqlServer.TopicRepository
    {
        public TopicRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
