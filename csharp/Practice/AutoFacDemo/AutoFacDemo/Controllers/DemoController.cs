using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using AutoFacDemo.AOP;
using AutoFacDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoFacDemo.Controllers
{
    [Intercept(typeof(TestInterceptor))]
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IHelloService _hello;
        private readonly IServiceProvider _provider;

        public IHelloService Service { get; set; }

        public DemoController(IHelloService hello, IServiceProvider provider)
        {
            _hello = hello;
            _provider = provider;
        }

        [ActionFilter]
        [HttpGet]
        public string Get()
        {
            // 构造函数注入
            return _hello.SayHello();
        }

        [HttpGet("get2")]
        public string Get2()
        {
            // 构造函数注入
            return Service.SayHello();
        }

        // 会触发拦截器
        [HttpGet("get3")]
        public virtual string Get3(int id)
        {
            // 构造函数注入
            return "this is get3";
        }

        [ActionFilter]
        // 不会触发拦截器
        [HttpGet("get4")]
        public string Get4(int id)
        {
            return "this is get4";
        }

        //应该2次
        [HttpGet("get5")]
        public virtual string Get5()
        {
            // 构造函数注入
            return _hello.SayHello();
        }

        [HttpGet("get6")]
        public virtual string Get6()
        {
            // 构造函数注入
            return Service.SayHello();
        }
    }
}
