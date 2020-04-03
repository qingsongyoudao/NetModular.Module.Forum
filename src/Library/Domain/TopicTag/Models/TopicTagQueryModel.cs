using NetModular.Lib.Data.Query;

namespace  NetModular.Module.Forum.Domain.TopicTag.Models
{
    public class TopicTagQueryModel : QueryModel
    {

        /// <summary>
        /// ��������
        /// </summary>
        public string TopicName { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        public int? TopicId { get; set; }
    }
}
