using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Forum.Application.TagService.ViewModels;
using NetModular.Module.Forum.Domain.Tag;
using NetModular.Module.Forum.Domain.Tag.Models;

namespace NetModular.Module.Forum.Application.TagService
{
    public class TagService : ITagService
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _repository;
        public TagService(IMapper mapper, ITagRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResultModel> Query(TagQueryModel model)
        {
            var result = new QueryResultModel<TagEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(TagAddModel model)
        {
            var entity = _mapper.Map<TagEntity>(model);
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

            var model = _mapper.Map<TagUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(TagUpdateModel model)
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
