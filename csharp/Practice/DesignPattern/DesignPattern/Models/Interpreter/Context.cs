using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Models.Interpreter
{
    public class Context
    {
        public string Input { get; set; }
        public int Ounput { get; set; }

        public Context(string input)
        {
            Input = input;
        }
    }
}
