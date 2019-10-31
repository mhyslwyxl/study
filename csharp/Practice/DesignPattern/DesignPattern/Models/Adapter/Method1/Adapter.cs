using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Models.Adapter.Method1
{
    public class Adapter : Current, IAdapter
    {
        public void Use18V()
        {
            this.Use220V();
            Console.WriteLine("转换为18V电压输出");
        }
    }
}
