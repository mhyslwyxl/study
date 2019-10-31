using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Models.Interpreter
{
    public abstract class Expression
    {
        public abstract void Interpret(Context context);
    }
}
