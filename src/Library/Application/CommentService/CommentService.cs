using System.Threading.Tasks;
using AutoMapper;
using NetModular.Module.Forum.Application.CommentService.ViewModels;
using NetModular.Module.Forum.Domain.Comment;
using NetModular.Module.Forum.Domain.Comment.Models;
using NetModular.Module.Forum.Domain.Mark;

namespace NetModular.Module.Forum.Application.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _repository;
        private readonly IMarkRepository _markRepository;

        public CommentService(IMapper mapper, ICommentRepository repository, IMarkRepository markRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _markRepository = markRepository;
        }

        public async Task<IResultModel> Query(CommentQueryModel model)
        {
            var result = new QueryResultModel<CommentEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(CommentAddModel model)
        {
            var entity = _mapper.Map<CommentEntity>(model);
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

            var model = _mapper.Map<CommentUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(CommentUpdateModel model)
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

        #region ͳ���ۼ�
        public async Task<IResultModel> AddUpCount(int id)
        {
            await _markRepository.AddAsync(new MarkEntity
            {
                Type = MarkType.CommentUp,
                MemberId = 0,
                RelationId = id
                //MemberId = _dbContext.LoginInfo.AccountId
            });
            return ResultModel.Result(await _repository.AddUpCount(id));
        }
        public async Task<IResultModel> AddDownCount(int id)
        {
            await _markRepository.AddAsync(new MarkEntity
            {
                Type = MarkType.CommentDown,
                MemberId = 0,
                RelationId = id
                //MemberId = _dbContext.LoginInfo.AccountId
            });
            return ResultModel.Result(await _repository.AddDownCount(id));
        }
        public async Task<IResultModel> AddLikeCount(int id)
        {
            await _markRepository.AddAsync(new MarkEntity
            {
                Type = MarkType.CommentLike,
                MemberId = 0,
                RelationId = id
                //MemberId = _dbContext.LoginInfo.AccountId
            });
            return ResultModel.Result(await _repository.AddLikeCount(id));
        }
        #endregion 
    }
}
