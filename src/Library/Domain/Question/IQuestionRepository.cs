using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.Forum.Domain.Question.Models;

namespace NetModular.Module.Forum.Domain.Question
{
    /// <summary>
    /// 问题管理仓储
    /// </summary>
    public interface IQuestionRepository : IRepository<QuestionEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<QuestionEntity>> Query(QuestionQueryModel model);

        /// <summary>
        /// 访问次数加一次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> AddVisitCount(int id);
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
        /// 踩加一
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> AddLikeCount(int id);
        /// <summary>
        /// 回答加一
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> AddAnswerCount(int id);
    }
}
