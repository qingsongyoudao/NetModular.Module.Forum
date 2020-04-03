using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NetModular.Lib.Cache.Abstractions;
using NetModular.Lib.Utils.Core.Models;
using NetModular.Module.Forum.Application.CategoryService.ViewModels;
using NetModular.Module.Forum.Domain.Category;
using NetModular.Module.Forum.Domain.Category.Models;
using NetModular.Module.Forum.Infrastructure;
using NetModular.Module.Forum.Infrastructure.Repositories;

namespace NetModular.Module.Forum.Application.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        private readonly ICacheHandler _cacheHandler;
        private readonly ForumDbContext _dbContext;
        public CategoryService(IMapper mapper, 
            ICategoryRepository repository,
            ForumDbContext dbContext,
            ICacheHandler cacheHandler)
        {
            _mapper = mapper;
            _cacheHandler = cacheHandler;
            _repository = repository;
            _dbContext = dbContext;
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


        #region 排序
        public async Task<IResultModel> QuerySortList(long? parentId)
        {
            var model = new SortUpdateModel<long>();
            var all = await _repository.GetAllAsync();
            model.Options = all.Select(m => new SortOptionModel<long>()
            {
                Id = m.Id,
                Label = m.Name,
                Sort = m.Sort
            }).ToList();

            return ResultModel.Success(model);
        }

        public async Task<IResultModel> UpdateSortList(SortUpdateModel<long> model)
        {
            if (model.Options == null || !model.Options.Any())
            {
                return ResultModel.Failed("不包含数据");
            }

            using (var uow = _dbContext.NewUnitOfWork())
            {
                foreach (var option in model.Options)
                {
                    var entity = await _repository.GetAsync(option.Id, uow);
                    if (entity == null)
                    {
                        return ResultModel.Failed();
                    }
                    entity.Sort = option.Sort;
                    if (!await _repository.UpdateAsync(entity, uow))
                    {
                        return ResultModel.Failed();
                    }
                }
                uow.Commit();
            }

            return ResultModel.Success();
        }
        #endregion
    }
}
