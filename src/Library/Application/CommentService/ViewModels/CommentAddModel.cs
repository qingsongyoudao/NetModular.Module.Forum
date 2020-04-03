using System;

namespace NetModular.Module.Forum.Application.CommentService.ViewModels
{
    /// <summary>
    /// 评论信息添加模型
    /// </summary>
    public class CommentAddModel
    {
        /// <summary>
        /// 主题ID
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 回复人ID
        /// </summary>
        public int To { get; set; }

        /// <summary>
        /// 回复内容
        /// </summary>
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
