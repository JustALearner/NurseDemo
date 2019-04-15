using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nurse.VModel;
using Nurse.IBusiness;
namespace Nurse.CoreApi.Controllers
{
    /// <summary>
    /// 用户相关
    /// </summary>
    [ApiController]
    [Route("api/Users")] 
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IMapper _mapper;
        private readonly IUrlHelper _urlHelper;

        public UserController(IUserBusiness userBusiness, IMapper mapper, IUrlHelper urlHelper)
        {
            _mapper = mapper;
            _urlHelper = urlHelper;
            _userBusiness = userBusiness;
        }
        // GET: api/User
        /// <summary>
        /// 获取用户信息列表()
        /// </summary>
        /// <param name="postParameters"></param>
        /// <returns></returns>
        [HttpGet(Name ="GetUsers")]
        public async Task<IActionResult> Get([FromQuery]QueryParameters postParameters)
                                                                                                                                                                                                                                                                                 {

            //var users = await _userBusiness.GetAllEntitiesAsync();
            var users = await _userBusiness.GetPagedEntitiesAsync(postParameters);

            if (users == null)
            {
                return NotFound();
            }

            var userVMs = _mapper.Map<IEnumerable<UserViewModel>>(users);
            var previousPageLink = users.HasPrevious ?
                CreatePostUri(postParameters, PaginationResourceUriType.PreviousPage) : null;

            var nextPageLink = users.HasNext ?
                CreatePostUri(postParameters, PaginationResourceUriType.NextPage) : null;
            var ret = new
            {
                users.PerPageSize,
                users.PageIndex,
                users.TotalItemCount,
                users.PageCount,
                previousPageLink,
                nextPageLink

            };
            Response.Headers.Add("x-Pagination", JsonConvert.SerializeObject(ret, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
            //return Ok(new PagedList<UserViewModel>(pageIndex, pageSize, users.TotalItemCount, userVMs));
            return Ok(userVMs);
        }

        // GET: api/User/5
        [HttpGet("{id}",Name ="GetById")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        private string CreatePostUri(QueryParameters parameters, PaginationResourceUriType uriType)
        {

            switch (uriType)
            {
                case PaginationResourceUriType.PreviousPage:
                    var previousParameters = new
                    {
                        pageIndex = parameters.PageIndex - 1,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        fields = parameters.Fields
                    };
                    return _urlHelper.Link("GetUsers", previousParameters);
                case PaginationResourceUriType.NextPage:
                    var nextParameters = new
                    {
                        pageIndex = parameters.PageIndex + 1,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        fields = parameters.Fields
                    };                   
                    return _urlHelper.Link("GetUsers", nextParameters);
                default:
                    var currentParameters = new
                    {
                        pageIndex = parameters.PageIndex,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        fields = parameters.Fields
                    };
                    return _urlHelper.Link("GetUsers", currentParameters);
            }
        }
    }
}
