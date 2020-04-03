using NetModular.Lib.Options.Abstraction;

namespace NetModular.Module.Forum.Infrastructure
{
    /// <summary>
    /// 论坛配置项
    /// </summary>
    public class ForumOptions : IModuleOptions
    {
        public IModuleOptions Copy()
        {
            return new ForumOptions
            {

            };
        }
    }
}
