    using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.PostgreSQL
{
    public class QuestionRepository : SqlServer.QuestionRepository
    {
        public QuestionRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}