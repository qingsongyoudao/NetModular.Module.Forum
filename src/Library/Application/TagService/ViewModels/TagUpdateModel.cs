using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Module.Forum.Domain.Tag;

namespace NetModular.Module.Forum.Application.TagService.ViewModels
{
    /// <summary>
    /// 标签添加模型
    /// </summary>
    public class TagUpdateModel : TagAddModel
    {
        [Required(ErrorMessage = "请选择要修改的标签")]
        public int Id { get; set; }
    }
}
