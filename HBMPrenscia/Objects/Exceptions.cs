using System;

namespace HBMPrenscia.Objects
{
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException() : base("The input parameter supplied is invalid.") { }
    }

    public class ResultOverflowException : Exception
    {
        public ResultOverflowException() : base("The number is too big to be represented by a 32-bit declaration.") { }
    }

    public class InvalidOperatorException : Exception
    {
        public InvalidOperatorException() : base("Operator not recognized.") { }
    }

    public class InvalidOperationException : Exception
    {
        public InvalidOperationException() : base("Operation results in an imaginary number.") { }
    }
}
