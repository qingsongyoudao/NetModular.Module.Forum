using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Module.Forum.Domain.Question;

namespace NetModular.Module.Forum.Application.QuestionService.ViewModels
{
    /// <summary>
    /// 问题管理添加模型
    /// </summary>
    public class QuestionAddModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// 访问次数
        /// </summary>
        public int VisitCount { get; set; }

        /// <summary>
        /// 回答次数
        /// </summary>
        public int AnswerCount { get; set; }

        /// <summary>
        /// 赞次数
        /// </summary>
        public int UpCount { get; set; }

        /// <summary>
        /// 踩次数
        /// </summary>
        public int DownCount { get; set; }

        /// <summary>
        /// 问题内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Abstract { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public int IsTop { get; set; }
    }
}
