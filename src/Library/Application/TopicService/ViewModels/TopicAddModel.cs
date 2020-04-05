using System;

namespace NetModular.Module.Forum.Application.TopicService.ViewModels
{
    /// <summary>
    /// 主题添加模型
    /// </summary>
    public class TopicAddModel
    {
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
        /// 内容
        /// </summary>
        public string Content { get; set; }

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

        /// <summary>
        /// 标签列表
        /// </summary>
        public int[] Tags { get; set; }
    }
}
