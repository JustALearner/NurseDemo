using System.Collections.Generic;
using System.Threading.Tasks;
using Nurse.Entities;
using Nurse.IRepository;


namespace Nurse.Repositories
{
    public class UserRepository:BaseRepository<T_Sys_User>, IDependency, IUserRepository
    {
        public UserRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }

}
