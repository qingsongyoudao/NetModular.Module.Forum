using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SQLite
{
    public class TopicTagRepository : SqlServer.TopicTagRepository
    {
        public TopicTagRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
