using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Nurse.AutoMapperConfig;
using Nurse.Common;
using Nurse.IBusiness;
using Nurse.VModel;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Nurse.Api.Controllers
{
    [System.Web.Http.RoutePrefix("Api")]
    public class UserController : ApiController
    {
       
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;

        }

        public UserController()
        {

        }
        [System.Web.Http.Route("users", Name = "GetUsers")]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Get([FromUri]QueryParameters postParameters)
        {

            //var users = await _userBusiness.GetAllEntitiesAsync();
            var users = await _userBusiness.GetPagedEntitiesAsync(postParameters);

            if (users == null)
            {
                return NotFound();
            }
           
           var userVMs = AutoMapperConfiguration.Mapper.Map<IEnumerable<UserViewModel>>(users);
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
            HttpContext.Current.Response.Headers.Add("x-Pagination", JsonConvert.SerializeObject(ret,new JsonSerializerSettings(){ ContractResolver=new CamelCasePropertyNamesContractResolver()}));
            //return Ok(new PagedList<UserViewModel>(pageIndex, pageSize, users.TotalItemCount, userVMs));
            return Ok(userVMs);
        }

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var user = await _userBusiness.GetEntityByIdAsync(id);


            if (user == null)
            {
                return NotFound();
            }

            //_mapper.Map<UserViewModel>(user);
            try
            {
                var userVm = user.ToModel();
                return Ok(userVm);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }



        }


        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
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
                    return Url.Link("GetUsers", previousParameters);
                case PaginationResourceUriType.NextPage:
                    var nextParameters = new
                    {
                        pageIndex = parameters.PageIndex + 1,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        fields = parameters.Fields
                    };
                    var struri= Url.Link("GetUsers", nextParameters);
                    return Url.Link("GetUsers", nextParameters);
                default:
                    var currentParameters = new
                    {
                        pageIndex = parameters.PageIndex,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        fields = parameters.Fields
                    };
                    return Url.Link("GetUsers", currentParameters);
            }
        }
    }

}
