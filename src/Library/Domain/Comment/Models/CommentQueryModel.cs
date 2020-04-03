using NetModular.Lib.Data.Query;

namespace  NetModular.Module.Forum.Domain.Comment.Models
{
    public class CommentQueryModel : QueryModel
    {
        /// <summary>
        /// 主题ID
        /// </summary>
        public int? TopicId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 回复人ID
        /// </summary>
        public int? To { get; set; }

    }
}
