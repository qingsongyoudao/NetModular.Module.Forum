using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Module.Forum.Application.QuestionService;
using NetModular.Module.Forum.Domain.Question.Models;
using NetModular.Module.Forum.Domain.Topic.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace NetModular.Module.Forum.Web.Controllers.App
{
    [Description("问题接口")]
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _service;

        public QuestionController(IQuestionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("问题列表")]
        public Task<IResultModel> List([FromQuery]QuestionQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpGet]
        [Description("通过编号获取问题详细记录，包括标签，并自动访问加一")]
        public Task<IResultModel> GetQuestionById([BindRequired]int id)
        {
            _service.AddVisitCount(id);
            return _service.Edit(id);
        }

        [HttpGet]
        [Description("问题赞一下")]
        public Task<IResultModel> Up([BindRequired]int id)
        {
            return _service.AddUpCount(id);
        }

        [HttpGet]
        [Description("问题踩一下")]
        public Task<IResultModel> Down([BindRequired]int id)
        {
            return _service.AddDownCount(id);
        }

        [HttpGet]
        [Description("问题喜欢一下")]
        public Task<IResultModel> Like([BindRequired]int id)
        {
            return _service.AddLikeCount(id);
        }
    }
}
