using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMPrenscia.Objects
{
    public static class StringExtensions
    {
        public static bool ParseInt(this string input)
        {
            try
            {
                if (input == "0")
                    throw new InvalidParameterException();

                int.Parse(input, System.Globalization.NumberStyles.None);

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

        public static bool ParseOperator(this string input)
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