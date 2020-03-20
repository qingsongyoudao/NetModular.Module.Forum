using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.Forum.Application.MarkService.ViewModels;
using NetModular.Module.Forum.Domain.Mark;

namespace NetModular.Module.Forum.Application.MarkService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<MarkAddModel, MarkEntity>();
            cfg.CreateMap<MarkEntity, MarkUpdateModel>();
            cfg.CreateMap<MarkUpdateModel, MarkEntity>();
        }
    }
}
