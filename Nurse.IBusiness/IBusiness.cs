using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nurse.Common;
using Nurse.VModel;

namespace Nurse.IBusiness
{
    public interface IBusiness<T>where T:class,new()
    {
        Task<PagedList<T>> GetPagedEntitiesAsync(QueryParameters postParameters);
        Task<IEnumerable<T>> GetAllEntitiesAsync();

        Task<T> GetEntityByIdAsync(int id);
        IList<T> GetEntityBySql(string sql);
        void AddEntity(T user);
        void Delete(T user);
        void Update(T user);
    }
}
