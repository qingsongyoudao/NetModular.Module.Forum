using NetModular.Lib.Data.Query;

namespace  NetModular.Module.Forum.Domain.Mark.Models
{
    public class MarkQueryModel : QueryModel
    {
        /// <summary>
        /// ����Id
        /// </summary>
        public int TopicId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public MarkType? Type { get; set; }

    }
}
