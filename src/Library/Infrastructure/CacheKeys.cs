using System.ComponentModel;

namespace NetModular.Module.Forum.Infrastructure
{
    public class CacheKeys
    {
        /// <summary>
        /// 分类树
        /// </summary>
        [Description("分类")]
        public const string CategorySelect = "FORUM:CATEGORY:SELECT";

        /// <summary>
        /// 用户邮箱集合
        /// </summary>
        public const string USER_EMAIL = "FORU:USER:EMAIL";

        /// <summary>
        /// 用户名集合
        /// </summary>
        public const string USER_USER_NAME = "FORU:USER:USER_NAME";
    }
}
