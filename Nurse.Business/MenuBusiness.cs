using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nurse.Entities;
using Nurse.IBusiness;
using Nurse.IRepository;

namespace Nurse.Business
{
    class MenuBusiness : BaseBusiness<TestVueMenus>, IDependency, IMenuBusiness
    {
        public MenuBusiness(IMenuRepository repository) : base(repository)
        {
        }
    }
}
