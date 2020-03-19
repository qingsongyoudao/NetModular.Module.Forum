using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.MySql
{
    public class TopicRepository : SqlServer.TopicRepository
    {
        public TopicRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}