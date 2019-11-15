using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOPTest.IServices;
using Autofac.Extras.DynamicProxy;
using AOPTest.AOP;

namespace AOPTest.Services
{
    //[Intercept(typeof(AOPDemo))]
    public class Userservice : IUserservice
    {
        public string SayHello()
        {
            return "Hello World!";
        }
    }
}
