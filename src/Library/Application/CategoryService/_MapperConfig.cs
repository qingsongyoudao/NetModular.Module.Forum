using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.Forum.Application.CategoryService.ViewModels;
using NetModular.Module.Forum.Domain.Category;

namespace NetModular.Module.Forum.Application.CategoryService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CategoryAddModel, CategoryEntity>();
            cfg.CreateMap<CategoryEntity, CategoryUpdateModel>();
            cfg.CreateMap<CategoryUpdateModel, CategoryEntity>();
        }
    }
}
