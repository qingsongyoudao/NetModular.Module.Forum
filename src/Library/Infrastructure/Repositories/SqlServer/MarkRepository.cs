using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Forum.Domain.Mark;
using NetModular.Module.Forum.Domain.Mark.Models;
using NetModular.Module.Forum.Domain.Member;
using NetModular.Module.Forum.Domain.Topic;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SqlServer
{
    public class MarkRepository : RepositoryAbstract<MarkEntity>, IMarkRepository
    {
        public MarkRepository(IDbContext context) : base(context)
        {
        }

        public Task<long> Count(int RelationId, MarkType type)
        {
            return Db.Find(m => m.RelationId == RelationId && m.Type == type).CountAsync();
        }

        public async Task<IList<MarkEntity>> Query(MarkQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();
            var joinQuery = query.LeftJoin<MemberEntity>((t1, t2) => t1.MemberId == t2.Id);

            joinQuery.Where((t1, t2) => t1.RelationId == model.RelationId);
            joinQuery.WhereNotNull(model.Type, (t1, t2) => t1.Type == model.Type);

            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderByDescending((t1, t2) => t1.Id);
            }

            joinQuery.Select((t1, t2) => new
            {
                t1,
                t2.NickName,
                t2.Avatar,
                t2.Sex
            });

            var result = await joinQuery.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;

            return result;
        }
    }
}
