using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SQLite
{
    public class MemberRepository : SqlServer.MemberRepository
    {
        public MemberRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
