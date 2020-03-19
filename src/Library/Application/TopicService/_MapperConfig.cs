using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.Forum.Application.TopicService.ViewModels;
using NetModular.Module.Forum.Domain.Topic;

namespace NetModular.Module.Forum.Application.TopicService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TopicAddModel, TopicEntity>();
            cfg.CreateMap<TopicEntity, TopicUpdateModel>();
            cfg.CreateMap<TopicUpdateModel, TopicEntity>();
        }
    }
}
