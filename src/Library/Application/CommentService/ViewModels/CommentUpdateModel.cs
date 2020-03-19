using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Module.Forum.Domain.Comment;

namespace NetModular.Module.Forum.Application.CommentService.ViewModels
{
    /// <summary>
    /// 评论信息添加模型
    /// </summary>
    public class CommentUpdateModel : CommentAddModel
    {
        [Required(ErrorMessage = "请选择要修改的评论信息")]
        public int Id { get; set; }
    }
}
