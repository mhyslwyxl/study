using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using WebApiDemo.AuthHelper;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.OpenApi.Models;

namespace WebApiDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Dictionary<string, string>>(Configuration.GetSection("Mime"));
            services.AddMvc();
            //.AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";//����ʱ���ʽ
            //});

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.1.0",
                    Title = "Ray WebAPI",
                    Description = "��ܼ���",
                    Contact = new OpenApiContact
                    {
                        Name = "RayWang",
                        Email = "2271272653@qq.com",
                        Url = new Uri("http://www.cnblogs.com/RayWang")
                    }
                });
                //���ע�ͷ���
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "APIHelp.xml");
                c.IncludeXmlComments(xmlPath);
                //��ӶԿ������ı�ǩ(����)
                //c.DocumentFilter<SwaggerDocTag>();

                //���header��֤��Ϣ
                //c.OperationFilter<SwaggerHeader>();
                //var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, };
                OpenApiSecurityRequirement security = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                };
                c.AddSecurityRequirement(security); //���һ�������ȫ�ְ�ȫ��Ϣ����AddSecurityDefinition����ָ���ķ�������Ҫһ�£�������Bearer��
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) �����ṹ: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey
                });
            });
            #endregion

            #region Token
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("System", policy => policy.RequireClaim("SystemType").Build());
                options.AddPolicy("Client", policy => policy.RequireClaim("ClientType").Build());
                options.AddPolicy("Admin", policy => policy.RequireClaim("AdminType").Build());
            });
            #endregion
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });
            #endregion

            #region TokenAuth
            app.UseMiddleware<TokenAuth>();
            #endregion

            app.UseMvc();

            app.UseStaticFiles();//���ڷ���wwwroot�µ��ļ� 
        }
    }
}
