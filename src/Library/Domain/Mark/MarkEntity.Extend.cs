using NetModular.Lib.Data.Abstractions.Attributes;

namespace NetModular.Module.Forum.Domain.Mark
{
    public partial class MarkEntity
    {
        /// <summary>
        /// êÇ³Æ
        /// </summary>
        [Ignore] public string NickName { get; set; }

        /// <summary>
        /// ÐÔ±ð
        /// </summary>
        [Ignore] public int Sex { get; set; }

        /// <summary>
        /// Í·Ïñ
        /// </summary>
        [Ignore] public string Avatar { get; set; }
    }
}
