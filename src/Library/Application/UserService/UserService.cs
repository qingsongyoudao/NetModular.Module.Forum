using System.Threading.Tasks;
using AutoMapper;
using NetModular.Module.Forum.Application.UserService.ViewModels;
using NetModular.Module.Forum.Domain.User;
using NetModular.Module.Forum.Domain.User.Models;

namespace NetModular.Module.Forum.Application.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        public UserService(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResultModel> Query(UserQueryModel model)
        {
            var result = new QueryResultModel<UserEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(UserAddModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);
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

            var model = _mapper.Map<UserUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(UserUpdateModel model)
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
