using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMPrenscia.Objects
{
    /// <summary>
    /// @author TeranL
    /// @date 12/19/2017
    /// 
    /// This is a refactored version of the first part of the assignment. It 
    /// contains almost no code from the original implementation.
    /// </summary>
    public static class AltCalculator
    {
        /// Keep track of last ten calculations
        private static Queue<string> ResultIndex = new Queue<string>();

        public static string Calculate(string equation)
        {
            var Operators = new Stack<CalculatorInput>();
            var Output = new Stack<CalculatorInput>();

            /// (1) Build postfix notation object 
            foreach (var c in equation.Split(' '))
            {
                switch (c)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        if (Operators.Count > 0)
                        {
                            var op = Operators.Peek();

                            while (op.InputPrecedence == CalculatorInput.Precedence.High)
                            {
                                /// Higher precedence operators * && /
                                Output.Push(Operators.Pop());
                            }
                        }

                        Operators.Push(new Operator(c.ToString()));
                        break;
                    default:
                        if (c != "(" && c != ")")
                            Output.Push(new Operand(c.ToString()));
                        break;
                }
            }

            /// (2) Move remaining operators over to input
            while (Operators.Count > 0)
            {
                Output.Push(Operators.Pop());
            }

            /// (3) Process postfix notation object
            var stack = new Stack<CalculatorInput>();

            foreach (var o in Output.Reverse())
            {
                if (o.GetType() == typeof(Operator))
                {
                    int right = int.Parse(stack.Pop().Value);
                    int left = int.Parse(stack.Pop().Value);

                    var operation = (Operator)o;
                    var opResult = new Operand(operation.ApplyOperation(left, right));
                    stack.Push(opResult);
                }
                else
                {
                    stack.Push(o);
                }
            }

            /// (4) Only track last ten results
            if (ResultIndex.Count >= 10)
                ResultIndex.Dequeue();

            var result = stack.Pop();
            ResultIndex.Enqueue(result.Value);

            return result.Value;
        }

        public static string GetPreviousResult(int index)
        {
            if (index < ResultIndex.Count)
                return ResultIndex.ElementAt(index);

            return string.Empty;
        }

        public static void Clear()
        {
            ResultIndex = new Queue<string>();
        }
    }
}
