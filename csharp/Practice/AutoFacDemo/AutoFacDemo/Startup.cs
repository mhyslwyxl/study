using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoFacDemo.AOP;
using AutoFacDemo.MiddleWare;
using AutoFacDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutoFacDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddControllersAsServices();

            //services.AddScoped<IHelloService>(x => new HelloService());

            //var builder = new ContainerBuilder();
            //builder.Populate(services);

            //builder.RegisterType<HelloService>().As<IHelloService>()
            //    .AsImplementedInterfaces()
            //    .PropertiesAutowired()
            //    .EnableInterfaceInterceptors();

            //builder.RegisterType<TestInterceptor>();
            ////builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            ////.AsImplementedInterfaces()
            ////.EnableInterfaceInterceptors();
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

            //app.UseMiddleware<InterceptMiddlware>();
            app.UseInterceptMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // 在这里添加服务注册
            builder.RegisterType<HelloService>();

            builder.RegisterType<TestInterceptor>(); // 要先注册拦截器

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors();

            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                .PropertiesAutowired() // 允许属性注入
                .EnableClassInterceptors(); // 允许在Controller类上使用拦截器
        }
    }
}
