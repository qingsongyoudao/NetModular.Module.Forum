using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Auth.Web.Attributes;
using NetModular.Lib.Utils.Core.Models;
using NetModular.Module.Forum.Application.CategoryService;
using NetModular.Module.Forum.Application.CategoryService.ViewModels;
using NetModular.Module.Forum.Domain.Category.Models;

namespace NetModular.Module.Forum.Web.Controllers.App
{
    [Description("分类")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> List()
        {
            return _service.GetList();
        }
    }
}
