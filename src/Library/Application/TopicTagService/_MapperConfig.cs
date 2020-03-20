using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.Forum.Application.TopicTagService.ViewModels;
using NetModular.Module.Forum.Domain.TopicTag;

namespace NetModular.Module.Forum.Application.TopicTagService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TopicTagAddModel, TopicTagEntity>();
            cfg.CreateMap<TopicTagEntity, TopicTagUpdateModel>();
            cfg.CreateMap<TopicTagUpdateModel, TopicTagEntity>();
        }
    }
}
