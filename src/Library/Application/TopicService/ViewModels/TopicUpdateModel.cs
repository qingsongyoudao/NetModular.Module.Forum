using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.Forum.Application.TopicService.ViewModels
{
    /// <summary>
    /// 主题添加模型
    /// </summary>
    public class TopicUpdateModel : TopicAddModel
    {
        [Required(ErrorMessage = "请选择要修改的主题")]
        public int Id { get; set; }
    }
}
