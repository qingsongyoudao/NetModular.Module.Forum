using System.Threading.Tasks;
using AutoMapper;
using NetModular.Module.Forum.Application.TopicTagService.ViewModels;
using NetModular.Module.Forum.Domain.TopicTag;
using NetModular.Module.Forum.Domain.TopicTag.Models;

namespace NetModular.Module.Forum.Application.TopicTagService
{
    public class TopicTagService : ITopicTagService
    {
        private readonly IMapper _mapper;
        private readonly ITopicTagRepository _repository;
        public TopicTagService(IMapper mapper, ITopicTagRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResultModel> Query(TopicTagQueryModel model)
        {
            var result = new QueryResultModel<TopicTagEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(TopicTagAddModel model)
        {
            var entity = _mapper.Map<TopicTagEntity>(model);
            //if (await _repository.Exists(entity))
            //{
                //return ResultModel.HasExists;
            //}

            var result = await _repository.AddAsync(entity);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Edit(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
                return ResultModel.NotExists;

            var model = _mapper.Map<TopicTagUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(TopicTagUpdateModel model)
        {
            var entity = await _repository.GetAsync(model.Id);
            if (entity == null)
                return ResultModel.NotExists;

            _mapper.Map(model, entity);

            //if (await _repository.Exists(entity))
            //{
                //return ResultModel.HasExists;
            //}

            var result = await _repository.UpdateAsync(entity);

            return ResultModel.Result(result);
        }
    }
}
