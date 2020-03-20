using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Forum.Application.MarkService;
using NetModular.Module.Forum.Application.MarkService.ViewModels;
using NetModular.Module.Forum.Domain.Mark.Models;

namespace NetModular.Module.Forum.Web.Controllers
{
    [Description("标记信息管理")]
    public class MarkController : ModuleController
    {
        private readonly IMarkService _service;

        public MarkController(IMarkService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery]MarkQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(MarkAddModel model)
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
        public Task<IResultModel> Update(MarkUpdateModel model)
        {
            return _service.Update(model);
        }
    }
}
