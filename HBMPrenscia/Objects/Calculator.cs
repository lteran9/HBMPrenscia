using System;
using System.Collections.Generic;

namespace HBMPrenscia.Objects
{
    /// <summary>
    /// @author TeranL
    /// @date 12/19/2017
    /// 
    /// Calculator class exemplifying Object Oriented Principles (OOP)
    /// for HBM Prenscia. Concepts covered in this project:
    ///     (1) Encapsulation
    ///         - Class variables are not accessible from outside class definition.
    ///          
    ///     (2) Inheritance
    ///         - Custom exception class declarations inherit from base Exception class.
    ///                 
    ///     (3) Polymorphism
    ///         - 
    ///         
    /// PART 1
    /// </summary>
    public class Calculator
    {
        private string LeftOperand { get; set; }
        private string RightOperand { get; set; }
        private string Operator { get; set; }

        private Stack<string> ResultIndex { get; set; }

        public Calculator(string _left, string _right, string _operator)
        {
            if (!_left.ParseInt() || !_right.ParseInt() || !_operator.ParseOperator())
                throw new InvalidParameterException(); /// ~ symbolic declaration

            LeftOperand = _left;
            RightOperand = _right;
            Operator = _operator;

            ResultIndex = new Stack<string>();
        }

        public void SetRight(string value)
        {
            if (value.ParseInt())
                RightOperand = value;
        }

        public void SetLeft(string value)
        {
            if (value.ParseInt())
                LeftOperand = value;
        }

        public void Calculate()
        {
            Calculate(LeftOperand, RightOperand, Operator);
        }

        private void Calculate(string leftOp, string rightOp, string op)
        {
            string result = string.Empty;

            try
            {
                int left = Int32.Parse(leftOp);
                int right = Int32.Parse(rightOp);

                switch (Operator)
                {
                    case "+":
                        result = checked(left + right).ToString();
                        break;
                    case "-":
                        result = checked(left - right).ToString();
                        break;
                    case "*":
                        result = checked(left * right).ToString();
                        break;
                    case "/":
                        result = checked(left / right).ToString();
                        break;
                    default: break;
                }

                ResultIndex.Push(result);
            }
            catch (OverflowException)
            {
                throw new ResultOverflowException();
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        public string GetResult()
        {
            return ResultIndex.Peek();
        }

        public string GetPreviousResult(int index)
        {
            if (index > 0 && index <= 10)
                return ResultIndex.ToArray()[index];

            throw new InvalidParameterException();
        }
    }
}
