using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.Forum.Application.QuestionService.ViewModels;
using NetModular.Module.Forum.Domain.Question;

namespace NetModular.Module.Forum.Application.QuestionService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<QuestionAddModel, QuestionEntity>();
            cfg.CreateMap<QuestionEntity, QuestionUpdateModel>();
            cfg.CreateMap<QuestionUpdateModel, QuestionEntity>();
        }
    }
}
