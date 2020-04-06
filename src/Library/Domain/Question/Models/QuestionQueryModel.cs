using System;
using NetModular.Lib.Data.Query;

namespace NetModular.Module.Forum.Domain.Question.Models
{
    public class QuestionQueryModel : QueryModel
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public int? MemberId { get; set; }


        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Abstract { get; set; }

    }
}
