using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Abstractions.Entities;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Forum.Domain.Tag;
using NetModular.Module.Forum.Domain.Tag.Models;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SqlServer
{
    public class TagRepository : RepositoryAbstract<TagEntity>, ITagRepository
    {
        public TagRepository(IDbContext context) : base(context)
        {
        }

        public async Task<bool> AddCount(int[] tagIds, bool isAdd, IUnitOfWork uow = null)
        {
            var list = await Db.Find(f => tagIds.Contains(f.Id)).ToListAsync();
            foreach (var item in list)
            {
                if (isAdd) item.Count++;
                else
                {
                    item.Count--;
                    item.Count = item.Count < 0 ? 0 : item.Count;
                }
                await Db.UpdateAsync(item, uow);
            }
            return true;

            //不支持写法（等待支持）
            //return await Db.Find(f => tagIds.Contains(f.Id)).UseUow(uow).UpdateAsync(m => new TagEntity
            //{
            //    Count = m.Count + 1
            //});

            //采用sql写法
            //string tagDatabaseName = EntityDescriptorCollection.Get<TagEntity>().Database;
            //string addCountSql = $"update {tagDatabaseName}tag set Count=Count+1 where id in ({string.Join(",", tagIds)})";
            //return await Db.ExecuteAsync(addCountSql, uow);
        }

        public async Task<int> RecalculationCount(int[] tagIds, IUnitOfWork uow = null)
        {
            string tagDatabaseName = EntityDescriptorCollection.Get<TagEntity>().Database;
            string addCountSql = $"update {tagDatabaseName}tag as t1 set " +
                $" t1.Count=(select count(1) from {tagDatabaseName}topic_Tag as t2 where t2.tagId=t1.id) " +
                $"where t1.id in ({string.Join(",", tagIds)})";
            return await Db.ExecuteAsync(addCountSql, uow);
        }

        public async Task<IList<TagEntity>> Query(TagQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();

            if (!paging.OrderBy.Any())
            {
                query.OrderByDescending(m => m.Id);
            }

            var result = await query.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;

            return result;
        }
    }
}
