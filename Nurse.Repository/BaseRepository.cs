using System.Collections.Generic;
using System.Threading.Tasks;
using Nurse.Common;
using Nurse.Entities;
using Nurse.VModel;
using SqlSugar;

namespace Nurse.Repositories
{
    public abstract class BaseRepository<T>where T:class,new()
    {
        protected internal DbFactory DbFactory;
//                protected SqlSugarClient Db { get; } = DbFactory.GetInstance();
        protected SqlSugarClient Db;

        protected BaseRepository(DbFactory dbFactory)
        {
            DbFactory = dbFactory;
            Db = dbFactory.GetDbContext();
        }
        public async Task<PagedList<T>> GetPagedEntitiesAsync(QueryParameters queryParameters)
        {

           var list= await Db.Queryable<T>().ToPageListAsync(queryParameters.PageIndex, queryParameters.PageSize);
            var count = await Db.Queryable<T>().CountAsync();
            return new PagedList<T>(queryParameters.PageIndex, queryParameters.PageSize, count, list);

        }
        public async Task<IEnumerable<T>> GetAllEntitiesAsync()
        {
            var list = await Db.Queryable<T>().ToListAsync();
          
            return list;
        }

        public void Update(T entity)
        {
            Db.Updateable<T>(entity).ExecuteCommand();

        }

        public void Delete(T entity)
        {
           
            Db.Deleteable<T>(entity).ExecuteCommand();
        }

        public void AddEntity(T entity)
        {
            Db.Insertable<T>(entity).ExecuteCommand();
        }

        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await Task.Factory.StartNew<T>(() => Db.Queryable<T>().InSingle(id));
        }
    }
}
