using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMPrenscia.Objects
{
    public class Operator : CalculatorInput
    {
        public Type OperatorType { get; }

        public Operator(string _value) : base(_value)
        {
            this.OperatorType = GetOperatorType();
        }

        public string ApplyOperation(int leftOp, int rightOp)
        {
            switch (OperatorType)
            {
                case Type.Addition:
                    return (leftOp + rightOp).ToString();
                case Type.Subtraction:
                    return (leftOp - rightOp).ToString();
                case Type.Multiplication:
                    return (leftOp * rightOp).ToString();
                case Type.Division:
                    return (leftOp / rightOp).ToString();
                default:
                    return string.Empty;
            }
        }

        private Type GetOperatorType()
        {
            if (!string.IsNullOrEmpty(Value))
            {
                switch (Value)
                {
                    case "*":
                        return Type.Multiplication;
                    case "/":
                        return Type.Division;
                    case "+":
                        return Type.Addition;
                    case "-":
                        return Type.Subtraction;
                    default:
                        return Type.Undefined;
                }
            }

            return Type.Addition;
        }

        public enum Type
        {
            Undefined,
            Addition,
            Subtraction,
            Multiplication,
            Division
        }
    }
}
