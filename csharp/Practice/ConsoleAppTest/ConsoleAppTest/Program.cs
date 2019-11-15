using System;

namespace ConsoleAppTest
{
    class Program
    {
        delegate void TestDelegate(string s);
        static void M(string s)
        {
            Console.WriteLine(s);
        }

        delegate void MyDelegate(int circleCount, string s);
        static void Main(string[] args)
        {
            // Original delegate syntax required 
            // initialization with a named method.
            TestDelegate testDelA = new TestDelegate(M);

            // C# 2.0: A delegate can be initialized with
            // inline code, called an "anonymous method." This
            // method takes a string as an input parameter.
            TestDelegate testDelB = delegate (string s) { Console.WriteLine(s); };

            // C# 3.0. A delegate can be initialized with
            // a lambda expression. The lambda also takes a string
            // as an input parameter (x). The type of x is inferred by the compiler.
            TestDelegate testDelC = (x) => { Console.WriteLine(x); };

            // Invoke the delegates.
            testDelA("Hello. My name is M and I write lines.");
            testDelB("That's nothing. I'm anonymous and ");
            testDelC("I'm a famous author.");

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");

            MyDelegate md = (x, y) =>
            {
                for (int i = 0; i < x; i++)
                    Console.WriteLine(y);
            };

            md(2, "aaasss cccvvv");
            Console.ReadKey();
        }
    }
}
