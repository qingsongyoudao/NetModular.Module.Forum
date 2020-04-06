using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SQLite
{
    public class QuestionRepository : SqlServer.QuestionRepository
    {
        public QuestionRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
