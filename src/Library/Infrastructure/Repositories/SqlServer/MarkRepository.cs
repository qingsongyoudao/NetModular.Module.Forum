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

        public Task<long> Count(int TopicId, MarkType type)
        {
            return Db.Find(m => m.TopicId == TopicId && m.Type == type).CountAsync();
        }

        public async Task<IList<MarkEntity>> Query(MarkQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();
            var joinQuery = query.LeftJoin<TopicEntity>((t1, t2) => t1.TopicId == t2.Id)
                .LeftJoin<MemberEntity>((t1, t2, t3) => t1.UserId == t3.Id);

            joinQuery.Where((t1, t2, t3) => t1.TopicId == model.TopicId);
            joinQuery.WhereNotNull(model.Type, (t1, t2, t3) => t1.Type == model.Type);

            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderByDescending((t1, t2, t3) => t1.Id);
            }

            joinQuery.Select((t1, t2, t3) => new
            {
                t1,
                TopicTitle = t2.Title,
                t3.NickName,
                t3.Avatar,
                t3.Sex
            });

            var result = await joinQuery.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;

            return result;
        }
    }
}
