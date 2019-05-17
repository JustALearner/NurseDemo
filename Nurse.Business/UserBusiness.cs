using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nurse.Common;
using Nurse.Entities;
using Nurse.IBusiness;
using Nurse.IRepository;

namespace Nurse.Business
{
    public class UserBusiness: BaseBusiness<T_Sys_User>,IDependency,  IUserBusiness
    {
   
        public UserBusiness(IUserRepository repository) : base(repository)
        {
        }


      
    }
}
