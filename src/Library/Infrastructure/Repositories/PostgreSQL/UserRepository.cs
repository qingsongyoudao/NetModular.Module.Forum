    using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.PostgreSQL
{
    public class UserRepository : SqlServer.UserRepository
    {
        public UserRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}