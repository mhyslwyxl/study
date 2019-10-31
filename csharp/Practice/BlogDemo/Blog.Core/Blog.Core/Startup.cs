using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Blog.Core.Common;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Blog.Core.Middlewares;
using Blog.Core.AuthHelper; 
using System.Threading.Tasks;

namespace Blog.Core
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new Appsettings(Env.ContentRootPath));

            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v0.1.0",
                    Title = "Blog.Core",
                    Description = "���˵���ĵ�",
                    Contact = new OpenApiContact
                    {
                        Name = "Blog.Core",
                        Email = "Blog.Core@xxx.com",
                        Url = new System.Uri("https://www.jianshu.com/u/121212")
                    }
                });

                #region ��ȡxml��Ϣ
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Blog.Core.xml");//������Ǹո����õ�xml�ļ���
                c.IncludeXmlComments(xmlPath, true);//Ĭ�ϵĵڶ���������false�������controller��ע�ͣ��ǵ��޸�

                var xmlModelPath = Path.Combine(basePath, "Blog.Core.Model.xml");//�������Model���xml�ļ���
                c.IncludeXmlComments(xmlModelPath);
                #endregion

                #region Token�󶨵�ConfigureServices
                //���header��֤��Ϣ
                //c.OperationFilter<SwaggerHeader>();
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                //var security = new Dictionary<string, IEnumerable<string>> { { "Blog.Core", new string[] { } }, };
                //c.AddSecurityRequirement(security);
                //�������ơ�Blog.Core�����Զ��壬����һ�¼���
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey
                });
                #endregion
                //services.AddJwtConfiguration(Configuration);
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));
                options.AddPolicy("A_S_O", policy => policy.RequireRole("Admin", "System", "Others"));
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Issuer"],//������
                ValidateAudience = true,
                ValidAudience = audienceConfig["Audience"],//������
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(30),
                RequireExpirationTime = true,
            };

            services.AddAuthentication("Bearer")
             // ���JwtBearer����
             .AddJwtBearer(o =>
             {
                 o.TokenValidationParameters = TokenValidationParameters;
                 o.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         // ������ڣ����<�Ƿ����>��ӵ�������ͷ��Ϣ��
                         if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                         {
                             context.Response.Headers.Add("Token-Expired", "true");
                         }
                         return Task.CompletedTask;
                     }
                 };
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                #region Swagger

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    //֮ǰ��д����
                    //c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
                    //c.RoutePrefix = "";//·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�ȥlaunchSettings.json��launchUrlȥ��

                    //���ݰ汾���Ƶ��� ����չʾ
                    //typeof(ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
                    //{
                    //    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{ApiName} {version}");
                    //});
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog.Core v1");
                    c.RoutePrefix = "";
                });
                //�����м����������Swagger��ΪJSON�ս��
                //app.UseSwagger();
                ////�����м�������swagger-ui��ָ��Swagger JSON�ս��
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog.Core V1");
                //});
                #endregion Swagger
            }
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    app.UseHsts();
            //}

            #region CORS

            //����ڶ��ַ�����ʹ�ò��ԣ���ϸ������Ϣ��ConfigureService��
            app.UseCors("LimitRequests");//�� CORS �м����ӵ� web Ӧ�ó��������, �������������

            //�����һ�ְ汾����ҪConfigureService�����÷��� services.AddCors();
            //    app.UseCors(options => options.WithOrigins("http://localhost:8021").AllowAnyHeader()
            //.AllowAnyMethod());

            #endregion CORS

            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();
            //app.UseStatusCodePages();//�Ѵ����뷵��ǰ̨��������404
            app.UseRouting();

            #region Authen
            app.UseMiddleware<JwtTokenAuth>();//ע�����Ȩ�����Ѿ���������ʹ���±ߵĹٷ���֤��������������㻹�봫User��ȫ�ֱ��������ǿ��Լ���ʹ���м��
            //app.UseAuthentication();
            #endregion Authen

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}