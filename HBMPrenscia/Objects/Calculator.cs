using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMPrenscia.Objects
{
    public class Calculator
    {
        private string LeftArg { get; set; }
        private string RightArg { get; set; }
        private string OperatorArg { get; set; }

        private Stack<string> ResultIndex { get; set; }

        public Calculator(string _left, string _right, string _operator)
        {
            if (!ParseInt(_left) || !ParseInt(_right) || !ParseOperator(_operator))
                throw new InvalidParameterException(); // <- symbolic declaration

            LeftArg = _left;
            RightArg = _right;
            OperatorArg = _operator;

            ResultIndex = new Stack<string>();
        }

        public void setRight(string value)
        {
            if (ParseInt(value))
                RightArg = value;
        }

        public void setLeft(string value)
        {
            if (ParseInt(value))
                LeftArg = value;
        }

        public void calculate()
        {
            string result = string.Empty;

            try
            {
                int left = Int32.Parse(LeftArg);
                int right = Int32.Parse(RightArg);

                switch (OperatorArg)
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

        public string getResult()
        {
            return ResultIndex.Peek();
        }

        public string getPreviousResult(int index)
        {
            try
            {
                return ResultIndex.ToArray()[index];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return string.Empty;
        }

        private bool ParseInt(string input)
        {
            try
            {
                int.Parse(input);

                return true;
            }
            catch (OverflowException)
            {
                throw new ResultOverflowException();
            }
            catch (ArgumentNullException)
            {
                throw new InvalidParameterException();
            }
            catch (FormatException)
            {
                throw new InvalidParameterException();
            }
        }

        private bool ParseOperator(string input)
        {
            switch (input)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    return true;
                default:
                    throw new InvalidOperatorException();
            }
        }
    }
}
