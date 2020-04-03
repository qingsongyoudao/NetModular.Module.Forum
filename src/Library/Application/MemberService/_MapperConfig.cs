using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.Forum.Application.MemberService.ViewModels;
using NetModular.Module.Forum.Domain.Member;

namespace NetModular.Module.Forum.Application.MemberService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<MemberAddModel, MemberEntity>();
            cfg.CreateMap<MemberEntity, MemberUpdateModel>();
            cfg.CreateMap<MemberUpdateModel, MemberEntity>();
        }
    }
}
