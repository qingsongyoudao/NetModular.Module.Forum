using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.Forum.Application.TagService.ViewModels;
using NetModular.Module.Forum.Domain.Tag;

namespace NetModular.Module.Forum.Application.TagService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TagAddModel, TagEntity>();
            cfg.CreateMap<TagEntity, TagUpdateModel>();
            cfg.CreateMap<TagUpdateModel, TagEntity>();
        }
    }
}
