using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Forum.Domain.Comment;
using NetModular.Module.Forum.Domain.Comment.Models;
using NetModular.Module.Forum.Domain.Member;
using NetModular.Module.Forum.Domain.Tag;
using NetModular.Module.Forum.Domain.Topic;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SqlServer
{
    public class CommentRepository : RepositoryAbstract<CommentEntity>, ICommentRepository
    {
        public CommentRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<CommentEntity>> Query(CommentQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();
            var joinQuery = query.LeftJoin<TopicEntity>((t1, t2) => t1.TopicId == t2.Id)
                .LeftJoin<MemberEntity>((t1, t2, t3) => t1.To == t3.Id)
                .LeftJoin<MemberEntity>((t1, t2, t3, t4) => t2.MemberId == t4.Id);

            joinQuery.WhereNotNull(model.TopicId, (t1, t2, t3, t4) => t1.TopicId == model.TopicId);
            joinQuery.WhereNotNull(model.MemberId, (t1, t2, t3, t4) => t1.MemberId == model.MemberId);
            joinQuery.WhereNotNull(model.To, (t1, t2, t3, t4) => t1.To == model.To);

            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderByDescending((t1, t2, t3, t4) => t1.Id);
            }

            joinQuery.Select((t1, t2, t3, t4) => new
            {
                t1,
                TopicTitle = t2.Title,
                ToNickName = t3.NickName,
                ToAvatar = t3.Avatar,
                ToSex = t3.Sex,
                t4.NickName,
                t4.Avatar,
                t4.Sex
            });

            var result = await joinQuery.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;

            return result;
        }
    }
}
