using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.Forum.Application.UserService.ViewModels;
using NetModular.Module.Forum.Domain.User;

namespace NetModular.Module.Forum.Application.UserService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserAddModel, UserEntity>();
            cfg.CreateMap<UserEntity, UserUpdateModel>();
            cfg.CreateMap<UserUpdateModel, UserEntity>();
        }
    }
}
