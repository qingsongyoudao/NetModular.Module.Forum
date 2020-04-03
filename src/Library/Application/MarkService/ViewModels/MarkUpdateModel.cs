using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.Forum.Application.MarkService.ViewModels
{
    /// <summary>
    /// 标记信息添加模型
    /// </summary>
    public class MarkUpdateModel : MarkAddModel
    {
        [Required(ErrorMessage = "请选择要修改的标记信息")]
        public int Id { get; set; }
    }
}
