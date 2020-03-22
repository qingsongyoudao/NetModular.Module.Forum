using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Forum.Domain.Category;
using NetModular.Module.Forum.Domain.Topic;
using NetModular.Module.Forum.Domain.Topic.Models;
using NetModular.Module.Forum.Domain.User;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SqlServer
{
    public class TopicRepository : RepositoryAbstract<TopicEntity>, ITopicRepository
    {
        public TopicRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<TopicEntity>> Query(TopicQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();

            var joinQuery = query.LeftJoin<UserEntity>((t1, t2) => t1.UserId == t2.Id)
                .LeftJoin<CategoryEntity>((t1, t2, t3) => t1.CategoryId == t3.Id);

            joinQuery.WhereNotNull(model.UserId, (t1, t2, t3) => t1.UserId == model.UserId);

            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderByDescending((t1, t2, t3) => t1.Id);
            }

            joinQuery.Select((t1, t2, t3) => new
            {
                t1,
                t2.NickName,
                t2.Avatar,
                t2.Sex,
                CategoryName = t3.Name
            });
            var result = await query.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;

            return result;
        }
    }
}
