using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NetModular.Lib.Cache.Abstractions;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Forum.Application.MemberService.ViewModels;
using NetModular.Module.Forum.Domain.Member;
using NetModular.Module.Forum.Domain.Member.Models;
using NetModular.Module.Forum.Infrastructure;

namespace NetModular.Module.Forum.Application.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository _repository;
        private readonly ICacheHandler _cacheHandler;
        public MemberService(IMapper mapper, IMemberRepository repository,
            ICacheHandler cacheHandler)
        {
            _mapper = mapper;
            _repository = repository;
            _cacheHandler = cacheHandler;
        }

        public async Task<IResultModel> Query(MemberQueryModel model)
        {
            var result = new QueryResultModel<MemberEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(MemberAddModel model)
        {
            var entity = _mapper.Map<MemberEntity>(model);
            //if (await _repository.Exists(entity))
            //{
            //return ResultModel.HasExists;
            //}
            var result = await _repository.AddAsync(entity);


            return ResultModel.Result(result);
        }

        private async Task SetUserEmailCache(string email)
        {

            if (_cacheHandler.TryGetValue(CacheKeys.USER_EMAIL, out List<string> root))
            {
                root = root == null ? new List<string>() : root;
                if (!root.Contains(email))
                {
                    root.Add(email);
                }
                await _cacheHandler.SetAsync(CacheKeys.USER_EMAIL, root);
            }
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

            var model = _mapper.Map<MemberUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(MemberUpdateModel model)
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
