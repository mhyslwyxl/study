using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using WebApiDemo.Services;

namespace WebApiDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ////��Ӳ��Լ�Ȩģʽ
            //services.AddAuthorization(options =>
            //{
            //    //options.AddPolicy("Permission", policy => policy.Requirements.Add(new PolicyRequirement()));
            //    options.AddPolicy("Admin", policy => policy.RequireRole("admin"));
            //    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            //    options.AddPolicy("RequireClaim", policy => policy.RequireUserName("Admin"));
            //    //options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));
            //    //options.AddPolicy("A_S_O", policy => policy.RequireRole("Admin", "System", "Others"));
            //})
            //.AddAuthentication(s =>
            //{
            //    //���JWT Scheme
            //    s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    s.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            ////���jwt��֤��
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
            //        ClockSkew = TimeSpan.FromSeconds(30),

            //        ValidateAudience = true,//�Ƿ���֤Audience
            //        //ValidAudience = Const.GetValidudience(),//Audience
            //        //������ö�̬��֤�ķ�ʽ�������µ�½ʱ��ˢ��token����token��ǿ��ʧЧ��
            //        AudienceValidator = (m, n, z) =>
            //        {
            //            return m != null && m.FirstOrDefault().Equals(Const.ValidAudience);
            //        },
            //        ValidateIssuer = true,//�Ƿ���֤Issuer
            //        ValidIssuer = Const.Domain,//Issuer���������ǰ��ǩ��jwt������һ��

            //        ValidateIssuerSigningKey = true,//�Ƿ���֤SecurityKey
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Const.SecurityKey))//�õ�SecurityKey
            //    };
            //    options.Events = new JwtBearerEvents
            //    {
            //        OnAuthenticationFailed = context =>
            //        {
            //            //Token expired
            //            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            //            {
            //                context.Response.Headers.Add("Token-Expired", "true");
            //            }
            //            return Task.CompletedTask;
            //        }
            //    };
            //});
            services.AddJwtConfiguration(Configuration);

            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
