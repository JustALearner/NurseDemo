using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nurse.Common;
using Nurse.VModel;


namespace Nurse.IRepository
{
   public  interface IRepository<T> where T:class,new()
    {
        Task<PagedList<T>> GetPagedEntitiesAsync(QueryParameters queryParameters);
        Task<IEnumerable<T>> GetAllEntitiesAsync( );
        Task<T> GetEntityByIdAsync(int id);
        void AddEntity(T user);
        void Delete(T user);
        void Update(T user);
    }

}
