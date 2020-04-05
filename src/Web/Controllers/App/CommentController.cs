using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Auth.Web.Attributes;
using NetModular.Lib.Utils.Core.Models;
using NetModular.Module.Forum.Application.CommentService;
using NetModular.Module.Forum.Application.CommentService.ViewModels;
using NetModular.Module.Forum.Domain.Comment.Models;

namespace NetModular.Module.Forum.Web.Controllers.App
{
    [Description("分类")]
    public class CommentController : BaseController
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("主题评论列表-分页")]
        public Task<IResultModel> List([FromQuery]CommentQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加评论")]
        public Task<IResultModel> Create(CommentAddModel model)
        {
            //model = CreatedIP
            return _service.Add(model);
        }

    }
}
