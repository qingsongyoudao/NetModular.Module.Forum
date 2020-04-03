using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.Forum.Application.CategoryService.ViewModels
{
    /// <summary>
    /// 分类添加模型
    /// </summary>
    public class CategoryUpdateModel : CategoryAddModel
    {
        [Required(ErrorMessage = "请选择要修改的分类")]
        public int Id { get; set; }
    }
}
