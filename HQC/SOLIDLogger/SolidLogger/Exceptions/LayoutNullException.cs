namespace SolidLogger.Exceptions
{
    using System;

    public class LayoutNullException : ApplicationException
    {
        public LayoutNullException(string msg) 
            : base(msg)
        {
        }
    }
}
