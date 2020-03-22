using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Forum.Domain.Tag;
using NetModular.Module.Forum.Domain.Topic;
using NetModular.Module.Forum.Domain.TopicTag;
using NetModular.Module.Forum.Domain.TopicTag.Models;
using NetModular.Module.Forum.Domain.User;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SqlServer
{
    public class TopicTagRepository : RepositoryAbstract<TopicTagEntity>, ITopicTagRepository
    {
        public TopicTagRepository(IDbContext context) : base(context)
        {
        }
        public async Task<bool> DeleteByTopicId(int topicId, IUnitOfWork uow = null)
        {
            if (uow == null)
            {
                return await Db.Find(m => m.TopicId == topicId).DeleteAsync();
            }
            return await Db.Find(m => m.TopicId == topicId).UseUow(uow).DeleteAsync();
        }

        public async Task<bool> DeleteByTagId(int tagId, IUnitOfWork uow = null)
        {
            if (uow == null)
            {
                return await Db.Find(m => m.TagId == tagId).DeleteAsync();
            }
            return await Db.Find(m => m.TagId == tagId).UseUow(uow).DeleteAsync();
        }

        public async Task<IList<TopicTagEntity>> Query(TopicTagQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();
            var joinQuery = query.LeftJoin<TopicEntity>((t1, t2) => t1.TopicId == t2.Id)
                .LeftJoin<TagEntity>((t1, t2, t3) => t1.TagId == t3.Id)
                .LeftJoin<UserEntity>((t1, t2, t3, t4) => t2.UserId == t4.Id);

            joinQuery.Where((t1, t2, t3, t4) => t1.TopicId == model.TopicId);

            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderByDescending((t1, t2, t3, t4) => t1.Id);
            }

            joinQuery.Select((t1, t2, t3, t4) => new
            {
                t1,
                TopicTitle = t2.Title,
                TagName = t3.Name,
                NickName = t4.NickName
            });

            var result = await joinQuery.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;

            return result;
        }
    }
}
