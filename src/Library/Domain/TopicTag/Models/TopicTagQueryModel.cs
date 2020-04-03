using NetModular.Lib.Data.Query;

namespace  NetModular.Module.Forum.Domain.TopicTag.Models
{
    public class TopicTagQueryModel : QueryModel
    {

        /// <summary>
        /// 主题名称
        /// </summary>
        public string TopicName { get; set; }

        /// <summary>
        /// 主题ID
        /// </summary>
        public int? TopicId { get; set; }
    }
}
