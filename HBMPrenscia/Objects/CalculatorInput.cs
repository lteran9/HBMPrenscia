using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMPrenscia.Objects
{
    public abstract class CalculatorInput
    {
        public string Value { get; }

        public Precedence InputPrecedence { get; }

        public CalculatorInput(string _value)
        {
            this.Value = _value;
            this.InputPrecedence = GetPrecedence();
        }

        private Precedence GetPrecedence()
        {
            if (!string.IsNullOrEmpty(Value))
            {
                if (Value == "*" || Value == "/")
                    return Precedence.High;
            }

            return Precedence.Low;
        }

        public enum Precedence
        {
            Low,
            High
        }
    }
}
