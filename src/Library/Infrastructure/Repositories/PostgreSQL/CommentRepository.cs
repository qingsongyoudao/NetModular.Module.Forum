    using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.PostgreSQL
{
    public class CommentRepository : SqlServer.CommentRepository
    {
        public CommentRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}