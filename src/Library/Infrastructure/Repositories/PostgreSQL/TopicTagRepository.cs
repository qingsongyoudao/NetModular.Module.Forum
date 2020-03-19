    using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.PostgreSQL
{
    public class TopicTagRepository : SqlServer.TopicTagRepository
    {
        public TopicTagRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}