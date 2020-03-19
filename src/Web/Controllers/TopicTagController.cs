using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Forum.Application.TopicTagService;
using NetModular.Module.Forum.Application.TopicTagService.ViewModels;
using NetModular.Module.Forum.Domain.TopicTag.Models;

namespace NetModular.Module.Forum.Web.Controllers
{
    [Description("主题标签管理")]
    public class TopicTagController : ModuleController
    {
        private readonly ITopicTagService _service;

        public TopicTagController(ITopicTagService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery]TopicTagQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(TopicTagAddModel model)
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
        public Task<IResultModel> Update(TopicTagUpdateModel model)
        {
            return _service.Update(model);
        }
    }
}
