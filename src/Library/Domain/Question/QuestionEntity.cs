using System;
using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities.Extend;

namespace NetModular.Module.Forum.Domain.Question
{
    /// <summary>
    /// 问题管理
    /// </summary>
    [Table("Question")]
    public partial class QuestionEntity : EntityBase<int>
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Length(100)]
        public string Title { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        [Length(100)]
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
        /// 喜欢次数
        /// </summary>
        public int LikeCount { get; set; }

        /// <summary>
        /// 问题内容
        /// </summary>
		[Max]
        public string Content { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        [Length(200)]
        public string Abstract { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public int IsTop { get; set; }

        /// <summary>
        /// 最后回答时间
        /// </summary>
        public DateTime LastAnswerTime { get; set; }

        /// <summary>
        /// 发布IP
        /// </summary>
        public string CreatedIP { get; set; }
    }
}
