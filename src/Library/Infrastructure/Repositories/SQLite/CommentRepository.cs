using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SQLite
{
    public class CommentRepository : SqlServer.CommentRepository
    {
        public CommentRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
