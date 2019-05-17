using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nurse.CoreApi
{
    //添加通用参数，若in='header'则添加到header中,默认query参数
    public class AssignOperationVendorExtensions : IOperationFilter
    {
        /// <summary>
        /// apply
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation == null || context == null)
                return;
            operation.Parameters = operation.Parameters ?? new List<IParameter>();

            //token
            var isAuthor = true;
//                context.ApiDescription.ControllerAttributes().Any(e => e.GetType() == typeof(UserAuthorizeAttribute)) ||
//                context.ApiDescription.ActionAttributes().Any(e => e.GetType() == typeof(UserAuthorizeAttribute));
            if (isAuthor)
            {
                //in query header 
                operation.Parameters.Insert(0,
                    new NonBodyParameter()
                        {Name = "X-Token", In = "header", Description = "身份验证票据", Required = true, Type = "string"});
            }


           
        }
    }
}