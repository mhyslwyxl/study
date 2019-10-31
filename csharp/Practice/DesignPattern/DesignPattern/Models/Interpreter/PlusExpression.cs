using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Models.Interpreter
{
    public class PlusExpression : Expression
    {
        public override void Interpret(Context context)
        {
            //提示信息
            Console.WriteLine("自动递增");
            //获取上下文环境
            string input = context.Input;
            //类型和转换
            int intInput = int.Parse(input);
            //递增
            ++intInput;
            //重新赋值
            context.Input = intInput.ToString();
            context.Ounput = intInput;
        }

    }
}
