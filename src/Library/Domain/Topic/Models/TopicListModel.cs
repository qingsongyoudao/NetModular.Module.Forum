using System;
using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities;

namespace NetModular.Module.Forum.Domain.Topic
{
    /// <summary>
    /// 主题
    /// </summary>
    [Table("Topic")]
    public partial class TopicListModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 预览数
        /// </summary>
        public int ViewCount { get; set; }

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
        /// 评论数
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 最后回复时间
        /// </summary>
        public DateTime LastReplyTime { get; set; }

        /// <summary>
        /// 发布IP
        /// </summary>
        public string CreatedIP { get; set; }

    }
}
