using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.MySql
{
    public class TopicTagRepository : SqlServer.TopicTagRepository
    {
        public TopicTagRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}