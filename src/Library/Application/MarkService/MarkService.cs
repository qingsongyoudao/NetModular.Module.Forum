using System.Threading.Tasks;
using AutoMapper;
using NetModular.Module.Forum.Application.MarkService.ViewModels;
using NetModular.Module.Forum.Domain.Mark;
using NetModular.Module.Forum.Domain.Mark.Models;

namespace NetModular.Module.Forum.Application.MarkService
{
    public class MarkService : IMarkService
    {
        private readonly IMapper _mapper;
        private readonly IMarkRepository _repository;
        public MarkService(IMapper mapper, IMarkRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResultModel> Query(MarkQueryModel model)
        {
            var result = new QueryResultModel<MarkEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(MarkAddModel model)
        {
            var entity = _mapper.Map<MarkEntity>(model);
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

            var model = _mapper.Map<MarkUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(MarkUpdateModel model)
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

        public async Task<IResultModel> Count(int TopicId, MarkType type)
        {
            var result = await _repository.Count(TopicId, type);
            return ResultModel.Success<long>(result);
        }
    }
}
