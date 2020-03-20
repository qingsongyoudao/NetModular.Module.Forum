using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Module.Forum.Domain.TopicTag;

namespace NetModular.Module.Forum.Application.TopicTagService.ViewModels
{
    /// <summary>
    /// 主题标签添加模型
    /// </summary>
    public class TopicTagUpdateModel : TopicTagAddModel
    {
        [Required(ErrorMessage = "请选择要修改的主题标签")]
        public int Id { get; set; }
    }
}
