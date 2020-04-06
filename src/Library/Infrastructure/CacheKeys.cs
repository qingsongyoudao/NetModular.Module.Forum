using System.ComponentModel;

namespace NetModular.Module.Forum.Infrastructure
{
    public class CacheKeys
    {
        /// <summary>
        /// 分类树
        /// </summary>
        [Description("分类")]
        public const string CATEGORY_SELECT = "FORUM:CATEGORY:SELECT";

        /// <summary>
        /// 会员邮箱集合
        /// </summary>
        [Description("会员邮箱集合")]
        public const string USER_EMAIL = "FORUM:USER:EMAIL";

        /// <summary>
        /// 会员名集合
        /// </summary>
        [Description("会员名集合")]
        public const string USER_USER_NAME = "FORUM:USER:USER_NAME";
    }
}
