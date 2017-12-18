using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMPrenscia.Objects
{
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException() : base("The input parameter supplied is invalid.") { }
    }

    public class ResultOverflowException : Exception
    {
        public ResultOverflowException() : base("Result Overflow") { }
    }

    public class InvalidOperatorException : Exception
    {
        public InvalidOperatorException() : base("Invalid Operator") { }
    }

    public class InvalidOperationException : Exception
    {
        public InvalidOperationException() : base("Invalid Operation") { }
    }
}
