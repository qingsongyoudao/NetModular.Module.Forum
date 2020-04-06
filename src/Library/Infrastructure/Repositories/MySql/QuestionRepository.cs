using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.MySql
{
    public class QuestionRepository : SqlServer.QuestionRepository
    {
        public QuestionRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}