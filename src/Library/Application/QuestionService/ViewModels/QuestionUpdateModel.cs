using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Module.Forum.Domain.Question;

namespace NetModular.Module.Forum.Application.QuestionService.ViewModels
{
    /// <summary>
    /// 问题管理添加模型
    /// </summary>
    public class QuestionUpdateModel : QuestionAddModel
    {
        [Required(ErrorMessage = "请选择要修改的问题管理")]
        public int Id { get; set; }
    }
}
