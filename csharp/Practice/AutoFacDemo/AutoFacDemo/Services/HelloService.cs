using Autofac.Extras.DynamicProxy;
using AutoFacDemo.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacDemo.Services
{
    [Intercept(typeof(TestInterceptor))]
    public interface IHelloService
    {
        string SayHello();
    }

   
    public class HelloService : IHelloService
    {
        public string SayHello()
        {
            return "Hello World!";
        }
    }
}
