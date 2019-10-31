using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Models.Adapter.Method2
{
    public class Adapter : IAdapter
    {
        private Current current ;
        public Adapter(Current current)
        {
            this.current = current;
        }

        public void Use18V()
        {
            current.Use220V();
            Console.WriteLine("转换为18V电压输出");
        }
    }
}
