using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nurse.Common;
using Nurse.IRepository;
using Nurse.VModel;

namespace Nurse.Business
{
    public abstract class BaseBusiness<T>where T:class,new()
    {
        private readonly IRepository<T> _repository;

        protected BaseBusiness(IRepository<T> repository)
        {
            this._repository = repository;
        }
      
        public async Task<PagedList<T>> GetPagedEntitiesAsync(QueryParameters  queryParameters)
       {
           return await _repository.GetPagedEntitiesAsync(queryParameters);
       }

        public Task<T> GetEntityByIdAsync(int id)
        {
            return _repository.GetEntityByIdAsync(id);
        }
        public IList<T> GetEntityBySql(string sql)
        {
            return _repository.GetEntityBySql(sql);
        }

        public async Task<IEnumerable<T>> GetAllEntitiesAsync()
        {
            var list = await _repository.GetAllEntitiesAsync();
            return list;
        }

        public void Update(T user)
        {
            throw new NotImplementedException();
        }

        public void Delete(T user)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(T user)
        {
            throw new NotImplementedException();
        }
    }
}
