using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Nurse.Entities;

namespace Nurse.CoreApi.Controllers
{
    
    [EnableCors("Domain")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenusController : ControllerBase
    {


        // GET: api/Menus
        [HttpGet]
        public IActionResult Get()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("JsonFile/menus.json");
            var config = builder.Build();
            IList<TestVueMenus> menus = new List<TestVueMenus>()
            {
                new TestVueMenus{ Title= config["menus:0:title"], Icon=config["menus:0:icon"],
                    ChildMenu =new List<TestVueMenus>
                    {
                        new TestVueMenus{ Title = config["menus:0:childMenu:0:title"], Flag = config["menus:0:childMenu:0:Flag"]=="true",Path= config["menus:0:childMenu:0:path"]  },
                        new TestVueMenus{ Title = config["menus:0:childMenu:1:title"], Flag = config["menus:0:childMenu:1:Flag"]=="true",Path= config["menus:0:childMenu:1:path"]  },
                        new TestVueMenus{ Title = config["menus:0:childMenu:2:title"], Flag = config["menus:0:childMenu:2:Flag"]=="true",Path= config["menus:0:childMenu:2:path"]  },
                        new TestVueMenus{ Title = config["menus:0:childMenu:3:title"], Flag = config["menus:0:childMenu:3:Flag"]=="true",Path= config["menus:0:childMenu:3:path"]  }

                    }},
                new TestVueMenus{ Title= config["menus:1:title"], Icon=config["menus:1:icon"],
                    ChildMenu =new List<TestVueMenus>
                    {
                        new TestVueMenus{ Title = config["menus:1:childMenu:0:title"],Path= config["menus:1:childMenu:0:path"]  },
                        new TestVueMenus{ Title = config["menus:1:childMenu:1:title"],Path= config["menus:1:childMenu:1:path"]  },
                       
                    }}
            };
            
            return Ok(menus);
        }

        // GET: api/Menus/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Menus
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Menus/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
