using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurse.Entities
{
    public class TestVueMenus
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }

        public bool Flag { get; set; } = true;

        public IList<TestVueMenus> ChildMenu { get; set; }
    }
}
