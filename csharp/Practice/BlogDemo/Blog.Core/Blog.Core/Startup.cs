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
using Blog.Core.AuthHelper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using static Blog.Core.SwaggerHelper.CustomApiVersion;
using System.Linq;

namespace Blog.Core
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        private const string ApiName = "Blog.Core";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton(new Appsettings(Env.ContentRootPath));
            services.AddSingleton(new Appsettings());
            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            //});
            string version = "v1";
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            services.AddSwaggerGen(c =>
            {
                //������ȫ���İ汾�����ĵ���Ϣչʾ
                //typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                //{
                c.SwaggerDoc(version, new OpenApiInfo
                {
                    // {ApiName} �����ȫ�ֱ����������޸�
                    Version = version,
                    Title = $"{ApiName} �ӿ��ĵ�����Netcore 3.0",
                    Description = $"{ApiName} HTTP API " + version,
                    Contact = new OpenApiContact { Name = ApiName, Email = "Blog.Core@xxx.com", Url = new Uri("https://www.jianshu.com/u/94102b59cc2a") },
                    License = new OpenApiLicense { Name = ApiName, Url = new Uri("https://www.jianshu.com/u/94102b59cc2a") }
                });
                c.OrderActionsBy(o => o.RelativePath);
                //});


                //��������
                var xmlPath = Path.Combine(basePath, "Blog.Core.xml");//������Ǹո����õ�xml�ļ���
                c.IncludeXmlComments(xmlPath, true);//Ĭ�ϵĵڶ���������false�������controller��ע�ͣ��ǵ��޸�

                var xmlModelPath = Path.Combine(basePath, "Blog.Core.Model.xml");//�������Model���xml�ļ���
                c.IncludeXmlComments(xmlModelPath);

                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                c.OperationFilter<SecurityRequirementsOperationFilter>();

                #region Token�󶨵�ConfigureServices
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey
                });
                #endregion
            });

            //string secret = Appsettings.app(new string[] { "Audience", "Secret" });
            //var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            //var audienceConfig = Configuration.GetSection("Audience");

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
            //    options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
            //    options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));
            //    options.AddPolicy("A_S_O", policy => policy.RequireRole("Admin", "System", "Others"));
            //})
            //.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        //ValidateIssuerSigningKey = true,
            //        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
            //        //ValidateIssuer = false,
            //        //ValidateAudience = false
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = signingKey,
            //        ValidateIssuer = true,
            //        ValidIssuer = audienceConfig["Issuer"],//������
            //        ValidateAudience = true,
            //        ValidAudience = audienceConfig["Audience"],//������
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.FromSeconds(30),
            //        RequireExpirationTime = true,
            //    };
            //});
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
            //app.UseAuthentication();
            //app.UseMiddleware<JwtTokenAuth>();//ע�����Ȩ�����Ѿ���������ʹ���±ߵĹٷ���֤��������������㻹�봫User��ȫ�ֱ��������ǿ��Լ���ʹ���м��
            //�Զ�����֤�м��
            app.UseJwtTokenAuth(); //Ҳ����app.UseMiddleware<JwtTokenAuth>();
            app.UseAuthorization();
            #endregion Authen

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}