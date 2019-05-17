
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nurse.Business;
using Nurse.Common.CacheHelper;
using Nurse.IBusiness;
using Nurse.IRepository;
using Nurse.Repositories;
using SqlSugar;
using Swashbuckle.Swagger;
using Swashbuckle.AspNetCore.Swagger;
using Nurse.Token.Model;
using System.Text;
using IdentityModel;

namespace Nurse.CoreApi
{
    public class StartupDevelopment
    {
        private readonly IHostingEnvironment _hostingEnv;

        public StartupDevelopment(IConfiguration configuration, IHostingEnvironment hostingEnv)
        {
            Configuration = configuration;
            _hostingEnv = hostingEnv;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            var cacheProvider = Configuration["CachePorviderName"];
            if (cacheProvider == "CacheMemory")
            {
                //Use MemoryCache
                services.AddSingleton<IMemoryCache>(factory =>
                {
                    var cache = new MemoryCache(new MemoryCacheOptions());
                    return cache;
                });
                services.AddSingleton<Nurse.Common.CacheHelper.ICacheService, MemoryCacheService>();
            }

            //将appsettings.json中的JwtSettings部分文件读取到JwtSettings中，这是给其他地方用的
            services.Configure<JwtSettiing>(Configuration.GetSection("JwtSettings"));

            //由于初始化的时候我们就需要用，所以使用Bind的方式读取配置
            //将配置绑定到JwtSettings实例中
            var jwtSettings = new JwtSettiing();
            Configuration.Bind("JwtSettiing", jwtSettings);

            services.AddAuthentication(options =>
            {
                //认证middleware配置
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    //主要是jwt  token参数设置
                    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        NameClaimType = JwtClaimTypes.Name,
                        RoleClaimType = JwtClaimTypes.Role,

                        //Token颁发机构
                        ValidIssuer = jwtSettings.Issuer,
                        //颁发给谁
                        ValidAudience = jwtSettings.Audience,
                        //这里的key要进行加密，需要引用Microsoft.IdentityModel.Tokens
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                        /***********************************TokenValidationParameters的参数默认值***********************************/
                        // RequireSignedTokens = true,
                        // SaveSigninToken = false,
                        // ValidateActor = false,
                        // 将下面两个参数设置为false，可以不验证Issuer和Audience，但是不建议这样做。
                        // ValidateAudience = true,
                        // ValidateIssuer = true, 
                        // ValidateIssuerSigningKey = false,
                        // 是否要求Token的Claims中必须包含Expires
                        // RequireExpirationTime = true,
                        // 允许的服务器时间偏移量
                        // ClockSkew = TimeSpan.FromSeconds(300),
                        // 是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                        // ValidateLifetime = true

                    };
                });


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

            var dict = new Dictionary<string, IEnumerable<string>>();
            dict.Add("Bearer", Enumerable.Empty<string>());
            services.AddSwaggerGen(options =>
                {

                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1.0",
                        Title = "Nurse接口文档",
                        Description = "RESTful API for Nurse",
                        TermsOfService = null,
                        Contact = new OpenApiContact {Name = "zac", Email = "636984860@QQ.com", Url = null}
                    });

                    // 注释
                    options.IncludeXmlComments(
                        $"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");

                    // Tags描述
                    //                options.DocumentFilter<TagDescriptionsDocumentFilter>();
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "请输入带有Bearer的Token",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey

                    });

                    //Json Token认证方式，此方式为全局添加
//                    options.AddSecurityRequirement(dict);

                }
            );

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserBusiness, UserBusiness>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseDeveloperExceptionPage();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseSwagger().UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
            app.UseMvc();
        }
    }
}
