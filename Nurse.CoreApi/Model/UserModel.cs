using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nurse.CoreApi.Model
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
    }
}
