using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.Forum.Application.CommentService.ViewModels;
using NetModular.Module.Forum.Domain.Comment;

namespace NetModular.Module.Forum.Application.CommentService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CommentAddModel, CommentEntity>();
            cfg.CreateMap<CommentEntity, CommentUpdateModel>();
            cfg.CreateMap<CommentUpdateModel, CommentEntity>();
        }
    }
}
