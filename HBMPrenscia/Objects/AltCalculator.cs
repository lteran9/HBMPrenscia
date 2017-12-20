using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMPrenscia.Objects
{
    /// <summary>
    /// @author TeranL
    /// @date 12/18/2017
    /// 
    /// This is a refactored version of the first part of the assignment. The 
    /// purpose of this scheme is to provide a less verbose API for calculating
    /// the result of equations involving addition, subtraction, multiplication,
    /// and division. 
    /// 
    /// Important: This class makes use of the Shunting Yard Algorithm to translate
    /// the equation (as a string) into Reverse Polish Notation (RPN). The RPN is
    /// then processed in postfix notation to return the result of the equation.
    /// 
    /// PART II
    /// </summary>
    public sealed class AltCalculator
    {
        /// Keep track of last ten calculations
        private static Queue<string> resultIndex = null;

        public static Queue<string> ResultIndex
        {
            get
            {
                if (resultIndex == null)
                {
                    resultIndex = new Queue<string>();
                }

                return resultIndex;
            }
        }

        /// <summary>
        /// This method will receive a string equation and calculate the 
        /// result by converting the equation to postfix notation. You can
        /// find more details about the Shunting-Yard Algorithm at:
        ///     https://en.wikipedia.org/wiki/Shunting-yard_algorithm
        ///     
        /// </summary>
        /// <param name="equation">Infix notation equation. Does not support parentheses.</param>
        /// <returns>Result of the equation.</returns>
        public static string Calculate(string equation)
        {
            var Operators = new Stack<Operator>();
            var Output = new Stack<CalculatorInput>();

            /// (1) Build postfix notation object 
            BuildOutput(equation, ref Operators, ref Output);

            /// (2) Move remaining operators over to input
            MoveOperators(ref Operators, ref Output);

            /// (3) Object should return with 1 value
            var stack = ProcessPostfixNotation(Output);

            /// (4) Only track last ten results
            if (ResultIndex.Count >= 10)
                ResultIndex.Dequeue();

            var result = stack.Pop();
            ResultIndex.Enqueue(result.Value);

            /// (5) Return result of equation
            return result.Value;
        }

        public static string GetPreviousResult(int index)
        {
            if (index >= 0 && index < ResultIndex.Count)
                /// Most recent result at lower index (0)
                return ResultIndex.Reverse().ElementAt(index);

            return string.Empty;
        }

        public static void Clear()
        {
            resultIndex = null;
        }

        private static void BuildOutput(string equation, ref Stack<Operator> operators, ref Stack<CalculatorInput> output)
        {
            if (equation.Length <= 0)
                throw new InvalidParameterException();

            /// Add space to distinguish between multiple digit numbers
            equation = equation.Replace("*", " * ");
            equation = equation.Replace("+", " + ");
            equation = equation.Replace("-", " - ");
            equation = equation.Replace("/", " / ");

            foreach (var c in equation.Split(' '))
            {
                switch (c)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        while (operators.Count > 0 && operators.Peek().InputPrecedence == CalculatorInput.Precedence.High)
                        {
                            /// Higher precedence operators * && /
                            output.Push(operators.Pop());
                        }

                        operators.Push(new Operator(c.ToString()));
                        break;
                    default:
                        if (c != "(" && c != ")")
                            output.Push(new Operand(c.ToString()));
                        break;
                }
            }
        }

        private static void MoveOperators(ref Stack<Operator> from, ref Stack<CalculatorInput> to)
        {
            while (from.Count > 0)
            {
                to.Push(from.Pop());
            }
        }

        private static Stack<CalculatorInput> ProcessPostfixNotation(Stack<CalculatorInput> output)
        {
            var stack = new Stack<CalculatorInput>();

            foreach (var o in output.Reverse())
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

            return stack;
        }
    }
}
