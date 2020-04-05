using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Forum.Domain.Member;
using NetModular.Module.Forum.Domain.Member.Models;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SqlServer
{
    public class MemberRepository : RepositoryAbstract<MemberEntity>, IMemberRepository
    {
        public MemberRepository(IDbContext context) : base(context)
        {
        }

        public bool ExistsEmail(string email)
        {
            return Db.Find().Where(w => w.Email == email).Exists();
        }

        public bool ExistsUserName(string userName)
        {
            return Db.Find().Where(w => w.UserName == userName).Exists();
        }

        public Task<MemberEntity> GetByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<MemberEntity>> Query(MemberQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();

            if (!paging.OrderBy.Any())
            {
                query.OrderByDescending(m => m.Id);
            }

            var result = await query.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;

            return result;
        }
    }
}
