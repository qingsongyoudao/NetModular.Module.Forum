using System;
using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.Forum.Application.MemberService.ViewModels
{
    /// <summary>
    /// 用户信息添加模型
    /// </summary>
    public class MemberUpdateModel : MemberAddModel
    {
        [Required(ErrorMessage = "请选择要修改的用户信息")]
        public int Id { get; set; }
    }
}
