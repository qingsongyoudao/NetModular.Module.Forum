using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NetModular.Lib.Cache.Abstractions;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Forum.Application.CategoryService.ResultModels;
using NetModular.Module.Forum.Application.CategoryService.ViewModels;
using NetModular.Module.Forum.Domain.Category;
using NetModular.Module.Forum.Domain.Category.Models;
using NetModular.Module.Forum.Infrastructure;

namespace NetModular.Module.Forum.Application.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        private readonly ICacheHandler _cacheHandler;
        public CategoryService(IMapper mapper, ICategoryRepository repository, ICacheHandler cacheHandler)
        {
            _mapper = mapper;
            _cacheHandler = cacheHandler;
            _repository = repository;
        }

        public async Task<IResultModel> Query(CategoryQueryModel model)
        {
            var result = new QueryResultModel<CategoryEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(CategoryAddModel model)
        {
            var entity = _mapper.Map<CategoryEntity>(model);
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

            var model = _mapper.Map<CategoryUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(CategoryUpdateModel model)
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

        public async Task<IResultModel> Select()
        {
            if (!_cacheHandler.TryGetValue(CacheKeys.CategorySelect, out List<OptionResultModel> list))
            {
                var all = await _repository.GetAllAsync();
                list = all.Select(m => new OptionResultModel
                {
                    Label = m.Name,
                    Value = m.Id
                }).ToList();

                await _cacheHandler.SetAsync(CacheKeys.CategorySelect, list);
            }

            return ResultModel.Success(list);
        }

    }
}
