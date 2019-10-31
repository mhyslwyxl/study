using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Models.Interpreter
{
    public class RunDemo
    {
        public static void Run()
        {
            string number = "10";
            Context context = new Context(number);
            Expression expression = new PlusExpression();
            expression.Interpret(context);
            Console.WriteLine(context.Ounput);
        }
    }
}
