using System;
using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities;

namespace NetModular.Module.Forum.Domain.Comment
{
    /// <summary>
    /// 评论信息
    /// </summary>
    [Table("Comment")]
    public partial class CommentEntity : Entity<int>
    {
        /// <summary>
        /// 主题ID
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// 回复人ID
        /// </summary>
        public int To { get; set; }

        /// <summary>
        /// 回复内容
        /// </summary>
		[Max]
        public string Content { get; set; }

        /// <summary>
        /// 赞数
        /// </summary>
        public int UpCount { get; set; }

        /// <summary>
        /// 踩数
        /// </summary>
        public int DownCount { get; set; }

        /// <summary>
        /// 喜欢数
        /// </summary>
        public int LikeCount { get; set; }

        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 创建IP
        /// </summary>
        public string CreatedIP { get; set; }

    }
}
