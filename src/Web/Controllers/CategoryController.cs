using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Auth.Web.Attributes;
using NetModular.Lib.Utils.Core.Models;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Forum.Application.CategoryService;
using NetModular.Module.Forum.Application.CategoryService.ViewModels;
using NetModular.Module.Forum.Domain.Category.Models;

namespace NetModular.Module.Forum.Web.Controllers
{
    [Description("分类管理")]
    public class CategoryController : ModuleController
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery]CategoryQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(CategoryAddModel model)
        {
            return _service.Add(model);
        }

        [HttpDelete]
        [Description("删除")]
        public Task<IResultModel> Delete([BindRequired]int id)
        {
            return _service.Delete(id);
        }

        [HttpGet]
        [Description("编辑")]
        public Task<IResultModel> Edit([BindRequired]int id)
        {
            return _service.Edit(id);
        }

        [HttpPost]
        [Description("修改")]
        public Task<IResultModel> Update(CategoryUpdateModel model)
        {
            return _service.Update(model);
        }

        [Common]
        [HttpGet]
        [Description("选择")]
        public Task<IResultModel> Select()
        {
            return _service.Select();
        }


        #region 排序

        [HttpGet]
        [Description("获取排序信息")]
        public Task<IResultModel> Sort(long? parentId)
        {
            return _service.QuerySortList(parentId);
        }

        [HttpPost]
        [Description("更新排序信息")]
        public Task<IResultModel> Sort(SortUpdateModel<long> model)
        {
            return _service.UpdateSortList(model);
        }
        #endregion
    }
}
