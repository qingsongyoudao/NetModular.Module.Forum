using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.Forum.Application.UserService.ViewModels
{
    /// <summary>
    /// 用户信息添加模型
    /// </summary>
    public class UserUpdateModel : UserAddModel
    {
        [Required(ErrorMessage = "请选择要修改的用户信息")]
        public int Id { get; set; }
    }
}
