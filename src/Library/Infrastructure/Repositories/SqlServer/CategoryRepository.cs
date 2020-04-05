using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Abstractions.Entities;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Forum.Domain.Category;
using NetModular.Module.Forum.Domain.Category.Models;

namespace NetModular.Module.Forum.Infrastructure.Repositories.SqlServer
{
    public class CategoryRepository : RepositoryAbstract<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(IDbContext context) : base(context)
        {
        }

        public async Task<bool> AddCount(int[] categoryIds, bool isAddCount, IUnitOfWork uow = null)
        {
            var list = await Db.Find(f => categoryIds.Contains(f.Id)).ToListAsync();
            foreach (var item in list)
            {
                if (isAddCount) item.Count++;
                else
                {
                    item.Count--;
                    item.Count = item.Count < 0 ? 0 : item.Count;
                }
                await Db.UpdateAsync(item, uow);
            }
            return true;

            //string databaseName = EntityDescriptorCollection.Get<CategoryEntity>().Database;
            //string addCountSql = $"update {databaseName}category set Count=Count+1 where id in ({string.Join(",", categoryIds)})";
            //return await Db.ExecuteAsync(addCountSql, uow);
        }

        /// <summary>
        /// 重现运算逻辑 （用目前ORM写不出来)
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        public async Task<int> RecalculationCount(int[] categoryIds, IUnitOfWork uow = null)
        {
            string databaseName = EntityDescriptorCollection.Get<CategoryEntity>().Database;
            string addCountSql = $"update {databaseName}category as t1 set Count=(select count(1) from topic as t2 where t2.categoryId=t1.id) where id in ({string.Join(",", categoryIds)})";
            return await Db.ExecuteAsync(addCountSql, uow);
        }

        public async Task<IList<CategoryEntity>> Query(CategoryQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();

            if (!paging.OrderBy.Any())
            {
                query.OrderByDescending(m => m.Sort);
            }

            var result = await query.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;

            return result;
        }


        public async Task<IList<CategoryEntity>> GetList()
        {
            return await Db.Find().OrderBy(o => o.Sort).ToListAsync();
        }
    }
}
