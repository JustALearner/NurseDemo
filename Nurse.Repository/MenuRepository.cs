using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nurse.Entities;
using Nurse.IRepository;

namespace Nurse.Repositories
{
    class MenuRepository : BaseRepository<TestVueMenus>, IDependency, IMenuRepository
    {
        public MenuRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
