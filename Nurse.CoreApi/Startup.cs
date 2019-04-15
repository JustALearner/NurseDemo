using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Nurse.Business;
using Nurse.IBusiness;
using Nurse.IRepository;
using Nurse.Repositories;
using SqlSugar;

namespace Nurse.CoreApi
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnv;
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnv)
        {
            Configuration = configuration;
            _hostingEnv = hostingEnv;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSqlSugarClient<DbFactory>((serviceProvider, config) =>
            {
                config.ConnectionString = serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection");
                config.DbType = DbType.SqlServer;
                config.IsAutoCloseConnection = true;
                config.InitKeyType = InitKeyType.Attribute;
                config.IsShardSameThread = false;
            });
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(factory =>
            {
                var actionContext = factory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(options =>

                {

                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1.0",
                        Title = "Nurse接口文档",
                        Description = "RESTful API for Nurse",
                        TermsOfService = null,
                        Contact = new OpenApiContact { Name = "zac", Email = "636984860@QQ.com", Url = null }
                    });

                    // 注释
                    options.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");

                    // Tags描述
                    //                options.DocumentFilter<TagDescriptionsDocumentFilter>();


                }

            );

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserBusiness, UserBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseMvc();                     
            app.UseSwagger().UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
           
        }
    }
}
