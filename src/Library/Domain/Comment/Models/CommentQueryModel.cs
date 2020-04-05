using NetModular.Lib.Data.Query;

namespace  NetModular.Module.Forum.Domain.Comment.Models
{
    public class CommentQueryModel : QueryModel
    {
        /// <summary>
        /// ����ID
        /// </summary>
        public int? TopicId { get; set; }

        /// <summary>
        /// �û����
        /// </summary>
        public int? MemberId { get; set; }

        /// <summary>
        /// �ظ���ID
        /// </summary>
        public int? To { get; set; }

    }
}
