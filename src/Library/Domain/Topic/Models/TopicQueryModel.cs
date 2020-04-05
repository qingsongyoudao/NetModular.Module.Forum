using NetModular.Lib.Data.Query;

namespace NetModular.Module.Forum.Domain.Topic.Models
{
    public class TopicQueryModel : QueryModel
    {

        /// <summary>
        /// 会员编号
        /// </summary>
        public int? MemberId { get; set; }

        /// <summary>
        /// 标题 (模糊查询条件）
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryId { get; set; }


    }
}
