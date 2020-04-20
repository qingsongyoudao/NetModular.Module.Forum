using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;

namespace NetModular.Module.Forum.Infrastructure.Repositories
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(IDbContextOptions options) : base(options)
        {
        }
    }
}
