using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.Forum.Domain.Comment.Models;

namespace NetModular.Module.Forum.Domain.Comment
{
    /// <summary>
    /// 评论信息仓储
    /// </summary>
    public interface ICommentRepository : IRepository<CommentEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<CommentEntity>> Query(CommentQueryModel model);
    }
}
