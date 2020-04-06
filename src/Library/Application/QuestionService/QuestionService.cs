using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Forum.Application.QuestionService.ViewModels;
using NetModular.Module.Forum.Domain.Mark;
using NetModular.Module.Forum.Domain.Question;
using NetModular.Module.Forum.Domain.Question.Models;
using NetModular.Module.Forum.Infrastructure.Repositories;

namespace NetModular.Module.Forum.Application.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IMarkRepository _markRepository;
        private readonly IQuestionRepository _repository;
        private readonly ForumDbContext _dbContext;

        public QuestionService(IMapper mapper, IQuestionRepository repository,
            IMarkRepository markRepository,
            ForumDbContext dbContext)
        {
            _mapper = mapper;
            _markRepository = markRepository;
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<IResultModel> Query(QuestionQueryModel model)
        {
            var result = new QueryResultModel<QuestionEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(QuestionAddModel model)
        {
            var entity = _mapper.Map<QuestionEntity>(model);
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

            var model = _mapper.Map<QuestionUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(QuestionUpdateModel model)
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

        #region Õ≥º∆¿€º”
        public async Task<IResultModel> AddVisitCount(int id)
        {
            return ResultModel.Result(await _repository.AddVisitCount(id));
        }

        public async Task<IResultModel> AddUpCount(int id)
        {
            await _markRepository.AddAsync(new MarkEntity
            {
                Type = MarkType.QuestionUp,
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
                Type = MarkType.QuestionDown,
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
                Type = MarkType.QuestionLike,
                MemberId = 0,
                RelationId = id
                //MemberId = _dbContext.LoginInfo.AccountId
            });
            return ResultModel.Result(await _repository.AddLikeCount(id));
        }
        public async Task<IResultModel> AddAnswerCount(int id)
        {
            return ResultModel.Result(await _repository.AddAnswerCount(id));
        }
        #endregion
    }
}
