using System;
using System.Threading.Tasks;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Forum.Application.QuestionService.ViewModels;
using NetModular.Module.Forum.Domain.Question.Models;

namespace NetModular.Module.Forum.Application.QuestionService
{
    /// <summary>
    /// 问题管理服务
    /// </summary>
    public interface IQuestionService
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Query(QuestionQueryModel model);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Add(QuestionAddModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        Task<IResultModel> Delete(int id);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> Edit(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Update(QuestionUpdateModel model);

        /// <summary>
        /// 访问次数加一次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> AddVisitCount(int id);
        /// <summary>
        /// 赞加一
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> AddUpCount(int id);
        /// <summary>
        /// 踩加一
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> AddDownCount(int id);
        /// <summary>
        /// 喜欢加一
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> AddLikeCount(int id);
        /// <summary>
        /// 回答加一
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> AddAnswerCount(int id);
    }
}
