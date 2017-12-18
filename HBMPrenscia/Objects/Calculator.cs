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
                throw new InvalidParameterException();

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
                        result = (left + right).ToString();
                        break;
                    case "-":
                        result = (left - right).ToString();
                        break;
                    case "*":
                        result = (left * right).ToString();
                        break;
                    case "/":
                        result = (left / right).ToString();
                        break;
                    default: break;
                }

                ResultIndex.Push(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string getResult()
        {
            return ResultIndex.Peek();
        }

        public string getResult(int index)
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
            int _parse = 0;
            Int32.TryParse(input, out _parse);

            return _parse != 0;
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
                    return false;
            }
        }
    }
}
