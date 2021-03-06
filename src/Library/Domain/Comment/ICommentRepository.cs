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

        /// <summary>
        /// 赞加一
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> AddUpCount(int id);
        /// <summary>
        /// 踩加一
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> AddDownCount(int id);

        /// <summary>
        /// 喜欢加一
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> AddLikeCount(int id);
    }
}
