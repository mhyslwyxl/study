using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Jwt.Gateway.MiddleWares;
using Microsoft.Extensions.DependencyInjection;

namespace Jwt.Gateway
{
    public class Startup
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
                    {
                        /*OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Query["access_token"];
                            return Task.CompletedTask;
                        },*/
                        OnTokenValidated = context =>
                        {
                            var token = ((System.IdentityModel.Tokens.Jwt.JwtSecurityToken)context.SecurityToken).RawData;
                            if (InBlacklist(token))
                            {
                                context.Fail("token in blacklist");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = _configuration["JwtTokenAudience"],
                        ValidIssuer = _configuration["JwtTokenIssuer"],
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]))
                    };
                });
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseApiCustomException(new ApiCustomExceptionMiddleWareOption(
                     handleType: ApiCustomExceptionHandleType.Both,
                     jsonHandleUrlKeys: new PathString[] { "/api" },
                     errorHandingPath: "/home/error"));

            app.UseAuthentication();


            app.UseMvc();
        }



        bool InBlacklist(string token)
        {
            //code: 实际项目中应该查询数据库或配置文件进行比对

            return false;
        }


    }
}
 