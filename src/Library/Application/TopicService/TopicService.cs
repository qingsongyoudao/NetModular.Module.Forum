using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NetModular.Module.Forum.Application.TopicService.ViewModels;
using NetModular.Module.Forum.Domain.Category;
using NetModular.Module.Forum.Domain.Tag;
using NetModular.Module.Forum.Domain.Topic;
using NetModular.Module.Forum.Domain.Topic.Models;
using NetModular.Module.Forum.Domain.TopicTag;
using NetModular.Module.Forum.Infrastructure.Repositories;

namespace NetModular.Module.Forum.Application.TopicService
{
    public class TopicService : ITopicService
    {
        private readonly IMapper _mapper;
        private readonly ITopicRepository _repository;
        private readonly ITopicTagRepository _topicTagRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ForumDbContext _forumDbContext;
        public TopicService(IMapper mapper, ITopicRepository repository,
            ForumDbContext forumDbContext,
            ITopicTagRepository topicTagRepository,
            ITagRepository tagRepository,
            ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _forumDbContext = forumDbContext;
            _repository = repository;
            _topicTagRepository = topicTagRepository;
            _tagRepository = tagRepository;
            _categoryRepository = categoryRepository;
        }



        public async Task<IResultModel> Query(TopicQueryModel model)
        {
            var result = new QueryResultModel<TopicEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(TopicAddModel model)
        {
            var entity = _mapper.Map<TopicEntity>(model);
            //if (await _repository.Exists(entity))
            //{
            //return ResultModel.HasExists;
            //}
            using var uow = _forumDbContext.NewUnitOfWork();
            var result = await _repository.AddAsync(entity, uow);
            if (result && model.Tags != null && model.Tags.Count() > 0)
            {
                var tagList = model.Tags.Select(s => new TopicTagEntity
                {
                    TopicId = entity.Id,
                    TagId = s
                }).ToList();

                //新增只需要重新添加即可 消息队列处理
                await _topicTagRepository.AddAsync(tagList, uow);
                uow.Commit();

                if (model.Tags.Count() > 0) await _tagRepository.AddCount(model.Tags, true);
                await _categoryRepository.AddCount(new int[] { entity.CategoryId }, true);
            }
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


            var model = _mapper.Map<TopicUpdateModel>(entity);

            var topicTags = await _topicTagRepository.Query(new Domain.TopicTag.Models.TopicTagQueryModel { TopicId = entity.Id });
            model.Tags = topicTags.ToList().Select(s => s.TagId).ToArray();

            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(TopicUpdateModel model)
        {
            var entity = await _repository.GetAsync(model.Id);
            if (entity == null)
                return ResultModel.NotExists;

            //获取原值
            int originCategory = entity.CategoryId;
            var topicTags = await _topicTagRepository.Query(new Domain.TopicTag.Models.TopicTagQueryModel
            {
                TopicId = entity.Id
            });

            _mapper.Map(model, entity);

            using var uow = _forumDbContext.NewUnitOfWork();
            var result = await _repository.UpdateAsync(entity, uow);
            if (result && model.Tags != null && model.Tags.Count() > 0)
            {
                //删除原关系
                await _topicTagRepository.DeleteByTopicId(entity.Id, uow);
                var tagList = model.Tags.Select(s => new TopicTagEntity
                {
                    TopicId = entity.Id,
                    TagId = s
                }).ToList();
                await _topicTagRepository.AddAsync(tagList, uow);
            }
            uow.Commit();

            #region 判断哪些标签需要重新计算 （这里需要消息队列处理）

            //编辑前
            var originTags = topicTags.Select(s => s.TagId).ToArray();
            //删除的
            var exceptR = originTags.Except(model.Tags);
            //新增的
            var exceptL = model.Tags.Except(originTags);
            //如果差集为0，则无需重新计算
            if (exceptR.Count() > 0 || exceptL.Count() > 0)
            {
                if (exceptR.Count() > 0) await _tagRepository.AddCount(exceptR.ToArray(), false);
                if (exceptL.Count() > 0) await _tagRepository.AddCount(exceptL.ToArray(), true);
            }
            #endregion
            #region 判断哪些分类需要重新计算 （这里需要消息队列处理）
            if (originCategory != entity.CategoryId)
            {
                await _categoryRepository.AddCount(new int[] { entity.CategoryId }, true);
                await _categoryRepository.AddCount(new int[] { originCategory }, false);
            }
            #endregion

            return ResultModel.Result(result);
        }
    }
}
