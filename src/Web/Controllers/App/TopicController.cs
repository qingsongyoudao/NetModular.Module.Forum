using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Forum.Application.MemberService;
using NetModular.Module.Forum.Application.MemberService.ViewModels;
using NetModular.Module.Forum.Application.TopicService;
using NetModular.Module.Forum.Domain.Topic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace NetModular.Module.Forum.Web.Controllers.App
{
    [Description("会员接口")]
    public class TopicController : BaseController
    {
        private readonly ITopicService _service;

        public TopicController(ITopicService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("主题列表")]
        public Task<IResultModel> List([FromQuery]TopicQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpGet]
        [Description("通过编号获取详细记录，包括标签")]
        public Task<IResultModel> GetTopicById([BindRequired]int id)
        {
            return _service.Edit(id);
        }
    }
}
